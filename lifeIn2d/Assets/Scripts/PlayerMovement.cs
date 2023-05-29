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

    int rectify = 0;
    float horizontalInput;
    float verticalInput;
    private bool isWalking = false;
    private bool isFacingRight = true;
    SpriteRenderer spriterenderer;

    sceneLoader SceneLoaderScript;

    [SerializeField] GameObject walkSound;
    [SerializeField] AudioSource swordSound;
    [SerializeField] GameObject GongSound;
    [SerializeField] GameObject BossFightSound;
    [SerializeField] GameObject safeTrigger;
    void Start()
    {
        WaterSlider.value = 2000;
        Foodslider.value = 2000;
        Healthslider.value = 2000;
        GongSound.SetActive(false);
        BossFightSound.SetActive(false);
        swordSound=GetComponent<AudioSource>();
        boss = FindObjectOfType<Boss>();
        sword.SetActive(false);
        spriterenderer = gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        SceneLoaderScript = FindObjectOfType<sceneLoader>();
       
    }
    void Update()
    {
       
        coinText.text = coinCount.ToString();   
        WaterSlider.value -= reduceSpeed * Time.deltaTime;
        Foodslider.value -= reduceSpeed * Time.deltaTime;
        RestrictPlayerBeforeBoss(true);

        if (WaterSlider.value <= 0 || Foodslider.value <= 0)
        {
            Healthslider.value -= reduceSpeed * Time.deltaTime;
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Healthslider.value > 0)
        {
            // calculate the movement vector based on the input and the speed
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
            // move the game object
            playerPos.position += movement;

            //Checks Whether the player moves or not
            if (horizontalInput == 0 && verticalInput == 0)
            {
                isWalking = false;
                walkSound.SetActive(false);
            }
            else
            {
                isWalking = true;
                walkSound.SetActive(true);
            }
            //Activates the sword when the player presses left mouse

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Attacking");
                sword.SetActive(true);
                swordSound.Play();
                Invoke("DisableSword", 0.5f);
            }
            Flip();
        }
        else
        {
            Invoke("LoadDeathScene", 0.8f);
        }
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
        if (collider.CompareTag("Projectile")  && Healthslider.value>0)
        {
            Healthslider.value -= 100;
            Boss boss = FindObjectOfType<Boss>();
            if (boss.Fightstarted == true) rectify = -10;

            Vector2 randomDis = new Vector2(
                Random.Range(transform.position.x + 10 + rectify, transform.position.x - 10),
                Random.Range(transform.position.y + 10, transform.position.y - 10)
            );
            transform.position = randomDis;
        }
        if (collider.CompareTag("BossArea"))
        {
            boss.Fightstarted = true;
            GongSound.SetActive(true);
            BossFightSound.SetActive(true); 
            safeTrigger.SetActive(false);
            RestrictPlayerBeforeBoss(false);
        }
    
    }
    public void changeWeapon(Sprite weapon, int damage,Vector2 spriteSize)
    {
        spriterenderer.sprite = weapon;
        spriterenderer.size = spriteSize;
        sword.GetComponent<Sword>().damage = damage;
    }
    // Returns the bool value of the trigger "IsWalking"
    public bool IsWalking()
    { 
        return isWalking;   
    }
    void LoadDeathScene()
    {
        SceneLoaderScript.LoadLevel(4);
    }
    public void RestrictPlayerBeforeBoss(bool value)
    {
        if (value == true)
        {
            if (transform.position.y > 51)
            {
                transform.position = new Vector2(transform.position.x, 46);
            }
            if (transform.position.y < -46)
            {
                transform.position = new Vector2(transform.position.x, -42);
            }
        
            if (transform.position.x > 25)
            {
                transform.position = new Vector2(20,transform.position.y);
            }
            if (transform.position.x < -205)
            {
                transform.position = new Vector2(-200, transform.position.y);
            }
        }
        else
        {
            RestrictPlayerAfterBoss();
        }
    }
    void RestrictPlayerAfterBoss()
    {
        if (transform.position.y > 51)
        {
            transform.position = new Vector2(transform.position.x, 49);
        }
        if (transform.position.y < -46)
        {
            transform.position = new Vector2(transform.position.x, -44);
        }
        if (transform.position.x > -130)
        {
            transform.position = new Vector2(-134, transform.position.y);
        }
        if (transform.position.x < -205)
        {
            transform.position = new Vector2(-200, transform.position.y);
        }
    }
}
