using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private Animator animator;
    [SerializeField] PlayerMovement player;
    private const string IS_WALKING = "IsWalking";
        private const string IS_ATTACKING = "IsAttacking";
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player=FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        // Changes the animation as the movement is more the zero or not 
        if(player.Healthslider.value > 0) 
        {
            animator.SetBool(IS_WALKING, playerMovement.IsWalking());
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Change KeyCode.Space to the desired attack button
            {
                animator.SetBool(IS_ATTACKING, true);
            }
            else
            {
                animator.SetBool(IS_ATTACKING, false);
            }
        }
        else
        {
            animator.SetBool("Death", true);
        }    
    }
   
}
