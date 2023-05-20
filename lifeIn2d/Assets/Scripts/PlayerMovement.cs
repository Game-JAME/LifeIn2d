using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    
     [SerializeField] Slider WaterSlider;
     [SerializeField] Slider Foodslider;
    [SerializeField] Slider Healthslider;

    [SerializeField] Transform transform ;

    [SerializeField] Food food;
  //  [SerializeField] Water water;
    [SerializeField] float speed;
     [SerializeField] float reduceSpeed;

    void Start()
     {
        
        food=FindObjectOfType<Food>();
     //   water=FindObjectOfType<Water>();    
        
        WaterSlider.value = 100;
        Foodslider.value = 100;
        Healthslider.value = 100;
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

        float horizontalInput = Input.GetAxis("Horizontal"); // get the value of the horizontal input axis
         float verticalInput = Input.GetAxis("Vertical"); // get the value of the vertical input axis

         // calculate the movement vector based on the input and the speed
         Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;

         // move the game object
         transform.position += movement;
     }

    public void UpdateWaterSliderValue(float value)
    {
         WaterSlider.value = value;
       
       
    }
    public void UpdateFoodSliderValue(float value)
    {
        Foodslider.value = value;
    }
    public void UpdateHealthSliderValue(float value)
    {
        if(WaterSlider.value!=0 &&Foodslider.value!=0)
        {
            Healthslider.value += value;

        }
        }
}