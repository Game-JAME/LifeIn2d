using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

public float speed;
public float retreatDistance;
public float stopDistance;

public float timeShot;
public float Startimeshot;
[SerializeField] Transform player;
[SerializeField] GameObject projectile;

void Start()
    {
        timeShot=Startimeshot;
        player=GameObject.FindGameObjectWithTag("Player").transform;
    }
void Update(){
    if(Vector2.Distance(transform.position,player.position)>stopDistance){
        transform.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }else if(Vector2.Distance(transform.position,player.position)<stopDistance && Vector2.Distance(transform.position,player.position)>retreatDistance){
      transform.position=this.transform.position;
            }
    else if(Vector2.Distance(transform.position,player.position)<retreatDistance){
         transform.position=Vector2.MoveTowards(transform.position,player.position,-speed*Time.deltaTime);
        }
        
    if(timeShot <=0){
        Instantiate(projectile,transform.position,Quaternion.identity);
        timeShot=Startimeshot;
    }else{
        timeShot-=Time.deltaTime;
    }

    }
}
