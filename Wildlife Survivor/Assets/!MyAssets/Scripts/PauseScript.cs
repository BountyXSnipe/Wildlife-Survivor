using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public GameObject pauseScreen;
    public GameObject optionsScreen;
    private bool paused = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            if (paused == false)
            {
                //Pause game
                PauseGame();
            }
            else
            {
                //Resume game
                ResumeGame();
            }
        }

    }

    void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);

        //Make cursor visisble and allow cursor movement so that the user can select buttons
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
        //Turn off UI windows
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);

        //Lock the cursor and make it invisisble
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowOptions()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void BackToPauseScreen()
    {
        pauseScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("TitleScreen");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }

}
