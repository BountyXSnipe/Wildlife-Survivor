using UnityEngine;
using System.Collections;

/// <summary>
/// This wolf AI assumes a single wolf moving around. They patrol through waypoints.
/// If the player gets caught within line of sight, they chase down the player.
/// If the player is sprinting, they can hear it if close enough. They can also hear the player if walking near them.
/// Landing makes the loudest sound, then sprinting, then walking.
/// Wolves will pursue the player in packs if close enough to the triggered wolf
/// </summary>

public class WolfAI : MonoBehaviour {

    public enum AIState { Patrolling, Alert, Chasing, Attacking };
    public AIState aiState;

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public Transform playerTransform;

    public float chaseTimer = 0;
    public float patrolSpeed = 3.5f;
    public float chaseSpeed = 16.1f;
    private float originChaseSpeed;
    public float attackSpeed = 30;
    public float attackTimer = 0;
    public float stamina = 100; //While the wolf is chasing, their stamina slowly drains down. When it reaches 0, they will move slower and will regenerate when not chasing
    public float staminaDrainRate = 5;
    public float staminaRecoveryRate = 15;

    public GameObject playerHurtHitbox;

    public AudioSource wolfSFX;
    public AudioClip alertSFX;
    public AudioClip sawPlayerSFX;
    public AudioClip attackingSFX;

    //public AudioSource chaseMusic;

    //This variable will be used to turn on/off the chase music if this wolf is chasing
    //Line of sight script will also communicate to this variable
    public ChaseMusicScript chaseMusicScript; 

    //Wolves get stuck if too far from their waypoint patrol, so we teleport them if they are idle for too long
    public float teleportTimer = 0;
    private Transform targetWaypoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        //Look for the chase music gameobject then get it's script component
        chaseMusicScript = GameObject.Find("Chase Music").GetComponent<ChaseMusicScript>() as ChaseMusicScript;

        originChaseSpeed = chaseSpeed;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
        
        //If they're switching waypoints too quickly, they've glitched out!
        //We need to teleport them back to their patrol spot
        if (teleportTimer >= 0)
        {
            //Teleport the wolf
            transform.position = agent.destination;
        }
        else
        {
            teleportTimer = 1;
        }
    }

    void Update()
    {

        //If the wolf is tired, lower their chase speed by half
        if (stamina <= 0)
        {
            chaseSpeed = originChaseSpeed * 0.5f;
        }
        else if (stamina > 0 && chaseSpeed != originChaseSpeed)
        {
            chaseSpeed = originChaseSpeed;
        }

        //=================
        //AI State Checking
        //=================
        #region
        //Patrolling
        if (aiState == AIState.Patrolling)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (agent.remainingDistance < 0.5f)
                GotoNextPoint();

            agent.speed = patrolSpeed;
            agent.angularSpeed = 600;
            //chaseMusic.volume = Mathf.Lerp(chaseMusic.volume, 0, 0.5f * Time.deltaTime);

            if (teleportTimer >= 0)
            {
                teleportTimer -= 30 * Time.deltaTime;
            }

            //Recover stamina only when patrolling
            if (stamina < 100)
            {
                stamina += 15 * Time.deltaTime;
            }
            else if (stamina > 100)
            {
                stamina = 100;
            }
        }
        else if (aiState == AIState.Alert)
        {
            //Start looking for the player through footstep sounds. Alert is triggered if they hear the player
        }
        else if (aiState == AIState.Chasing && attackTimer <= 0)
        {
            //If the player is out of sight for 5 seconds, AI stops chasing
            //Chase timer goes down until 0, then reset back to patrolling
            if (chaseTimer > 0)
            {
                chaseTimer -= 1 * Time.deltaTime;
            }
            else if (chaseTimer <= 0)
            {
                //stop chasing
                Debug.Log("Stopped chasing");
                chaseMusicScript.numOfEnemiesChasing -= 1;
                agent.SetDestination(points[destPoint].position);
                agent.speed = patrolSpeed;
                aiState = AIState.Patrolling;
            }

            if (stamina > 0)
            {
                stamina -= staminaDrainRate * Time.deltaTime;
            }
            else if (stamina < 0)
            {
                stamina = 0;
            }

            //Chase down the player
            agent.destination = playerTransform.position;

            //Run fast, slightly faster than the player sprint
            agent.speed = chaseSpeed;
            agent.angularSpeed = 600;

            //Play chase music fade in
            //chaseMusic.volume = Mathf.Lerp(chaseMusic.volume, 1, 1.5f * Time.deltaTime);
        }
        else if (aiState == AIState.Attacking || attackTimer > 0)
        {
            if (attackTimer > 0)
            {
                //ATTACK!
                playerHurtHitbox.SetActive(true);
                agent.speed = attackSpeed;
                //agent.angularSpeed = 10;
                attackTimer -= 1 * Time.deltaTime;

                //redundancy to keep the AI state in attacking since it switches to Chasing for some reason
                aiState = AIState.Attacking;
            }
            else
            {
                aiState = AIState.Chasing;
                playerHurtHitbox.SetActive(false);
                agent.angularSpeed = 600;
            }

            if (stamina > 0)
            {
                stamina -= staminaDrainRate * Time.deltaTime;
            }
            else if (stamina < 0)
            {
                stamina = 0;
            }
        }
        if (aiState != AIState.Attacking)
        {
            agent.angularSpeed = 600;
            playerHurtHitbox.SetActive(false);
        }
        #endregion

    }
}
