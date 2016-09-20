using UnityEngine;
using System.Collections;

public class HazardScript : MonoBehaviour {

    public float damage = 80;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player" || c.tag == "PlayerStealth")
        {
            PlayerStatus pStatus = c.GetComponent<PlayerStatus>();
            if (pStatus.hurtTimer <= 0)
            {
                pStatus.health -= damage;
                pStatus.hitScreen.alpha = 1;
                if (pStatus.hurtSFX.isPlaying == false)
                    pStatus.hurtSFX.Play();
                pStatus.hurtTimer = 1;
            }
        }
    }
}
