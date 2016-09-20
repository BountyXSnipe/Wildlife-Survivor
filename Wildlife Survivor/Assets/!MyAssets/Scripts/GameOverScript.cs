using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Menu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
