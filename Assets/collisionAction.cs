using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionAction : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // If an object enters the sphere collider radius
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("New collision with " + collision.gameObject);
    }

    // If an object is currently within the sphere collider radius
    // Doesn't do anything if the object of collision is the floor or a plane
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetType() != Plane && collision.gameObject.GetType() != )
        {
            Debug.Log("Ongoing collision with " + collision.gameObject);
        }
    }
}
