using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Water : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    void Start()
    {
        player=FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            player.UpdateWaterSliderValue(100);
            player.UpdateHealthSliderValue(50);
        }

    }
}
