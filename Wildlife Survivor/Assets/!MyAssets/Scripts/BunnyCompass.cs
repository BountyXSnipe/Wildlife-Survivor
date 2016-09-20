using UnityEngine;
using System.Collections;

public class BunnyCompass : MonoBehaviour {

    public Transform[] bunnyLocations; //Carries the locaction of each bunny in a set array
    public Transform homeLocation; //points towards the bed after saving all bunnies
    private int numOfBunnies;
    private int arrayCounter = 0; //starts at 0, then goes up for each bunny saved until it reaches the max num of bunnies saved
    private Transform compassTarget; //The position the compass will be pointing towards

	// Use this for initialization
	void Start () {
        numOfBunnies = bunnyLocations.Length; //subtract by 1 because the bunnLocations.Length gets the actual number of objects in the array as opposed to the literal array size (eg. there are 6 bunnies, but the array counts from 0 and not 1)
        if (bunnyLocations[0] != null)
            compassTarget = bunnyLocations[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (arrayCounter < numOfBunnies)
        {
            if (bunnyLocations[arrayCounter] == null)
            {
                arrayCounter++;
                if (arrayCounter < numOfBunnies)
                {
                    
                    compassTarget = bunnyLocations[arrayCounter];
                }
                else
                    compassTarget = homeLocation;
            }
        }
        else
        {
            compassTarget = homeLocation;
        }

        if (compassTarget != null)
        {
            Vector3 targetDir = compassTarget.position - transform.position;
            float step = 15 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            //Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
        }

	}
}
