using UnityEngine;
using System.Collections;

public class LineOfSightScript : MonoBehaviour {

    public WolfAI wolfAI; //Leave blank if not a wolf
    public Transform npcTransform;

    public enum LosType { Patrolling, Chasing }; //Line of sight type
    public LosType losType;

    public LayerMask losLayerMask;
    public RaycastHit hit;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            if (wolfAI != null)
            {       
                if (Physics.Linecast(npcTransform.position, c.transform.position, out hit, losLayerMask))
                {
                    //If the object line of sight hits the player and not some other object
                    if (hit.transform.tag == "Player")
                    {
                        if (losType == LosType.Patrolling)
                        {
                            //Play the wolf sound if he saw us for the first time from patrolling mode
                            if (wolfAI.aiState == WolfAI.AIState.Patrolling)
                            {
                                wolfAI.wolfSFX.clip = wolfAI.sawPlayerSFX;
                                wolfAI.wolfSFX.Play();
                                wolfAI.chaseMusicScript.numOfEnemiesChasing += 1;
                            }

                            //Make the enemy chase the player. If the player is out of sight for 5 seconds, AI stops chasing
                            wolfAI.aiState = WolfAI.AIState.Chasing;
                            wolfAI.chaseTimer = 10;
                        }
                        else if (losType == LosType.Chasing)
                        {
                            if (wolfAI.aiState == WolfAI.AIState.Chasing)
                                wolfAI.chaseTimer = 10;
                        }
                    }
                }
            }
        }
    }
}
