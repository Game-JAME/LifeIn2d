using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private Animator animator;
    private const string IS_WALKING = "IsWalking";
    private void Awake()
    {
        animator = GetComponent<Animator>();
        // Changes the animation as the movement is more the zero or not 
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
    }

    private void Update()
    {
        // Changes the animation as the movement is more the zero or not 
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
    }
}
