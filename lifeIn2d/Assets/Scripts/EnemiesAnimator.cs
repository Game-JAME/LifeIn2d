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

    private const string IS_WALKING = "IsWalking";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        animator.SetBool(IS_WALKING, shootingEnemy.IsWalking());
        animator.SetBool(IS_WALKING, enemy.IsWalking());

        if (enemy.transform.position != null)
        {
            animator.SetBool(IS_WALKING, true);
        }
        else
        {
            animator.SetBool(IS_WALKING, false);
        }

        if (shootingEnemy.transform.position != null)
        {
            animator.SetBool(IS_WALKING, true);
        }
        else
        {
            animator.SetBool(IS_WALKING, false);
        }
    }
}
