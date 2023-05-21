using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public float speed;
    [SerializeField] Transform playerPos;
   // [SerializeField] PlayerMovement player;
   Vector2 target;
    void Start()
    {
     //  player=FindObjectOfType<PlayerMovement>();
        playerPos=GameObject.FindGameObjectWithTag("Player").transform;
      target=new Vector2(playerPos.position.x,playerPos.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if(transform.position.x==target.x && transform.position.y==target.y){
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
           
             Destroy(gameObject);
        }
    }
}
