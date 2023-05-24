using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchaser : MonoBehaviour
{
    [SerializeField] int cost = 2;
    PlayerMovement player;
    [SerializeField] bool playerInside = false; // flag to check if player inside the trigger
<<<<<<< Updated upstream:lifeIn2d/Assets/Scenes/Purchaser.cs
    [SerializeField] GameObject item;
=======
    // Start is called before the first frame update
    [SerializeField] Sprite item;
>>>>>>> Stashed changes:lifeIn2d/Assets/Scripts/Purchaser.cs
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
                if(playerCoin >= cost)
                {
                    player.UpdateCoinCount(-cost);// remove the amount from player
<<<<<<< Updated upstream:lifeIn2d/Assets/Scenes/Purchaser.cs
<<<<<<< Updated upstream:lifeIn2d/Assets/Scenes/Purchaser.cs
=======
                    // find player object and get reference to current sword
                    GameObject playerObj = GameObject.FindWithTag("Player");
                    GameObject currentWeapon = playerObj.transform.GetChild(0).gameObject;
                    // change weapon 
                    GameObject newWeapon = Instantiate(item,currentWeapon.transform.position,Quaternion.identity);
                    newWeapon.transform.parent = playerObj.transform;
                    player.SetSword(newWeapon);
                    // destroy previous weapon
                    Destroy(currentWeapon);
                    

>>>>>>> Stashed changes:lifeIn2d/Assets/Scripts/Purchaser.cs
                    Debug.Log("purchase successfulll");
=======
                    player.changeWeapon(item);
>>>>>>> Stashed changes:lifeIn2d/Assets/Scripts/Purchaser.cs
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
