using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitReceiveCommands : MonoBehaviour
{
    //
    public float moveSpeed = 1;
    //
    Vector3 destination;
    public void passiveTravelTo(Vector3 point)
    {
        destination = point;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Translate((destination - this.transform.position)*moveSpeed * Time.deltaTime);
	}
}
