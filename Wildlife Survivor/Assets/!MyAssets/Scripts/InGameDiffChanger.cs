using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InGameDiffChanger : MonoBehaviour {

    //Player variables
    public PlayerStatus pStatus;
    public SprintingScript pSprint;
    public Light playerLight; //Light source like a flashlight to help the player see in the dark

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

    //Enemy variables
    public GameObject[] wolves;
    public GameObject[] extraWolves;

    //Other variables
    public AudioSource music;
    

	// Use this for initialization
	void Start ()
    {
        //Default the scene settings then make changes based on custom difficulty settings
        RenderSettings.skybox = nightSkybox;
        RenderSettings.fog = true;
        directionalLight.intensity = 0.1f;

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
            pSprint.superJumpLoss = 0;
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
    }

    // Update is called once per frame
    void Update () {
	
	}
}
