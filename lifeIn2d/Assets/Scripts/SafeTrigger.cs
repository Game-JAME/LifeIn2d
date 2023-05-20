using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeTrigger : MonoBehaviour
{
 
   public Enemy[] enemy;
    void Start(){
   
      enemy=FindObjectsOfType<Enemy>();
      }
    
   
   void OnTriggerEnter2D(Collider2D collider){
    for (int i = 0; i < enemy.Length; i++)
    {
        enemy[i].HasTriggered=true;
    }
   }
   void OnTriggerExit2D(Collider2D collider){
       for (int i = 0; i < enemy.Length; i++)
    {
        enemy[i].HasTriggered=false;
    }
   }
  
}
