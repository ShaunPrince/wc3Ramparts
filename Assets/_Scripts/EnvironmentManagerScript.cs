using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnvironmentManagerScript : MonoBehaviour
{
    public List<NavMeshSurface> surfaces;

	// Use this for initialization
	void Start ()
    {
		for (int i = 0; i < this.gameObject.transform.childCount; ++i)
        {
            surfaces.Add(this.gameObject.transform.GetChild(i).gameObject.GetComponent<NavMeshSurface>());
        }

        Rebake();
        //for (int i = 0; i < surfaces.Count; ++i)
        //{
        //    surfaces[i].BuildNavMesh();
        //}
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Rebake()
    {
        for (int i = 0; i < surfaces.Count; ++i)
        {
            surfaces[i].BuildNavMesh();
            try
            {
                surfaces[i].gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<NavMeshLink>().UpdateLink();
                    //.transform.GetChild(0).gameObject.GetComponentInChildren<NavMeshLink>().UpdateLink();
            }
            catch(System.NullReferenceException e)
            {
                Debug.Log(e.ToString());
                
            }
        }
    }
}
