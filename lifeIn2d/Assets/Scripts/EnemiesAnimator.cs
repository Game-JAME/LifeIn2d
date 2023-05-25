using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnimator : MonoBehaviour
{
    [SerializeField] private ShootingEnemy shootingEnemy;
    private Animator animator;
     private const string IS_WALKING = "IsWalking";
      private const string IS_ATTACKING = "IsAttacking";
      public bool isWalking=false;
      
    public void Awake()
    {
        animator = GetComponent<Animator>();
       // animator.SetBool("IsWalking", shootingEnemy.IsWalking());
    }
    void Start(){
       // player=FindObjectOfType<PlayerMovement>();
       // shootingEnemy=GetComponent<ShootingEnemy>();
    }
    void Update(){
         
         ///  Debug.Log("Walking");
    }
    public void SetWalkingAnimation(bool value){
          animator.SetBool(IS_WALKING, value);
    }
}
