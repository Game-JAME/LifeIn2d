using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnimator : MonoBehaviour
{
    //[SerializeField] private ShootingEnemy shootingEnemy;
    private Animator animator;
     private const string IS_WALKING = "IsWalking";
     private const string IS_ATTACKING = "IsAttacking";
      public bool isWalking=false;
    public bool isAttacking = false;
    public void Awake()
    {
        animator = GetComponent<Animator>();
       // animator.SetBool("IsWalking", shootingEnemy.IsWalking());
    }
    public void SetWalkingAnimation(bool value){
          animator.SetBool(IS_WALKING, value);
    }
    public void SetAttackAnimation(bool value)
    {
        animator.SetBool(IS_ATTACKING, value);
    }
    public void SetBossWalkAnimation(bool value)
    {
        animator.SetBool("walk", value);
    }
    public void SetBossAttackAnimation(bool value)
    {
        animator.SetBool("attack", value);
    }
    public void BossDeathAnimation(bool value)
    {
        animator.SetBool("death", value);
    }

}
