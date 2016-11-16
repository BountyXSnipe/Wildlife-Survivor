using UnityEngine;
using System.Collections;

/// <summary>
/// For food purposes. The plant has health and will get destroyed once it reaches 0
/// </summary>

public class FoodPlantScript : MonoBehaviour {

    public int health = 5;
    public bool eaten = false; //when eaten, the food disappears and waits to respawn
    public MeshRenderer foodMesh;
    public Collider foodHitbox;
    public float foodRespawnTime = 30; //measured in seconds

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (health <= 0 && eaten == false)
        {
            eaten = true;
            foodMesh.enabled = false;
            foodHitbox.enabled = false;
            StartCoroutine("FoodRespawn", foodRespawnTime);
        }
	}

    IEnumerator FoodRespawn(float _respawnTime)
    {
        yield return new WaitForSeconds(_respawnTime);
        eaten = false;
        foodMesh.enabled = true;
        foodHitbox.enabled = true;
        health = 5;
    }
}
