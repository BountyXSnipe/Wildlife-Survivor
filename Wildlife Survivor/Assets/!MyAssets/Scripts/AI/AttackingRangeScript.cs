using UnityEngine;
using System.Collections;

public class AttackingRangeScript : MonoBehaviour {

    public WolfAI wolfAI;

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
            if (wolfAI.aiState == WolfAI.AIState.Chasing)
            {
                wolfAI.attackTimer = 3;
                wolfAI.aiState = WolfAI.AIState.Attacking;
                wolfAI.wolfSFX.clip = wolfAI.attackingSFX;
                wolfAI.wolfSFX.Play();
            }
        }
    }

    
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player" || c.tag == "PlayerStealth")
        {
            if (wolfAI.aiState == WolfAI.AIState.Attacking && wolfAI.attackTimer <= 0)
            {
                Debug.Log("Out of Range");
                wolfAI.aiState = WolfAI.AIState.Chasing;
            }
        }
    }
}
