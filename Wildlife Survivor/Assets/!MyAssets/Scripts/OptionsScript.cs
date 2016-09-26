using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsScript : MonoBehaviour {

    private int currentQualitySettings;
    private string[] qualityLevelNames; //a list of quality level names to be converted into text

    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController playerController;

    //Text
    public Text mouseSensText;
    public Text qualitySettingText;
    public Text masterVolText;

	// Use this for initialization
	void Start ()
    {
        currentQualitySettings = QualitySettings.GetQualityLevel();
        qualityLevelNames = QualitySettings.names; //retrieve the list of quality names in an array

        //Set the quality setting text to the current quality level name
        qualitySettingText.text = qualityLevelNames[QualitySettings.GetQualityLevel()];

        //Get playerprefs and automatically configure settings to last set value
        //If playerprefs do not exist, automatically make one and default them

        //-------------------------
        //Mouse Sensitivity
        //-------------------------
        if (PlayerPrefs.HasKey("Mouse Sensitivity"))
        {
            //Set mouse sensitivity by retrieving the value from playerprefs
            playerController.mouseLook.XSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity");
            playerController.mouseLook.YSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity");

            //Set the text display to show the current sensitivity value
            mouseSensText.text = PlayerPrefs.GetFloat("Mouse Sensitivity").ToString();
        }
        else
        {
            PlayerPrefs.SetFloat("Mouse Sensitivity", 2);

            playerController.mouseLook.XSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity");
            playerController.mouseLook.YSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity");

            //Set the text display to show the current sensitivity value
            mouseSensText.text = PlayerPrefs.GetFloat("Mouse Sensitivity").ToString("F1"); //F1 rounds the float value to the nearest 10th when displayed as text
        }

        //-------------------------
        //Master Volume
        //-------------------------
        if (PlayerPrefs.HasKey("Master Volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Master Volume");
            masterVolText.text = PlayerPrefs.GetFloat("Master Volume").ToString("F1");
        }
        else
        {
            PlayerPrefs.SetFloat("Master Volume", 1);
            AudioListener.volume = PlayerPrefs.GetFloat("Master Volume");
            masterVolText.text = PlayerPrefs.GetFloat("Master Volume").ToString("F1");
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void ChangeMouseSensitivity(float sensChange)
    {
        //Get the playerpref value and assign it to a temp variable
        float mouseSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity");

        //Check to make sure the future sens change is greater than 0 and lower than 20 so that the sensitivity does not exceed a negative or very high value
        if (mouseSensitivity + sensChange > 0 && mouseSensitivity + sensChange < 20)
        {
            //Set the mouse sensitivity to the playerprefs then apply it to the player
            PlayerPrefs.SetFloat("Mouse Sensitivity", mouseSensitivity + sensChange);
            playerController.mouseLook.XSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity");
            playerController.mouseLook.YSensitivity = PlayerPrefs.GetFloat("Mouse Sensitivity");

            //Set the text display to show the current sensitivity value
            mouseSensText.text = PlayerPrefs.GetFloat("Mouse Sensitivity").ToString("F1");
        }        
    }

    public void ChangeMasterVolume(float volChange)
    {
        AudioListener.volume += volChange;

        //Clamp the values to prevent the audiolistener from getting negative volume or exceeding extremely loud volume
        if (AudioListener.volume < 0)
            AudioListener.volume = 0;
        else if (AudioListener.volume > 2)
            AudioListener.volume = 2;

        PlayerPrefs.SetFloat("Master Volume", AudioListener.volume);
        masterVolText.text = PlayerPrefs.GetFloat("Master Volume").ToString("F1");
    }

    public void ChangeMusicVolume(float volChange)
    {

    }

    public void ChangeSoundVolume(float volChange)
    {

    }

    public void ChangeQualitySettings(int qualityChange)
    {
        if (qualityChange > 0) //if a positive number, increase level
        {
            QualitySettings.IncreaseLevel();
            qualitySettingText.text = qualityLevelNames[QualitySettings.GetQualityLevel()];
        }
        else if (qualityChange < 0) //otherwise if negative number, decrease level
        {
            QualitySettings.DecreaseLevel();
            qualitySettingText.text = qualityLevelNames[QualitySettings.GetQualityLevel()];
        }
    }
}
