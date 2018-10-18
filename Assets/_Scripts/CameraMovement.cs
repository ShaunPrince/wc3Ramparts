using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float translationSpeed = 1;
    public float rotationSpeed = 1;

    private float horzTranslation;
    private float depthTranslation;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        horzTranslation = Input.GetAxisRaw("Horizontal") * translationSpeed;
        //depthTranslation = Input.GetAxisRaw("Vertical") * translationSpeed;

        Vector3 depthVector;
        depthVector = this.transform.TransformVector(Vector3.forward) * Input.GetAxisRaw("Vertical") * translationSpeed;

        this.transform.Translate(horzTranslation, 0, 0, Space.Self);
        this.transform.Translate(depthVector.x, 0, depthVector.z, Space.World);
		
	}
}
