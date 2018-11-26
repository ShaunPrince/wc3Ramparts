using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionAction : MonoBehaviour
{
    //attack target
    public GameObject target;

    //timer between attacks
    public int attackTimer;
    public int timerCounter;

    //movement stuff
    public bool needsNewMoveTarget;
    private bool isInRange;

    //tag
    private string tagName;

	// Use this for initialization
	void Start ()
    {
        attackTimer = 100;
        timerCounter = 0;
        isInRange = false;
        tagName = gameObject.tag;
        needsNewMoveTarget = false;
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
        if (isValidTarget(other))
        {
            target = other.gameObject;
            needsNewMoveTarget = false;
        }
    }

    //helper method: determines if the object in the trigger radius is a valid target for the current game object
    private bool isValidTarget( Collider other )
    {
        if (!hasTarget() && other.gameObject.GetComponent<DamageableEntity>() != null)
        {
            if( tagName == "Enemy" && (other.CompareTag("Player") || other.CompareTag("Tower")) )
                return true;
            if ( tagName == "Player" && other.CompareTag("Enemy") )
                return true;
        }

        return false;
    }

    //public method that returns whether or not the gameobject currently has a target set
    public bool hasTarget()
    {
        if (target != null)
            return true;
        return false;
    }

    //public method that returns whether or not the gameobject is currently in range of an opposing unit
    public bool isWithinRange()
    {
        return isInRange;
    }

    //If an object is currently within the sphere trigger radius
    private void OnTriggerStay(Collider other)
    {
        //if this object has a target within range, attack it
        if (hasTarget() && target == other.gameObject)
        {
            if (attackTimer <= timerCounter)
            {
                int currentEnemyHP = target.GetComponent<DamageableEntity>().getHealth();
                target.GetComponent<DamageableEntity>().takeDamage(5);
                timerCounter = 0;

                //if target is dead
                if ( currentEnemyHP - 5 <= 0 )
                {
                    isInRange = false;
                    needsNewMoveTarget = true;
                }
                else
                {
                    isInRange = true;
                    needsNewMoveTarget = false;
                }
            }
            timerCounter++;
        }
    }
}




/*
 * Enemy Spawn:
 *      From KEEP, pick a random direction (360deg)
 *      Go out X meters along that vector
 *      Spawn 1 unit every Y seconds
 *      After 2 spawns, select new direction
 *      
 *      (also paint them red, and add arrows (little objects w/out physics that fly out))
 *      
 *      
 *      
 * Attacking:
 *  Enemy Unit walks towards KEEP. Attack KEEP once in range.
 *      -> if KEEP is in range, /only/ attack KEEP (regardless of if being attacked from other forces or not)
 *          
 *      -> if run into PLAYER UNITS/WALLS/TOWERS along the way, attack those until there is an available path to keep walking.
 * 
 * 
 * 
 * Current Status:
 *      Enemy units move towards keep but don't stop to attack when in range of a player unit :/
 * 
 * 
 */