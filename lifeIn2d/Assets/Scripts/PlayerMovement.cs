using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI coinText; 
    [SerializeField] Slider WaterSlider;
    [SerializeField] Slider Foodslider;
    [SerializeField] Slider Healthslider;

    [SerializeField]public  int coinCount;
    [SerializeField] Boss boss;
    [SerializeField] Transform playerPos;

    [SerializeField] float speed;
    [SerializeField] float reduceSpeed;
    [SerializeField] float rotateSpeed;
    private bool isFacingRight = true;

    float horizontalInput;
    float verticalInput;
    private Animator animator;
    private bool isWalking = false;

    
    void Start()
    {
        WaterSlider.value = 1000;
        Foodslider.value = 1000;
        Healthslider.value = 1000;
      // coinText=GetComponent<TextMeshProUGUI>();
         boss=FindObjectOfType<Boss>();  
   }

   
     void Update()
     {
      coinText.text=$"Coins collected: {coinCount}";
        WaterSlider.value -= reduceSpeed * Time.deltaTime;
        Foodslider.value -= reduceSpeed * Time.deltaTime;

        if (WaterSlider.value <= 0 || Foodslider.value <= 0)
        {
            Healthslider.value -= reduceSpeed * Time.deltaTime;
        }
        if (Healthslider.value == 0)
        {
            SceneManager.LoadScene(2);
        }

        horizontalInput = Input.GetAxisRaw("Horizontal"); 
        verticalInput = Input.GetAxisRaw("Vertical"); 

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
        if (WaterSlider.value != 0 && Foodslider.value != 0)
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

        if (collider.CompareTag("Enemy"))
        {
            Healthslider.value -= 200;
            Vector2 randomDis = new Vector2(Random.Range(transform.position.x + 10, transform.position.x - 10), Random.Range(transform.position.y + 10, transform.position.y - 10));
            transform.position = randomDis;
        }
        if(collider.CompareTag("BossArea")){
        boss.Fightstarted=true;
       
        }
        if(collider.CompareTag("Boss")){
              Healthslider.value -= 300;
          Vector2 randomDis = new Vector2(Random.Range(transform.position.x+20,transform.position.x-20),Random.Range(transform.position.y+20,transform.position.y-20));
          transform.position=randomDis;
       }
 }
    // Returns the bool value of the trigger "IsWalking"
    public bool IsWalking()
    {
        return isWalking;
    }
}