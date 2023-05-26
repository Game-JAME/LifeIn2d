using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform enemyPos;
    [SerializeField] Transform player;
    [SerializeField] int minDistance;
    [SerializeField] Transform orginalPos;
    [SerializeField] PlayerMovement playerMovement;

    private bool isWalking = false;

    public bool HasTriggered = false;
    public float moveSpeed = 5f; // The speed at which the enemy moves
    public float detectionRadius = 5f; // The radius within which the player triggers the movement
    public float Health = 100f;
    public float retreatDistance;
    public float attackRange;

   [SerializeField]  EnemiesAnimator enemyAnimator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        enemyAnimator = GetComponent<EnemiesAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        float distance = Vector2.Distance(player.position, transform.position);

        // Check if the player is within the detection radius
        if (distance <= detectionRadius && HasTriggered == false)
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            enemyAnimator.SetWalkingAnimation(true);
            transform.Translate(direction * moveSpeed * Time.deltaTime);

        }
        else
        {
            if (orginalPos == null)
            {
                transform.position = this.transform.position;
                enemyAnimator.SetWalkingAnimation(false);
            }
            else if (Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                enemyAnimator.SetWalkingAnimation(true);
               transform.position = Vector2.MoveTowards(transform.position, orginalPos.position, moveSpeed * Time.deltaTime);
            }
           else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                enemyAnimator.SetWalkingAnimation(false);
                transform.position = this.transform.position;
            }
        }
       
        if (Health <= 0f)
        {
            DestroyEnemy(true);
        }

        // Attack only if the player is within attack range
        if (HasTriggered == false && distance <= attackRange)
        {
            enemyAnimator.SetAttackAnimation(true);
            playerMovement.Healthslider.value -= 100;
            Vector2 randomDis = new Vector2(Random.Range(transform.position.x + 10, transform.position.x - 10), Random.Range(transform.position.y + 10, transform.position.y - 10));
            player.position = randomDis;
        }
        else
        {
            enemyAnimator.SetAttackAnimation(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
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
    void Flip()
    {
        Vector3 localScale = transform.localScale;

        float direction = Mathf.Sign(player.position.x - transform.position.x);
        localScale.x = Mathf.Abs(localScale.x) * direction;
        transform.localScale = localScale;
    }
}
