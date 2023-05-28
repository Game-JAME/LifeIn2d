using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private bool isWalking;
    public float speed;
    public float retreatDistance;
    public float stopDistance;
    public float AttackRadius;

    public float timeShot;
    public float Startimeshot;

    [SerializeField]
    EnemiesAnimator enemyAnimation;

    [SerializeField]
    Transform player;

    [SerializeField] AudioSource fireball;
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform currentposition;
    public float moveSpeed = 5f;
    public float detectionRadius = 5f;
    public bool SafeTrigger = false;
    public float Health = 50f;

    void Start()
    {
        timeShot = Startimeshot;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnimation = GetComponent<EnemiesAnimator>();
        fireball=GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (Health <= 0f)
        {
            DestroyEnemy(true);
            return;
        }

        if (SafeTrigger)
        {
            HandleSafeAreaMovement();
        }
        else
        {
            HandleEnemyMovement(distance);
        }

       
    }

    void HandleSafeAreaMovement()
    {
        enemyAnimation.SetWalkingAnimation(false);

        if (currentposition == null)
        {
            transform.position = this.transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                currentposition.position,
                moveSpeed * Time.deltaTime
            );
        }
    }

    void HandleEnemyMovement(float distance)
    {
        HandleEnemyOrientation();
        if (distance <= detectionRadius && distance > stopDistance)
        {
            MoveTowardsPlayer();
        }
        else if (distance <= stopDistance && distance > retreatDistance)
        {
            StopMoving(distance);
        }
        else if (distance <= retreatDistance)
        {
            MoveAwayFromPlayer();
        }
        else
        {
            SetPosition();
        }
    }

    void HandleEnemyOrientation()
    {
        Vector3 localScale = transform.localScale;

        float direction = Mathf.Sign(player.position.x - transform.position.x);
        localScale.x = Mathf.Abs(localScale.x) * direction;
        transform.localScale = localScale;
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
        enemyAnimation.SetWalkingAnimation(true);
    }

    void StopMoving(float distance)
    {
        transform.position = this.transform.position;
        enemyAnimation.SetWalkingAnimation(false);

        if (timeShot <= 0 && distance <= AttackRadius)
        {
            ShootProjectile();
          fireball.Play();
        }
        else if (distance <= AttackRadius)
        {
            timeShot -= Time.deltaTime;
        }
    }
    void ShootProjectile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        timeShot = Startimeshot;
    }

    void MoveAwayFromPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            -speed * Time.deltaTime
        );
        enemyAnimation.SetWalkingAnimation(true);
    }

    void SetPosition()
    {
        enemyAnimation.SetWalkingAnimation(false);
        if (currentposition == null)
        {
            transform.position = this.transform.position;
        }
        else
        {
            //transform.position = currentposition.position;
        }
    }


    public void DestroyEnemy(bool value)
    {
        if (value == true)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Sword"))
        {
            Health -= 30;
        }
    }
}
