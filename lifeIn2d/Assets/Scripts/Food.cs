using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player.coinCount>=2){
            player.UpdateFoodSliderValue(100);
            player.UpdateHealthSliderValue(50);
            player.coinCount-=2;
            }

        }
    }
}
