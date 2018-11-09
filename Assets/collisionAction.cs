using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionAction : MonoBehaviour
{

    public GameObject target;
    public int attackTimer;
    public int timerCounter;

	// Use this for initialization
	void Start ()
    {
        attackTimer = 100;
        timerCounter = 0;
	}
	
	// Update is called once per frame
	void Update()
    {
        
    }

    // If an object collides with this game object
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Player") || collision.collider.CompareTag("Tower") || collision.collider.CompareTag("Plane") )
        {
            Debug.Log("Object " + gameObject.name + " has new collision with " + collision.gameObject);
        }
    }

    //If an object enters the sphere trigger radius
    private void OnTriggerEnter(Collider other)
    {
        //if curretnly has no target, sets new target to the object
        if (target == null && (other.CompareTag("Player") || other.CompareTag("Tower") || other.CompareTag("Enemy")) && other.gameObject.GetComponent<DamageableEntity>() != null)
        {
            target = other.gameObject;
            Debug.Log("Target Acquired: " + gameObject.name);
        }
    }

    //If an object is currently within the sphere trigger radius
    private void OnTriggerStay(Collider other)
    {
        //if this object has a target within range, attack it
        if (target != null && target == other.gameObject)
        {
            if (attackTimer <= timerCounter)
            {
                target.GetComponent<DamageableEntity>().takeDamage(5);
                //attackTimer += 20;
                timerCounter = 0;
            }
            timerCounter++;
        }
    }
}
