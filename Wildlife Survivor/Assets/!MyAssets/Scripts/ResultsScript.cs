using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResultsScript : MonoBehaviour {

    public Text bunniesSavedText;

	// Use this for initialization
	void Start ()
    {
        bunniesSavedText.text = "Bunnies Saved: " + PlayerStatus.bunniesSaved + "/6";
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.anyKeyDown && !Input.GetKey("e"))
        {
            SceneManager.LoadScene("TitleScreen");
            PlayerStatus.bunniesSaved = 0;
        }
	}
}
