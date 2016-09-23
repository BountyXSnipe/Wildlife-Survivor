using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScreenManager : MonoBehaviour {

    public CanvasGroup introText;
    public CanvasGroup eatText;
    public CanvasGroup easterEggText;
    public CanvasGroup drinkText;
    public CanvasGroup bunniesSavedText;
    public CanvasGroup notEnoughFoodAndBunnes;
    public CanvasGroup notEnoughBunnies;
    public CanvasGroup notEnoughFood;
    public CanvasGroup hungerFullText;

    private bool startFading;
    public float fadeOutSpeed = 1;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("WaitBeforeFading");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (startFading == true)
        {
            introText.alpha -= 0.5f * Time.deltaTime;
        }
        eatText.alpha -= 1f * Time.deltaTime;
        easterEggText.alpha -= 1f * Time.deltaTime;
        drinkText.alpha -= 1 * Time.deltaTime;
        bunniesSavedText.alpha -= 0.5f * Time.deltaTime;
        notEnoughBunnies.alpha -= 0.5f * Time.deltaTime;
        notEnoughFood.alpha -= 0.5f * Time.deltaTime;
        notEnoughFoodAndBunnes.alpha -= 0.5f * Time.deltaTime;
        hungerFullText.alpha -= 0.1f * Time.deltaTime;
	}

    IEnumerator WaitBeforeFading()
    {
        yield return new WaitForSeconds(12);
        startFading = true;
    }
}
