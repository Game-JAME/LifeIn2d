using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coinText;

    [SerializeField]
    Slider WaterSlider;

    [SerializeField]
    Slider Foodslider;

    [SerializeField]
    public Slider Healthslider;

    [SerializeField]
    public int coinCount;

    [SerializeField]
    Boss boss;

    [SerializeField]
    Transform playerPos;

    [SerializeField]
    GameObject sword;

    [SerializeField]
    float speed;

    [SerializeField]
    float reduceSpeed;

    [SerializeField]
    float rotateSpeed;

    float horizontalInput;
    float verticalInput;
    private bool isWalking = false;
    private bool isFacingRight = true;

    void Start()
    {
        WaterSlider.value = 2000;
        Foodslider.value = 2000;
        Healthslider.value = 2000;
        // coinText=GetComponent<TextMeshProUGUI>();
        boss = FindObjectOfType<Boss>();
        sword.SetActive(false);
    }

    void Update()
    {
        coinText.text = $"Coins collected: {coinCount}";
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

        //Checks Whether the player moves or not
        if (horizontalInput == 0 && verticalInput == 0)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }
        //Activates the sword when the player presses left mouse

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Attacking");
            sword.SetActive(true);
            Invoke("DisableSword", 0.5f);
        }
        Flip();
    }

    void DisableSword()
    {
        sword.SetActive(false);
    }

    //Function to flip the player
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Projectile"))
        {
            Healthslider.value -= 100;
            Vector2 randomDis = new Vector2(
                Random.Range(transform.position.x + 10, transform.position.x - 10),
                Random.Range(transform.position.y + 10, transform.position.y - 10)
            );
            transform.position = randomDis;
        }

        //  if (collider.CompareTag("Enemy"))
        //  {
        //     Healthslider.value -= 200;
        //     Vector2 randomDis = new Vector2(Random.Range(transform.position.x + 10, transform.position.x - 10), Random.Range(transform.position.y + 10, transform.position.y - 10));
        ///     transform.position = randomDis;
        // }
        if (collider.CompareTag("BossArea"))
        {
            boss.Fightstarted = true;
        }
        //if(collider.CompareTag("Boss")){
        //      Healthslider.value -= 300;
        //  Vector2 randomDis = new Vector2(Random.Range(transform.position.x+20,transform.position.x-20),Random.Range(transform.position.y+20,transform.position.y-20));
        //   transform.position=randomDis;
        // }
    }

    // Returns the bool value of the trigger "IsWalking"
    public bool IsWalking()
    {
        return isWalking;
    }
}
