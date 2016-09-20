using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
using System.Collections;

/// <summary>
/// The player stands over the bed hitbox trigger then they hold down e
/// to sleep. This restores a bit of their health, and skips the daytime cycle a bit
/// The player loses some hunger and thirst after sleeping, but not as much if they didn't sleep and waited
/// the same time passing cycle
/// </summary>

public class LeafBedScript : MonoBehaviour {

    public CanvasGroup sleepingEffect;
    private bool aboutToSleep;
    public PlayerStatus pStatus;

    public CanvasGroup notEnoughFoodAndBunnies;
    public CanvasGroup notEnoughFood;
    public CanvasGroup notEnoughBunnies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (aboutToSleep == false)
        {
            sleepingEffect.alpha -= 0.3f * Time.deltaTime;
        }

        //Once the screen is fully black, sleep
        if (sleepingEffect.alpha >= 1)
        {
            //Sleep (Beat the game)
            SceneManager.LoadScene("Results");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

	}

    void OnTriggerStay()
    {
        if (Input.GetKey("e"))
        {
            if (aboutToSleep == false && PlayerStatus.bunniesSaved >= 2)
            {
                Debug.Log("Sleeping");
                aboutToSleep = true;
                sleepingEffect.alpha += 0.3f * Time.deltaTime;
            }
            else if (aboutToSleep == false && PlayerStatus.bunniesSaved < 2)
            {
                notEnoughBunnies.alpha = 1;
            }
            //else if (aboutToSleep == false && pStatus.hunger < 100 && PlayerStatus.bunniesSaved >= 2)
            //{
            //    notEnoughFood.alpha = 1;
            //}
            else
            {
                Debug.Log("Sleeping");
                aboutToSleep = true;
                sleepingEffect.alpha += 0.3f * Time.deltaTime;
            }
        }
        else
        {
            aboutToSleep = false;
        }
    }

    void OnTriggerExit()
    {
        aboutToSleep = false;
    }
}
