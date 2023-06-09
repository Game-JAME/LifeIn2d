using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Purchaser : MonoBehaviour
{
    [SerializeField] int cost = 2;
    PlayerMovement player;
    [SerializeField]GameObject text;
    [SerializeField] bool playerInside = false; // flag to check if player inside the trigger
    [SerializeField] bool isHealthItem;
    [SerializeField] bool isWater;
    [SerializeField] float value;
    [SerializeField] Sprite item;
    [SerializeField] int damage;
    [SerializeField] GameObject buyText;
    [SerializeField] Vector2 spriteSize; // to change weapon sprite size based on the sprite
    void Start()
    {
        text.SetActive(false);
        buyText.SetActive(false);
        player = FindObjectOfType<PlayerMovement>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            // coming soon... code to display item details
            //
            playerInside = true;
            text.SetActive(playerInside);
            buyText.SetActive(playerInside);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerInside = false;
        text.SetActive(playerInside);
        buyText.SetActive(playerInside);
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
                    player.UpdateCoinCount(-cost);// remove the amount from player
                    gameObject.GetComponentInParent<AudioSource>().Play();
                    if (isHealthItem)
                    {
                        if (isWater)
                        {
                            player.UpdateWaterSliderValue(value);
                        }
                        else
                        {
                            player.UpdateFoodSliderValue(value);
                        }
                        player.UpdateHealthSliderValue(50);
                    }
                    else
                    {
                        player.changeWeapon(item,damage,spriteSize);
                    }
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
