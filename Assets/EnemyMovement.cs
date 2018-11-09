using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    // The target marker.
    public Transform target;
    

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        Vector3 moveTo = new Vector3(target.position.x, 0, target.position.z);
        this.gameObject.GetComponentInChildren<UnitReceiveCommands>().passiveMoveTo(moveTo);
        Debug.Log(this.transform.rotation);
        Debug.Log("Target Position: " + moveTo);
    }
}
