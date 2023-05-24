using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] Transform player;

    [SerializeField] GameObject projectile;

    [SerializeField] Transform currentposition;
    public float moveSpeed = 5f;
    public float detectionRadius = 5f;
    public bool SafeTrigger = false;
    public float Health = 50f;
    void Start()
    {
        timeShot = Startimeshot;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);


        if (Health <= 0f)
        {
            DestroyEnemy(true);
        }
        if (SafeTrigger == false)
        {
            if (distance <= detectionRadius && distance > retreatDistance)
            {
                
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                
            }
            else if (Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
            else
            {
                if (currentposition == null) { transform.position = this.transform.position; }
                else
                {
                    transform.position = currentposition.position;
                }
            }
        }
        else
        {
            if (currentposition == null)
            {
                
                transform.position = this.transform.position;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentposition.position, moveSpeed * Time.deltaTime);
            }
        }



        if (timeShot <= 0 && distance <= AttackRadius)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeShot = Startimeshot;
        }
        else if (distance <= AttackRadius)
        {
            timeShot -= Time.deltaTime;
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

    public bool IsWalking()
    {
        return isWalking;
    }
}
