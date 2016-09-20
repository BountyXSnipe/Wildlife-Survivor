using UnityEngine;
using System.Collections;

public class BushScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            //change the player tag to stealth player
            c.tag = "PlayerStealth";
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "PlayerStealth")
        {
            //Change the player back to normal
            c.tag = "Player";
        }
    }
}
