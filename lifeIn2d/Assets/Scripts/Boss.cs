using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] public Slider Healthslider;
    [SerializeField] GameObject healthObj;
    [SerializeField] EnemiesAnimator enemyAnimation;
    [SerializeField] Transform playerPos;
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject shootingEnemy;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject EnemySpawner;
    [SerializeField] GameObject bossFightAudio;
    public bool Fightstarted = false;
    public float timeShot;
    public float Startimeshot;
    public float maxHealth;
    public float moveSpeed = 2f;
    public float currentHealth;
    sceneLoader SceneLoaderScript;
    bool Died = false;
    void Start()
    {
        timeShot = Startimeshot;
        Healthslider.value = maxHealth;

        healthObj.SetActive(false);
        enemyAnimation.SetBossWalkAnimation(true);

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = FindObjectOfType<PlayerMovement>();
        SceneLoaderScript = FindObjectOfType<sceneLoader>();
        enemyAnimation = GetComponent<EnemiesAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        if (Fightstarted == true && Died == false)
        {
            EnemySpawner.SetActive(false);
            healthObj.SetActive(true);

            Vector2 direction = (playerPos.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            bossFightAudio.SetActive(true);
            if (timeShot <= 0)
            {
                Vector2 rand = new Vector2(Random.Range(transform.position.x + 15, transform.position.x - 15), Random.Range(transform.position.y + 15, transform.position.y - 15));
                Vector2 rand2 = new Vector2(Random.Range(transform.position.x + 15, transform.position.x - 15), Random.Range(transform.position.y + 15, transform.position.y - 15));
                Instantiate(enemy, rand, Quaternion.identity);
                Instantiate(shootingEnemy, rand2, Quaternion.identity);

                timeShot = Startimeshot;
            }
            else
            {
                timeShot -= Time.deltaTime;
            }
            if (Healthslider.value <= maxHealth * 50 / 100)
            {
                moveSpeed += 0.05f * Time.deltaTime;
            }

        }
        if (Healthslider.value <= 0)
        {
            Died = true;
            //Gets the enemy and shooting, and disables them
            Enemy[] enemy = FindObjectsOfType<Enemy>();
            ShootingEnemy[] shootingEnemy = FindObjectsOfType<ShootingEnemy>();
            for (int i = 0; i < enemy.Length; i++)
            {
                Destroy(enemy[i]);
            }
            for (int i = 0; i < shootingEnemy.Length; i++)
            {
                Destroy(shootingEnemy[i]);
            }
            Death();
            Invoke("LoadNextScene", 3f);
        }
    }
    private void Death()
    {
        Destroy(gameObject, 4f);
        transform.position = this.transform.position;
        enemyAnimation.SetBossWalkAnimation(false);
        enemyAnimation.BossDeathAnimation(true);
    }
    void LoadNextScene()
    {
        SceneLoaderScript.LoadLevel(3);
    }
    void Flip()
    {
        Vector3 localScale = transform.localScale;

        float direction = Mathf.Sign(playerPos.position.x - transform.position.x);
        localScale.x = Mathf.Abs(localScale.x) * direction;
        transform.localScale = localScale;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Sword"))
        {
            Healthslider.value -= 30;
        }
        if (Died == false)
        {
            if (collider.CompareTag("Player"))
            {
                player.Healthslider.value -= 150;
                IsBossAttacking();
                Vector2 randomDis = new Vector2(Random.Range(playerPos.position.x + 13, playerPos.position.x - 13), Random.Range(playerPos.position.y + 13, playerPos.position.y - 13));
                playerPos.position = randomDis;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("BossNotAttacking", 1f);
        }
    }
    void IsBossAttacking()
    {
        enemyAnimation.SetBossAttackAnimation(true);
    }
    private void BossNotAttacking()
    {
        enemyAnimation.SetBossAttackAnimation(false);
    }


}
