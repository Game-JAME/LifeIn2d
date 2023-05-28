using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] Slider Healthslider;
    [SerializeField]GameObject healthObj;
    [SerializeField] GameObject projectile;
    [SerializeField]Transform playerPos;
    [SerializeField] PlayerMovement player;
    [SerializeField]GameObject shootingEnemy;
    [SerializeField]GameObject enemy;
    public bool Fightstarted=false;
    public float timeShot;
    public float Startimeshot;
    public float maxHealth;
    public float moveSpeed = 2f; 
    sceneLoader SceneLoaderScript;

    void Start()
    {
        timeShot=Startimeshot;
     Healthslider.value=maxHealth;

       healthObj.SetActive(false);
      

       playerPos=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       player=FindObjectOfType<PlayerMovement>();
       SceneLoaderScript = FindObjectOfType<sceneLoader>();
       
    }   

    // Update is called once per frame
    void Update()
    {       
       if(Fightstarted==true){

            healthObj.SetActive(true);
            Vector3 randomDis=new Vector2(Random.Range(playerPos.position.x+5,playerPos.position.x-5),Random.Range(playerPos.position.y+5,playerPos.position.y-5));
             Vector2 direction = (randomDis - transform.position).normalized;
             transform.Translate(direction * moveSpeed * Time.deltaTime);
            
         if(timeShot <=0 ){
            Vector2 rand=new Vector2(Random.Range(transform.position.x+20,transform.position.x-20),Random.Range(transform.position.y+20,transform.position.y-20));
            Vector2 rand2=new Vector2(Random.Range(transform.position.x+20,transform.position.x-20),Random.Range(transform.position.y+20,transform.position.y-20));

             Instantiate(projectile,transform.position,Quaternion.identity);
             Instantiate(enemy,rand,Quaternion.identity);
              Instantiate(shootingEnemy,rand2,Quaternion.identity);

             timeShot=Startimeshot;
        }
          else{
            timeShot-=Time.deltaTime;
        }
       if( Healthslider.value <= maxHealth*50/100){ 
          moveSpeed+=0.05f*Time.deltaTime;
         }
       
       }
       if(Healthslider.value<=0){
        Destroy(gameObject);
            SceneLoaderScript.LoadLevel(3);        
       }
    }
  
    
  
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Sword")){
         Healthslider.value-=30;
      }
    }
}
