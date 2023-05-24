using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]Transform   enemyPos;
    [SerializeField]Transform player;
    [SerializeField]int minDistance;
    [SerializeField]Transform orginalPos;
    [SerializeField]PlayerMovement playerMovement;
    public bool HasTriggered=false;
      public float moveSpeed = 5f; // The speed at which the enemy moves
    public float detectionRadius = 5f; // The radius within which the player triggers the movement
    public float Health = 100f;
    public float retreatDistance;

    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement=FindObjectOfType<PlayerMovement>();
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
          if(orginalPos==null)
          {  
            transform.position=this.transform.position;
          }
          else if (Vector2.Distance(transform.position,player.position)>retreatDistance){
           transform.position= Vector2.MoveTowards(transform.position,orginalPos.position,moveSpeed*Time.deltaTime);
          }
          else if(Vector2.Distance(transform.position,player.position)<retreatDistance){
            transform.position=this.transform.position;
          }
        }
       if(Health<=0f){
         DestroyEnemy(true);
       }
     //   if(HasTriggered==true){
      // enemyPos.position=Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
      //  }
    }
    void OnTriggerEnter2D(Collider2D collider){
      if(collider.CompareTag("Player")){
        playerMovement.Healthslider.value-=100;
        Vector2 randomDis = new Vector2(Random.Range(transform.position.x+10,transform.position.x-10),Random.Range(transform.position.y+10,transform.position.y-10));
          player.position=randomDis;
      }
      if(collider.CompareTag("Sword")){
        Health-=30;
      }
    }
   public void DestroyEnemy(bool value){
     if(value==true){
      Destroy(gameObject);
     }
   }
    public void TakeDamage(int value){
      Health-=value;
    }
}
