using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public CanvasGroup titleScreen;
    public CanvasGroup controlsScreen;
    public CanvasGroup creditsScreen;
    public CanvasGroup diffScreen;
    public CanvasGroup customDiffScreen;
    public CanvasGroup singleMultiplayerScreen;

    private GraphicRaycaster titleRay;
    private GraphicRaycaster controlRay;
    private GraphicRaycaster creditsRay;
    private GraphicRaycaster diffRay;
    private GraphicRaycaster customDiffRay;
    private GraphicRaycaster singleMultiRay;

    public enum ScreenState { Title, Controls, Credits, Difficulty, CustomDifficulty, SingleOrMultiplayer };
    public ScreenState screenState;

    public float fadeSpeed = 5;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        titleRay = titleScreen.GetComponent<GraphicRaycaster>();
        controlRay = controlsScreen.GetComponent<GraphicRaycaster>();
        creditsRay = creditsScreen.GetComponent<GraphicRaycaster>();
        diffRay = diffScreen.GetComponent<GraphicRaycaster>();
        customDiffRay = customDiffScreen.GetComponent<GraphicRaycaster>();
        singleMultiRay = singleMultiplayerScreen.GetComponent<GraphicRaycaster>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (screenState == ScreenState.Title)
        {
            titleScreen.alpha = Mathf.Lerp(titleScreen.alpha, 1, fadeSpeed * Time.deltaTime);
            controlsScreen.alpha = Mathf.Lerp(controlsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            creditsScreen.alpha = Mathf.Lerp(creditsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            diffScreen.alpha = Mathf.Lerp(diffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            customDiffScreen.alpha = Mathf.Lerp(customDiffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            singleMultiplayerScreen.alpha = Mathf.Lerp(singleMultiplayerScreen.alpha, 0, fadeSpeed * Time.deltaTime);
        }
        else if (screenState == ScreenState.Controls)
        {
            titleScreen.alpha = Mathf.Lerp(titleScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            controlsScreen.alpha = Mathf.Lerp(controlsScreen.alpha, 1, fadeSpeed * Time.deltaTime);
            creditsScreen.alpha = Mathf.Lerp(creditsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            diffScreen.alpha = Mathf.Lerp(diffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            customDiffScreen.alpha = Mathf.Lerp(customDiffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            singleMultiplayerScreen.alpha = Mathf.Lerp(singleMultiplayerScreen.alpha, 0, fadeSpeed * Time.deltaTime);
        }
        else if (screenState == ScreenState.Credits)
        {
            titleScreen.alpha = Mathf.Lerp(titleScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            controlsScreen.alpha = Mathf.Lerp(controlsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            creditsScreen.alpha = Mathf.Lerp(creditsScreen.alpha, 1, fadeSpeed * Time.deltaTime);
            diffScreen.alpha = Mathf.Lerp(diffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            customDiffScreen.alpha = Mathf.Lerp(customDiffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            singleMultiplayerScreen.alpha = Mathf.Lerp(singleMultiplayerScreen.alpha, 0, fadeSpeed * Time.deltaTime);
        }
        else if (screenState == ScreenState.Difficulty)
        {
            titleScreen.alpha = Mathf.Lerp(titleScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            controlsScreen.alpha = Mathf.Lerp(controlsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            creditsScreen.alpha = Mathf.Lerp(creditsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            diffScreen.alpha = Mathf.Lerp(diffScreen.alpha, 1, fadeSpeed * Time.deltaTime);
            customDiffScreen.alpha = Mathf.Lerp(customDiffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            singleMultiplayerScreen.alpha = Mathf.Lerp(singleMultiplayerScreen.alpha, 0, fadeSpeed * Time.deltaTime);
        }
        else if (screenState == ScreenState.CustomDifficulty)
        {
            titleScreen.alpha = Mathf.Lerp(titleScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            controlsScreen.alpha = Mathf.Lerp(controlsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            creditsScreen.alpha = Mathf.Lerp(creditsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            diffScreen.alpha = Mathf.Lerp(diffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            customDiffScreen.alpha = Mathf.Lerp(customDiffScreen.alpha, 1, fadeSpeed * Time.deltaTime);
            singleMultiplayerScreen.alpha = Mathf.Lerp(singleMultiplayerScreen.alpha, 0, fadeSpeed * Time.deltaTime);
        }
        else if (screenState == ScreenState.SingleOrMultiplayer)
        {
            titleScreen.alpha = Mathf.Lerp(titleScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            controlsScreen.alpha = Mathf.Lerp(controlsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            creditsScreen.alpha = Mathf.Lerp(creditsScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            diffScreen.alpha = Mathf.Lerp(diffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            customDiffScreen.alpha = Mathf.Lerp(customDiffScreen.alpha, 0, fadeSpeed * Time.deltaTime);
            singleMultiplayerScreen.alpha = Mathf.Lerp(singleMultiplayerScreen.alpha, 1, fadeSpeed * Time.deltaTime);
        }

        if (titleScreen.alpha > 0.5f)
            titleRay.enabled = true;
        else 
            titleRay.enabled = false;

        if (controlsScreen.alpha > 0.5f)
            controlRay.enabled = true;
        else
            controlRay.enabled = false;

        if (creditsScreen.alpha > 0.5f)
            creditsRay.enabled = true;
        else
            creditsRay.enabled = false;

        if (diffScreen.alpha > 0.5f)
            diffRay.enabled = true;
        else
            diffRay.enabled = false;

        if (customDiffScreen.alpha > 0.5f)
            customDiffRay.enabled = true;
        else
            customDiffRay.enabled = false;

        if (singleMultiplayerScreen.alpha > 0.5f)
            singleMultiRay.enabled = true;
        else
            singleMultiRay.enabled = false;
    }

    public void PlayGame(string _difficulty)
    {
        //Set the difficulty based on the selected setting.M
        DifficultyModifier.difficulty = _difficulty;
        SceneManager.LoadScene("Main Level");
        PlayerStatus.bunniesSaved = 0;
    }

    public void PlayMultiplayer(string _difficulty)
    {
        //Set the difficulty based on the selected setting.M
        DifficultyModifier.difficulty = _difficulty;
        SceneManager.LoadScene("Main Level Multiplayer");
        PlayerStatus.bunniesSaved = 0;
    }

    public void ChangeToDifficulty()
    {
        screenState = ScreenState.Difficulty;
    }

    public void ChangeToCustomDifficulty()
    {
        screenState = ScreenState.CustomDifficulty;
    }

    public void ChangeToTitle()
    {
        screenState = ScreenState.Title;
    }

    public void ChangeToControls()
    {
        screenState = ScreenState.Controls;
        Debug.Log("controls");
    }

    public void ChangeToCredits()
    {
        screenState = ScreenState.Credits;
    }

    public void ChangeToSingleMultiplayer()
    {
        screenState = ScreenState.SingleOrMultiplayer;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
