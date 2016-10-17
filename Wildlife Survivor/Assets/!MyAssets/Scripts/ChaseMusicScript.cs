using UnityEngine;
using System.Collections;

//Required components
[RequireComponent(typeof(AudioSource))]

public class ChaseMusicScript : MonoBehaviour {

    public int numOfEnemiesChasing = 0; //When this is greater than 1, the chase music wills start playing, if 0, music fades out
    public AudioSource chaseMusic;

    // Use this for initialization
    void Start ()
    {
        chaseMusic = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Check if any enemies are chasing, then fade in/out the chase music
        if (numOfEnemiesChasing <= 0)
            chaseMusic.volume = Mathf.Lerp(chaseMusic.volume, 0, 0.5f * Time.deltaTime);
        else if (numOfEnemiesChasing > 0)
            chaseMusic.volume = Mathf.Lerp(chaseMusic.volume, 1, 1.5f * Time.deltaTime);
    }
}
