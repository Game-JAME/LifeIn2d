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

    [SerializeField] Transform playerPos ;

    [SerializeField] float speed;
     [SerializeField] float reduceSpeed;
  
    void Start()
     {
        WaterSlider.value = 1000;
        Foodslider.value = 1000;
        Healthslider.value = 1000;
   }

     // Update is called once per frame
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

        float horizontalInput = Input.GetAxis("Horizontal"); // get the value of the horizontal input axis
         float verticalInput = Input.GetAxis("Vertical"); // get the value of the vertical input axis

         // calculate the movement vector based on the input and the speed
         Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;

         // move the game object
         playerPos.position += movement;
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
     void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Projectile")){
            Healthslider.value-=100;
        }
     }

}