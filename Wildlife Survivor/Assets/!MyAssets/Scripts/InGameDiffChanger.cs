using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InGameDiffChanger : MonoBehaviour {

    //Player variables
    public PlayerStatus pStatus;
    public SprintingScript pSprint;
    public Light playerLight; //Light source like a flashlight to help the player see in the dark
    public GameObject bunnyVision;
    public Camera playerCam;

    //Compass Variables
    public GameObject bunnyCompass;

    //Environment variables
    public SpriteRenderer moon;
    public Material daySkybox;
    public Material nightSkybox;
    public Light directionalLight; //the sun light
	public Color daySkyAmbColor;
	public Color dayEquatorAmbColor;
	public Color dayGroundAmbColor;
    public Color dayFogColor;

    //Enemy variables
    public GameObject[] wolves;
    public GameObject[] extraWolves;

    //Other variables
    public AudioSource music;
    

	// Use this for initialization
	void Start ()
    {
        //=====
        //Defaulting
        //=====
        //Default the scene settings then make changes based on custom difficulty settings
        RenderSettings.skybox = nightSkybox;
        RenderSettings.fog = true;
        directionalLight.intensity = 0.1f;
        //Extra wolves start off disabled
        for (int i = 0; i < extraWolves.Length; ++i)
        {
            extraWolves[i].SetActive(false);
        }

        //========
        //Difficulty changing/modifying
        //========
        //Check first if the player is in a premade difficulty mode before
        //doing custom changes
        if (DifficultyModifier.difficulty == "easy")
        {
            RenderSettings.fog = false;
            bunnyCompass.SetActive(true);
            pStatus.thirstDrainRate = 0;
            pStatus.thirst = 100;
            pStatus.hungerDrainRate = 0;
            pStatus.hunger = 100;
        }
        else if (DifficultyModifier.difficulty == "medium")
        {
            RenderSettings.fog = false;
        }
        else if (DifficultyModifier.difficulty == "hard")
        {
            moon.enabled = false;
            bunnyCompass.SetActive(false);
            for (int i = 0; i < extraWolves.Length; ++i)
            {
                extraWolves[i].SetActive(true);
            }
        }
        //Otherwise, if the difficulty string doesn't match either of them, use custom difficulty settings

        //Upon scene load, the game changes take place based
        //on what the user set in the custom difficulty options
        //===================================================
        //Environment Settings
        //===================================================
        if (DifficultyModifier.dayTime == true)
        {
            RenderSettings.skybox = daySkybox;
            moon.enabled = false;
            directionalLight.intensity = 0.5f;

            //Change the ambient lighting to fit day time with 3 colors
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
            RenderSettings.ambientSkyColor = daySkyAmbColor;
            RenderSettings.ambientEquatorColor = dayEquatorAmbColor;
            RenderSettings.ambientGroundColor = dayGroundAmbColor;
            RenderSettings.fogColor = dayFogColor;

            //Turn off scary music
            music.enabled = false;

            //Disable player "flashlight" during daytime
            playerLight.enabled = false;
        }
        if (DifficultyModifier.noFog == true)
        {
            RenderSettings.fog = false;
        }
        if (DifficultyModifier.noMoon == true)
        {
            moon.enabled = false;
        }

        //===================================================
        //Player Settings
        //===================================================
        if (DifficultyModifier.noHunger == true)
        {
            pStatus.hungerDrainRate = 0;
            pStatus.hunger = 100;
        }
        if (DifficultyModifier.noThirst == true)
        {
            pStatus.thirstDrainRate = 0;
            pStatus.thirst = 100;
        }
        if (DifficultyModifier.infiniteHealth == true)
        {
            pStatus.infiniteHealth = true;
        }
        if (DifficultyModifier.infiniteStamina == true)
        {
            pSprint.sprintLoss = 0;
            pSprint.jumpLoss = 0;
            pSprint.sprintJumpLoss = 0;
            pSprint.superJumpLoss = 0;
        }
        if (DifficultyModifier.rabbitVision == true) //not finished yet
        {
            playerCam.enabled = false;
            bunnyVision.SetActive(true);
        }
        if (DifficultyModifier.extremeThirst == true)
        {
            pStatus.thirstDrainRate = 0.5f;
        }
        if (DifficultyModifier.starvationMode == true)
        {
            pStatus.hungerDrainRate = 0.3f;
        }
        if (DifficultyModifier.dieInOneHit == true)
        {
            pStatus.maxHealth = 1;
            pStatus.health = 1;
            pStatus.hpBar.maxValue = 1;
        }

        //===================================================
        //Compass Settings
        //===================================================
        if (DifficultyModifier.noRabbitCompass == true)
        {
            bunnyCompass.SetActive(false);
        }

        //===================================================
        //Enemy Settings
        //===================================================
        if (DifficultyModifier.noWolves == true) //Disable Wolves
        {
            for (int i = 0; i < wolves.Length; ++i)
            {
                wolves[i].SetActive(false);
            }
        }
        else if (DifficultyModifier.moreWolves == true) //otherwise if extra wolves are enabled
        {
            for (int i = 0; i < extraWolves.Length; ++i)
            {
                extraWolves[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
