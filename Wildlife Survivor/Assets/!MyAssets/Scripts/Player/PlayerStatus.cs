using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This script is used for the player's Hunger, Thirst, and Vitality
/// If either of these reach 0, the player dies
/// The sprinting script affects the hunger and thirst as well, draining faster while sprinting
/// </summary>

public class PlayerStatus : MonoBehaviour {

    public float hunger = 30;
    public float thirst = 100;
    public float health = 100;
    private float maxHealth = 100;
    private float lastHealth = 100;
    public float hurtTimer = 0;
    public float healthRegenRate = 0.1f;
    public float hungerDrainRate = 0.1f;
    public float thirstDrainRate = 0.5f;
    public bool infiniteHealth = false;


    public Slider hpBar;
    public Slider thirstBar;
    public Slider hungerBar;

    static public int bunniesSaved = 0;

    public SprintingScript sprintScript; //for retrieving stamina

    public AudioSource heartBeatSFX;
    public AudioSource hurtSFX;
    public AudioSource lowThirstSFX;

    public CanvasGroup bloodScreen;
    public CanvasGroup hitScreen;

    public CanvasGroup hungerFullText;
    public bool firstTimeTextShow;

    public VignetteAndChromaticAberration hungerScreen;
    public MotionBlur thirstScreen;
    public BlurOptimized staminaScreen;

    public bool inBushStealth = false;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateHungerScreen();
        UpdateThirstScreen();
        UpdateHitAndBloodScreen();

        //Updating the bars
        if (hpBar != null && thirstBar != null && hungerBar != null)
        {
            hpBar.value = health;
            thirstBar.value = thirst;
            hungerBar.value = hunger;
        }
        else
        {
            Debug.LogWarning("No hp bar, thirst bar, and/or hunger bar is assigned to PlayerStatus.cs");
        }

        //Overtime, the player loses hunger and thirst. 
        if (hunger > 100)
        {
            hunger = 100;
        }
        if (hunger > 0.1f)
            hunger -= hungerDrainRate * Time.deltaTime;
        else if (hunger <= 0.1f)
        {
            GameOver();
        }
        if (thirst > 0)
            thirst -= thirstDrainRate * Time.deltaTime;
        else if (thirst <= 0)
        {
            GameOver();
        }

        /*
        if (hunger >= 100 && firstTimeTextShow == false)
        {
            hungerFullText.alpha = 1;
            firstTimeTextShow = true;
        }
        */
        //Overtime, heal
        if (health > 0 && health < maxHealth)
            health += healthRegenRate * Time.deltaTime;
        if (health > maxHealth || infiniteHealth == true)
        {
            health = maxHealth;
        }
        else if (health <= 0 && infiniteHealth == false)
        {
            GameOver();
        }

        if (hurtTimer > 0)
        {
            hurtTimer -= 1 * Time.deltaTime;
        }

        //When the player gets hit
        if (lastHealth < health)
        {
            //Flash the screen red, alpha is based on how severe the damage was
            //hitScreen.alpha = (lastHealth - health) / 50;
            lastHealth = health;
        }
        else if (lastHealth > health)
        {
            //Play healing effect
            lastHealth = health;
        }

        //Stamina
        if (sprintScript.stamina <= 30 && sprintScript.stamina != 0)
        {
            staminaScreen.enabled = true;
            staminaScreen.blurSize = 5 - ((sprintScript.stamina / 30) * 5);
        }
        else
        {
            staminaScreen.enabled = false;
        }
	}

    void UpdateHungerScreen()
    {
        //Hunger screen makes use of vignette and will slowly close in up to 1
        if (hunger < 30 && hunger != 0)
        {
            hungerScreen.intensity = (1 - (hunger / 30));
        }
        else
        {
            hungerScreen.intensity = 0;
        }
    }

    //The Thirst screen makes use of the twirl effect and is passively animated. 
    void UpdateThirstScreen()
    {
        //Original thirst screen
        if (thirst < 30)
        {
            thirstScreen.blurAmount = 1 - (thirst / 30);
            lowThirstSFX.volume = 1 - (thirst / 15);
        }
        else
        {
            thirstScreen.blurAmount = 0;
            lowThirstSFX.volume = 0;
        }
        /*
        //Alternate
        if (thirst < 30 && thirst != 0)
        {
            hungerScreen.intensity = 1 - (hunger / 30);
        }
        */
    }

    void UpdateHitAndBloodScreen()
    {
        if (hitScreen.alpha > 0)
        {
            hitScreen.alpha -= 0.75f * Time.deltaTime;
        }

        if (health <= 50 && health != 0)
        {
            bloodScreen.alpha = 1 -(health / 50);
            heartBeatSFX.volume = 1 - (health / 50);
        }
        else if (health > 50)
        {
            bloodScreen.alpha = 0;
            heartBeatSFX.volume = 0;
        }
    }

    void GameOver()
    {
        //Die, GameOver
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Game Over");        
    }
}
