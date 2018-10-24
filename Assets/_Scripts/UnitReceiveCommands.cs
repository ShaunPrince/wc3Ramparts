using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitReceiveCommands : MonoBehaviour
{
    //
    public float moveSpeed = 1;
    //
    Vector3 destination;
    public void passiveTravelTo(Vector3 point)
    {
        destination = point;
        this.gameObject.GetComponentInChildren<NavMeshAgent>().destination = destination;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
}
