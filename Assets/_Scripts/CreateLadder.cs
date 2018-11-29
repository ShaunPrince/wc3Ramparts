using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateLadder : MonoBehaviour {

    GameObject ladder;
    // Use this for initialization
    void Start () {





    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateLadderCall()
    {
        ladder = new GameObject();
        ladder.gameObject.name = "Ladder";
        ladder.transform.SetParent(this.gameObject.transform);
        ladder.AddComponent<NavMeshLink>();
        ladder.GetComponent<NavMeshLink>().startPoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                                                                       this.gameObject.transform.position.z + 2f);
        ladder.GetComponent<NavMeshLink>().endPoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 5f,
                                                                       this.gameObject.transform.position.z + 4f);
        this.gameObject.transform.parent.GetComponentInParent<NavMeshSurface>().BuildNavMesh();
        ladder.GetComponent<NavMeshLink>().UpdateLink();
    }
}
