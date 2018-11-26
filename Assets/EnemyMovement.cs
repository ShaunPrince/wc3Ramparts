using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    
    // The target marker.
    public Transform target;

    //keeps track of if the object is currently targetting the keep
    private bool keep;
    

    // Use this for initialization
    void Start()
    {
        assignTargetKeep();
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        if (!gameObject.GetComponent<collisionAction>().isWithinRange())
        {
            //if object has a move target, move towards it
            if( target != null && !gameObject.GetComponent<collisionAction>().needsNewMoveTarget )
            {
                Vector3 moveTo = new Vector3(target.position.x, 0, target.position.z);
                this.gameObject.GetComponentInChildren<UnitReceiveCommands>().passiveMoveTo(moveTo);
            }
            //if object is in fighting range of a player unit, move towards it 
            else if(checkForAttack())
            {
                targetUnit();
            }
            //if object is not in fighting range of a player unit, target keep
            else
            {
                assignTargetKeep();
            }
        }
    }

    //checks if the object has an opposing player unit in range
    bool checkForAttack()
    {
        if (gameObject.GetComponent<collisionAction>().hasTarget())
            return true;
        return false;
    }

    //targets player unit in range
    void targetUnit()
    {
        target = gameObject.GetComponent<collisionAction>().target.transform;
        keep = false;
    }

    //targets keep
    void assignTargetKeep()
    {
        target = GameObject.FindWithTag("Keep").transform;
        keep = true;
    }
}

