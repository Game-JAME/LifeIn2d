using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{  
     public float timeSpawn;
   public float StartimeSpawn;
   [SerializeField]GameObject shootingEnemy;
    [SerializeField]GameObject enemy;
    void Start()
    {
        timeSpawn=StartimeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSpawn<=0f){
             Vector2 rand=new Vector2(Random.Range(transform.position.x+20,transform.position.x-20),Random.Range(transform.position.y+20,transform.position.y-20));
            Vector2 rand2=new Vector2(Random.Range(transform.position.x+20,transform.position.x-20),Random.Range(transform.position.y+20,transform.position.y-20));

              Instantiate(enemy,rand,Quaternion.identity);
              Instantiate(shootingEnemy,rand2,Quaternion.identity);
            timeSpawn=StartimeSpawn;
        }
        else{
            timeSpawn-=Time.deltaTime;
        }
    }
}
