using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

/// <summary>
/// While the shift key is held down, the player can sprint, at the cost
/// of using stamina and draining hunger and thirst faster
/// 
/// This script also controls the player footstep SFX
/// </summary>

public class SprintingScript : MonoBehaviour {

    public RigidbodyFirstPersonController fpsController;
    public PlayerStatus pStatus;
    public float stamina = 100;
    private float maxStamina = 100;
    public float sprintLoss = 15;
    public Slider stamBar;
    public float jumpLoss = 5;
    public float superJumpLoss = 15;
    public float standingRecovery = 25;
    public float walkingRecovery = 10;

    public AudioSource footStepAud;
    public AudioSource footStepAudSprint;
    public AudioClip walkingSFX;
    public AudioClip sprintingSFX;

    public bool tiredOut = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }

        if (stamina <= 0)
        {
            tiredOut = true;
        }

        if (stamina >= maxStamina && tiredOut == true)
        {
            tiredOut = false;
        }

        if (tiredOut == true)
        {
            fpsController.movementSettings.RunMultiplier = 1;
        }
        else
        {
            fpsController.movementSettings.RunMultiplier = 2;
        }

        stamBar.value = stamina;

        //Sprinting
        #region
        //If we're pressing the shift key to sprint
        if (Input.GetKey("left shift") && stamina > 0 && tiredOut == false)
        {
            //If any movement key is pressed
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                //Start running at the cost of using up stamina
                //if (pStatus.hunger < 100)
                pStatus.hunger -= (pStatus.hungerDrainRate * 4) * Time.deltaTime;
                pStatus.thirst -= (pStatus.thirstDrainRate * 2.5f) * Time.deltaTime;

                //Only drain stamina while running on the ground
                if (fpsController.Grounded == true)
                    stamina -= sprintLoss * Time.deltaTime;

                if (fpsController.Grounded == true)
                {
                    //Play footsteps
                    footStepAudSprint.volume = Mathf.Lerp(footStepAudSprint.volume, 1, 10f * Time.deltaTime);
                    //Fadeout footsteps
                    footStepAud.volume = Mathf.Lerp(footStepAud.volume, 0, 10f * Time.deltaTime);
                }
                else
                {
                    //Fadeout footsteps
                    footStepAud.volume = Mathf.Lerp(footStepAud.volume, 0, 10f * Time.deltaTime);
                    footStepAudSprint.volume = Mathf.Lerp(footStepAudSprint.volume, 0, 10f * Time.deltaTime);
                }
            }
        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //If we're pressing WASD
        {
            //Restore stamina if less than max and on the ground while moving
            if (stamina < maxStamina && fpsController.Grounded == true)
            {
                //Restore stamina
                stamina += walkingRecovery * Time.deltaTime;
            }

            //If we're on the ground
            if (fpsController.Grounded == true)
            {
                //Play footsteps
                //Play footsteps
                footStepAud.volume = Mathf.Lerp(footStepAud.volume, 0.5f, 10f * Time.deltaTime);
                //Fadeout footsteps
                footStepAudSprint.volume = Mathf.Lerp(footStepAudSprint.volume, 0, 10f * Time.deltaTime);
            }
            else
            {
                //Fadeout footsteps
                footStepAud.volume = Mathf.Lerp(footStepAud.volume, 0, 10f * Time.deltaTime);
                footStepAudSprint.volume = Mathf.Lerp(footStepAudSprint.volume, 0, 10f * Time.deltaTime);
            }
        }
        else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0) //If we're standing still and not pressing WASD
        {
            if (stamina < maxStamina && fpsController.Grounded == true)
            {
                //If standing still, restore stamina faster
                stamina += standingRecovery * Time.deltaTime;
            }

            //Fadeout footsteps
            footStepAud.volume = Mathf.Lerp(footStepAud.volume, 0, 10f * Time.deltaTime);
            footStepAudSprint.volume = Mathf.Lerp(footStepAud.volume, 0, 10f * Time.deltaTime);

        }
        #endregion

        //Jumping for loss of stamina
        if (fpsController.Grounded == true && Input.GetButtonDown("Jump") && Input.GetKey("c")) //Super Jump
        {            
            stamina -= superJumpLoss;
        }
        else if (fpsController.Grounded == true && Input.GetButtonDown("Jump")) //Jump
        {
            stamina -= jumpLoss;
        }
    }
}
