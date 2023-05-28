using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SafeTrigger : MonoBehaviour
{
    public Enemy[] enemy;
    public ShootingEnemy[] shootingEnemies;
    [SerializeField] GameObject dangerMusic;
    [SerializeField] GameObject safeAudio;
   
    void Update()
    {
        shootingEnemies = FindObjectsOfType<ShootingEnemy>();
        enemy = FindObjectsOfType<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].HasTriggered = true;
        }
        for (int i = 0; i < shootingEnemies.Length; i++)
        {
            shootingEnemies[i].SafeTrigger = true;
        }
        if (collider.CompareTag("Player"))
        {
        
            dangerMusic.SetActive(false);
            safeAudio.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].HasTriggered = false;
        }
        for (int i = 0; i < shootingEnemies.Length; i++)
        {
            shootingEnemies[i].SafeTrigger = false;
        }
        if (collider.CompareTag("Player"))
        {
            dangerMusic.SetActive(true);
            safeAudio.SetActive(false);
        }
    }

}
