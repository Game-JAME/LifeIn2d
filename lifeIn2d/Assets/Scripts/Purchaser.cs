using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchaser : MonoBehaviour
{
    [SerializeField] int cost = 2;
    PlayerMovement player;
    [SerializeField] bool playerInside = false; // flag to check if player inside the trigger
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            //
            // coming soon... code to display item details
            //
           
            playerInside = true; 
            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerInside = false; 
    }
    // Update is called once per frame
    void Update()
    {
        //check if player presses e to purchase when inside
        if (playerInside && Input.GetKeyDown("e"))
            {
                int playerCoin = player.GetCoinCount();
                Debug.Log(player.GetCoinCount());
                if(playerCoin >= cost)
                {
                     player.coinCount-=cost;// remove the amount from player
                   // player.UpdateCoinCount(-cost);// remove the amount from player
                    Debug.Log("purchase successfulll");
                }
                else
                {
                    Debug.Log("player no money");
                    //
                    // code to display no money
                    //
                }
            }
    }
}
