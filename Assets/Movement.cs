using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // The target marker.
    public Transform target;


    // Use this for initialization
    void Start()
    {
        assignTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        if (!gameObject.GetComponent<collisionAction>().isWithinRange())
        {
            if( target != null && !gameObject.GetComponent<collisionAction>().needsNewMoveTarget )
            {
                Vector3 moveTo = new Vector3(target.position.x, 0, target.position.z);
                this.gameObject.GetComponentInChildren<UnitReceiveCommands>().passiveMoveTo(moveTo);
            }
            else
            {
                assignTarget();
            }
        }
    }

    void assignTarget()
    {
        target = GameObject.FindWithTag("Enemy").transform;
    }
}