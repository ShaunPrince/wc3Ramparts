using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float translationSpeed = 1;
    public float rotationSpeed = 1;


    public float cameraSpeed = 20;
    public float borderThickness = 100;
    public Vector2 movingLimit ;
    public float minHeight = 10f;
    public float maxHeight = 100f;
    public float rotateSpeed;
    public float rotatingAmout;

    private Quaternion rotation;



    private float horzTranslation;
    private float depthTranslation;
    

	// Use this for initialization
	void Start ()
    {
        rotation = Camera.main.transform.rotation;

	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = transform.position;
        horzTranslation = Input.GetAxisRaw("Horizontal") * translationSpeed;
        //depthTranslation = Input.GetAxisRaw("Vertical") * translationSpeed;

        //moving the camera by mouse
        if (Input.mousePosition.y >= Screen.height-borderThickness)
            {
                pos.z += cameraSpeed* Time.deltaTime;

            }
        if (Input.mousePosition.y <=  borderThickness)
        {
            pos.z -= cameraSpeed * Time.deltaTime;

        }
        if (Input.mousePosition.x >= Screen.width - borderThickness)
        {
            pos.x += cameraSpeed * Time.deltaTime;

        }
        if (Input.mousePosition.x <= borderThickness)
        {
            pos.x -= cameraSpeed * Time.deltaTime;

        }
        pos.y -= Input.GetAxis("Mouse ScrollWheel") * cameraSpeed;
        pos.y = Mathf.Clamp(pos.y, minHeight, maxHeight);
        pos.x = Mathf.Clamp(pos.x, -movingLimit.x, movingLimit.x);
        pos.z = Mathf.Clamp(pos.z, -movingLimit.y, movingLimit.y);

        transform.position = pos;

        // Rotating the camera
        /*
        Vector3 origin = Camera.main.transform.eulerAngles;
        Vector3 destination = origin;
        if(Input.GetMouseButton(2))
        {
            destination.x -= Input.GetAxis("Mouse Y") * rotatingAmout;

            destination.y += Input.GetAxis("Mouse X") * rotatingAmout;
       

        }

        if(destination!= origin)
        {
            Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * rotateSpeed);


        }

        */



        Vector3 depthVector;
        depthVector = this.transform.TransformVector(Vector3.forward) * Input.GetAxisRaw("Vertical") * translationSpeed;

        this.transform.Translate(horzTranslation, 0, 0, Space.Self);
        this.transform.Translate(depthVector.x, 0, depthVector.z, Space.World);
		
	}
}
