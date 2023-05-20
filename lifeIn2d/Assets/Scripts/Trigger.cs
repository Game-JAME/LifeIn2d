using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]Enemy enemy;
    void Start(){
      enemy=FindObjectOfType<Enemy>();
    }
   void OnTriggerEnter2D(Collider2D collider){
       if(collider.CompareTag("Player")){
         enemy.HasTriggered=true;
       }
   }
}
