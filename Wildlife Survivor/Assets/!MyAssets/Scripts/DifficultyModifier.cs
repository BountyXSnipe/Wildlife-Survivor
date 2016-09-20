using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyModifier : MonoBehaviour {

    public static string difficulty; //easy, medium, hard or custom are the different modes

    //Modifiers that make the game easier
    public static bool noHunger = false;
    public static bool noThirst = false;
    public static bool noFog = false;
    public static bool noWolves = false;
    public static bool dayTime = false;
    public static bool infiniteHealth = false;
    public static bool infiniteStamina = false;

    //Modifiers that alter gameplay
    public static bool rabbitVision = false; //Camera is split into 2 and faces left and right
    public static bool noMoon = false;
    public static bool noRabbitCompass = false;
    public static bool noBunnyAlerts = false;
    public static bool noFoodCompass = false;
    public static bool noHomeCompass = false;

    //Hardcore gameplay modifiers
    public static bool starvationMode = false;
    public static bool extremeThirst = false;
    public static bool dieInOneHit = false;
    public static bool noHealing = false;
    public static bool moreWolves = false;

    //Menu toggle
    public Toggle noHungerTog;
    public Toggle noThirstTog;
    public Toggle noFogTog;
    public Toggle noWolvesTog;
    public Toggle daytimeTog;
    public Toggle rabbitVisionTog;
    public Toggle noMoonTog;
    public Toggle noBunCompTog;
    public Toggle noBunAlertsTog;
    public Toggle noFoodCompTog;
    public Toggle noWaterCompTog;
    public Toggle noHomeCompTog;
    public Toggle infHealthTog;
    public Toggle infStaminaTog;

    public Toggle starveModeTog;
    public Toggle extremeThirstTog;
    public Toggle dieOneHitTog;
    public Toggle noHealingTog;
    public Toggle moreWolvesTog;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateDifficultyChanges()
    {
        noHunger = noHungerTog.isOn;
        noThirst = noThirstTog.isOn;
        noFog = noFogTog.isOn;
        noWolves = noWolvesTog.isOn;
        dayTime = daytimeTog.isOn;
        rabbitVision = rabbitVisionTog.isOn;
        noMoon = noMoonTog.isOn;
        noRabbitCompass = noBunCompTog.isOn;
        noBunnyAlerts = noBunAlertsTog.isOn;
        noFoodCompass = noFoodCompTog.isOn;
        noHomeCompass = noHomeCompTog.isOn;
        infiniteHealth = infHealthTog.isOn;
        infiniteStamina = infStaminaTog.isOn;
        starvationMode = starveModeTog.isOn;
        extremeThirst = extremeThirstTog.isOn;
        dieInOneHit = dieOneHitTog.isOn;
        noHealing = noHealingTog.isOn;
        moreWolves = moreWolvesTog.isOn;

        //Check for any opposite settings conflicting with each other
        if (infiniteHealth == true && dieInOneHit == true)
        {
            //Turn off infinite health
            infHealthTog.isOn = false;
            infiniteHealth = false;
        }
    }
}
