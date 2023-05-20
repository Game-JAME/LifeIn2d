using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]Transform   enemyPos;
    [SerializeField]Transform player;
    [SerializeField]int minDistance;
    [SerializeField]Transform orginalPos;
    
    public bool HasTriggered=false;
      public float moveSpeed = 5f; // The speed at which the enemy moves
    public float detectionRadius = 5f; // The radius within which the player triggers the movement

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
          float distance = Vector2.Distance(player.position, transform.position);

        // Check if the player is within the detection radius
        if (distance <= detectionRadius &&HasTriggered==false)
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }else{
           transform.position= Vector2.MoveTowards(transform.position,orginalPos.position,moveSpeed*Time.deltaTime);

        }
     //   if(HasTriggered==true){
      // enemyPos.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
      //  }
    }
}
