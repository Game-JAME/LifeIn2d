using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemiesAnimator enemyAnimation;
    [SerializeField] Transform enemyPos;
    [SerializeField] Transform player;
    [SerializeField] int minDistance;
    [SerializeField] Transform orginalPos;
    [SerializeField] PlayerMovement playerMovement;

    private bool isWalking = false;
    private float distance;

    public bool HasTriggered = false;
    public float moveSpeed = 5f; // The speed at which the enemy moves
    public float detectionRadius = 5f; // The radius within which the player triggers the movement
    public float Health = 100f;
    public float retreatDistance;

    void Start()
    {
        enemyAnimation = GetComponent<EnemiesAnimator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerMovement.Healthslider.value -= 100;
            Vector2 randomDis = new Vector2(Random.Range(transform.position.x + 10, transform.position.x - 10), Random.Range(transform.position.y + 10, transform.position.y - 10));
            player.position = randomDis;
        }
        if (collider.CompareTag("Sword"))
        {
            Health -= 30;
        }
    }
    public void DestroyEnemy(bool value)
    {
        if (value == true)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int value)
    {
        Health -= value;
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void chasePlayer()
    {
        enemyAnimation.SetWalkingAnimation(true);
        distance = Vector2.Distance(player.position, transform.position);

        // Check if the player is within the detection radius
        if (distance <= detectionRadius && HasTriggered == false)
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            if (distance > 0) {
                // Move the enemy towards the player
                enemyAnimation.SetWalkingAnimation(true);
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (orginalPos == null)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                enemyAnimation.SetWalkingAnimation(true);
                transform.position = Vector2.MoveTowards(transform.position, orginalPos.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = this.transform.position;
            }
        }
        if (Health <= 0f)
        {
            DestroyEnemy(true);
        }
        //   if(HasTriggered==true){
        // enemyPos.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        //  }
    }
}
