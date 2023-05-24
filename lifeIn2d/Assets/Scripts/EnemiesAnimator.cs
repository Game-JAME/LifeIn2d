using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnimator : MonoBehaviour
{
    [SerializeField] private ShootingEnemy shootingEnemy;
    [SerializeField] private Enemy enemy;
    private Animator shootingEnemyAnimation;
    private Animator meleeEnemyAnimation;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        animator.SetBool("IsWalking", shootingEnemy.IsWalking());
        animator.SetBool("IsWalking", enemy.IsWalking());

        if (enemy.transform.position != null)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
