using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

public float speed;
public float retreatDistance;
public float stopDistance;
public float AttackRadius;

public float timeShot;
public float Startimeshot;
[SerializeField] Transform player;
[SerializeField] GameObject projectile;

[SerializeField]Transform currentposition;
      public float moveSpeed = 5f; 
    public float detectionRadius = 5f;
    public bool SafeTrigger=false;
void Start()
    {
        timeShot=Startimeshot;
        player=GameObject.FindGameObjectWithTag("Player").transform;
    }
void Update(){
      float distance = Vector2.Distance(player.position, transform.position);

        // Check if the player is within the detection radius
    if(SafeTrigger==false)
    {
        if (distance <= detectionRadius &&distance>retreatDistance)
        {
                transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }
         else if(Vector2.Distance(transform.position,player.position)<stopDistance && Vector2.Distance(transform.position,player.position)>retreatDistance){
                transform.position=this.transform.position;
          }
        else if(Vector2.Distance(transform.position,player.position)<retreatDistance){
                transform.position=Vector2.MoveTowards(transform.position,player.position,-speed*Time.deltaTime);
        }
        else{
              transform.position=currentposition.position;
        }
    } else{
            transform.position=currentposition.position;

        }

      
        
    if(timeShot <=0&&distance <= AttackRadius){
        Instantiate(projectile,transform.position,Quaternion.identity);
        timeShot=Startimeshot;
     }else if (distance <= AttackRadius) {
        timeShot-=Time.deltaTime;
        }

     }
}
