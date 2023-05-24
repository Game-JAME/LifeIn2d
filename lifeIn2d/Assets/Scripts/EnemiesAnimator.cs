using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnimator : MonoBehaviour
{
    [SerializeField] private ShootingEnemy shootingEnemy;
    private Animator animator;
    public void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", shootingEnemy.IsWalking());
    }
}
