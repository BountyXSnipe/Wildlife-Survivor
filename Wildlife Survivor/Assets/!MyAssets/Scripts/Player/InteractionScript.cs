using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// This script fires a raycast forward. If the object is intereactable, by pressing E
/// We either eat it, drink it, or intereact with it
/// </summary>

public class InteractionScript : MonoBehaviour {

    RaycastHit hit;
    public PlayerStatus pStatus; //For hunger and thirst

    private AudioSource audSource;
    public AudioClip eatSound;
    public AudioClip drinkSound;

    public CanvasGroup instructionsTextEat;
    public CanvasGroup instructionsTextDrink;
    public CanvasGroup easterEggText;
    public CanvasGroup bunniesSavedCanvas;
    public Text bunniesSavedText;

    public float drinkRate = 1;
    public float rateTimer = 0;

	// Use this for initialization
	void Start ()
    {
        audSource = GetComponent<AudioSource>() as AudioSource;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.DrawRay(transform.position, transform.forward, Color.yellow);

        //Passively reduce rateTimer
        if (rateTimer > 0)
        {
            rateTimer -= 1 * Time.deltaTime;
        }

        //If an object is in front of us
	    if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            //While holding down e, the player will progressively eat or drink by a set "rate of fire" of 1 per second
            if (Input.GetKey("e"))
            {
                if (rateTimer <= 0)
                {
                    //Check what object is scanned
                    if (hit.transform.tag == "Food" || hit.transform.tag == "Tutorial Food")
                    {
                        pStatus.hunger += 2.5f;
                        pStatus.health += 1;
                        //Reduce the "health" of the food until it's gone
                        hit.transform.gameObject.GetComponent<FoodPlantScript>().health -= 1;
                        //Play eating sound
                        audSource.clip = eatSound;
                        audSource.Play();
                        rateTimer = 0.5f;
                    }
                    else if (hit.transform.tag == "Water" || hit.transform.tag == "Tutorial Water")
                    {
                        if (pStatus.thirst < 97)
                        {
                            pStatus.thirst += 3;
                            //Play drinking sound
                            audSource.clip = drinkSound;
                            audSource.Play();
                            rateTimer = 0.25f;
                        }
                    }
                    else if (hit.transform.tag == "Bunny")
                    {
                        PlayerStatus.bunniesSaved += 1;
                        bunniesSavedCanvas.alpha = 1;
                        bunniesSavedText.text = "Bunnies Saved: " + PlayerStatus.bunniesSaved + "/6";
                        Destroy(hit.transform.gameObject);

                    }
                }
            } //end if get key e

            if (hit.transform.tag == "Tutorial Food")
            {
                instructionsTextEat.alpha = 1;
            }

            if (hit.transform.tag == "Tutorial Water")
            {
                instructionsTextDrink.alpha = 1;
            }

            if (hit.transform.tag == "Idea Fairy")
            {
                easterEggText.alpha = 1;
            }
        }
	}
}
