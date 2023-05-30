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
             Vector2 rand=new Vector2(Random.Range(transform.position.x+30,transform.position.x-30),Random.Range(transform.position.y+30,transform.position.y-30));
            Vector2 rand2=new Vector2(Random.Range(transform.position.x+30,transform.position.x-30),Random.Range(transform.position.y+30,transform.position.y-30));

              Instantiate(enemy,rand,Quaternion.identity);
              Instantiate(shootingEnemy,rand2,Quaternion.identity);
            timeSpawn=StartimeSpawn;
        }
        else{
            timeSpawn-=Time.deltaTime;
        }
    }
}
