using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    
     [SerializeField] Slider WaterSlider;
     [SerializeField] Slider Foodslider;
    [SerializeField] Slider Healthslider;

    [SerializeField] int coinCount;
    [SerializeField] Boss boss;
    [SerializeField] Transform playerPos ;

    [SerializeField] float speed;
     [SerializeField] float reduceSpeed;
     [SerializeField] float rotateSpeed;
   private bool isFacingRight = true;

    float horizontalInput;
    float verticalInput;
    void Start()
     {
        WaterSlider.value = 1000;
        Foodslider.value = 1000;
        Healthslider.value = 1000;
 
         boss=FindObjectOfType<Boss>();  
   }

   
     void Update()
     {

         WaterSlider.value -= reduceSpeed*Time.deltaTime;
         Foodslider.value -= reduceSpeed * Time.deltaTime;

          if(WaterSlider.value <= 0 || Foodslider.value<=0) 
          {
              Healthslider.value -= reduceSpeed*Time.deltaTime;
          }
          if(Healthslider.value==0){
             SceneManager.LoadScene(2);
          }

<<<<<<< Updated upstream
         horizontalInput = Input.GetAxisRaw("Horizontal"); 
         verticalInput = Input.GetAxisRaw("Vertical"); 
         //transform.rotation=Quaternion.Euler(horizontalInput,verticalInput,0f);
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
         playerPos.position += movement;
         Flip();
         
=======
         // calculate the movement vector based on the input and the speed
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;          
         // move the game object
        playerPos.position += movement;
        //transform.right = movement;
        if( horizontalInput ==0 && verticalInput == 0){
            isWalking=false;
        }
        else { 
            isWalking = true;
        }
        Flip();

        //Debug.Log(isWalking);
        //Debug.Log(verticalInput);


        // restrict player to boundaries

        // y-axis
        if (playerPos.position.y >= 51.2f)
        {
            playerPos.position = new Vector3(playerPos.position.x,51.2f,0);
        }
        else if(playerPos.position.y <= -50.5f)
        {
            playerPos.position = new Vector3(playerPos.position.x,-50.5f,0);
        }

        // x-axis
        if (playerPos.position.x >= 25.0f)
        {
            playerPos.position = new Vector3(25.0f,playerPos.position.y,0);
        }
        else if (playerPos.position.x <= -202.0f)
        {
            playerPos.position = new Vector3(-202.0f,playerPos.position.y,0);
        }
>>>>>>> Stashed changes
     }

    private void Flip()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void UpdateWaterSliderValue(float value)
    {
         WaterSlider.value += value;
       
       
    }
    public void UpdateFoodSliderValue(float value)
    {
        Foodslider.value += value;
    }
    public void UpdateHealthSliderValue(float value)
    {
        if(WaterSlider.value!=0 &&Foodslider.value!=0)
        {
            Healthslider.value += value;
        }
     }

    public void UpdateCoinCount(int val)
    {
        coinCount += val;
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

     void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Projectile")){
            Healthslider.value-=100;
             Vector2 randomDis = new Vector2(Random.Range(transform.position.x+10,transform.position.x-10),Random.Range(transform.position.y+10,transform.position.y-10));
          transform.position=randomDis;
        }
     
      if(collider.CompareTag("Enemy")){
          Healthslider.value-=200;
          Vector2 randomDis = new Vector2(Random.Range(transform.position.x+10,transform.position.x-10),Random.Range(transform.position.y+10,transform.position.y-10));
          transform.position=randomDis;
      }
    if(collider.CompareTag("BossArea")){
        boss.Fightstarted=true;
    }
     }
  
}