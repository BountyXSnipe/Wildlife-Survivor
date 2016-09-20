using UnityEngine;
using System.Collections;

/// <summary>
/// For food purposes. The plant has health and will get destroyed once it reaches 0
/// </summary>

public class FoodPlantScript : MonoBehaviour {

    public int health = 5;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
