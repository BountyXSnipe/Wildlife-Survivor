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
    void Start ()
    {
        //Each time the player loads up the menu, the difficulty settings are reset
        noHunger = false;
        noThirst = false;
        noFog = false;
        noWolves = false;
        dayTime = false;
        infiniteHealth = false;
        infiniteStamina = false;

        noMoon = false;
        noRabbitCompass = false;

        starvationMode = false;
        extremeThirst = false;
        dieInOneHit = false;
        noHealing = false;
        moreWolves = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Disable any toggle options that are opposite from the ones that are turned on. eg. "infinite health" vs "die in one hit"
        //Infinite health
        if (infHealthTog.isOn == true)
            dieOneHitTog.gameObject.SetActive(false);
        else if (dieOneHitTog.gameObject.activeSelf == false)
            dieOneHitTog.gameObject.SetActive(true);

        //No thirst
        if (noThirstTog.isOn == true)
            extremeThirstTog.gameObject.SetActive(false);
        else if (extremeThirstTog.gameObject.activeSelf == false)
            extremeThirstTog.gameObject.SetActive(true);

        //No hunger
        if (noHungerTog.isOn == true)
            starveModeTog.gameObject.SetActive(false);
        else if (starveModeTog.gameObject.activeSelf == false)
            starveModeTog.gameObject.SetActive(true);

        //No wolves
        if (noWolvesTog.isOn == true)
            moreWolvesTog.gameObject.SetActive(false);
        else if (moreWolvesTog.gameObject.activeSelf == false)
            moreWolvesTog.gameObject.SetActive(true);

        //Daytime
        if (daytimeTog.isOn == true)
            noMoonTog.gameObject.SetActive(false);
        else if (noMoonTog.gameObject.activeSelf == false)
            noMoonTog.gameObject.SetActive(true);

        //Hard mode options
        //Extreme thirst
        if (extremeThirstTog.isOn == true)
            noThirstTog.gameObject.SetActive(false);
        else if (noThirstTog.gameObject.activeSelf == false)
            noThirstTog.gameObject.SetActive(true);

        //Starvation mode
        if (starveModeTog.isOn == true)
            noHungerTog.gameObject.SetActive(false);
        else if (noHungerTog.gameObject.activeSelf == false)
            noHungerTog.gameObject.SetActive(true);

        //More wolves
        if (moreWolvesTog.isOn == true)
            noWolvesTog.gameObject.SetActive(false);
        else if (noWolvesTog.gameObject.activeSelf == false)
            noWolvesTog.gameObject.SetActive(true);

        //Die in one hit
        if (dieOneHitTog.isOn == true)
            infHealthTog.gameObject.SetActive(false);
        else if (infHealthTog.gameObject.activeSelf == false)
            infHealthTog.gameObject.SetActive(true);
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
