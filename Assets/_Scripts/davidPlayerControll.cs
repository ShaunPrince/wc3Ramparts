using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class davidPlayerControll : MonoBehaviour
{
    public GameObject currentSelection;
    public Camera pov;
    public GameObject towerTemplate;
    public GameObject Wall;
    private GameObject CurrentObject;


    private Ray povRay;
    RaycastHit MouseWorldPosHit;
    Vector3 MouseWorldPos;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        pov = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        povRay = pov.ScreenPointToRay(Input.mousePosition);
        RaycastHit MouseWorldPosHit;
        if(Physics.Raycast(povRay, out MouseWorldPosHit))
        {
            MouseWorldPos = MouseWorldPosHit.point;
        }
        
        Debug.Log(MouseWorldPos);

        //force mousepos to snap to 5x5 grid
        MouseWorldPos.x = Mathf.Round(MouseWorldPos.x / 5) * 5;
        MouseWorldPos.z = Mathf.Round(MouseWorldPos.z / 5) * 5;
        Vector3 horizontalPosition = new Vector3(MouseWorldPos.x, 0, MouseWorldPos.z);
        //Move Unit
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSelection = GameObject.Find("PlayerUnit");
        }
        //Spawn Tower
        else if (Input.GetKeyDown(KeyCode.Alpha2))

        {

            if (CurrentObject == null)
            {
                CurrentObject = Instantiate(towerTemplate);

            }
            
            /*
            GameObject tower = GameObject.Instantiate(towerTemplate);

            tower.transform.localPosition = MouseWorldPos;
            GameObject.Find("EnvironmentManager").GetComponent<EnvironmentManagerScript>().Rebake();
            */
        }
        if (CurrentObject != null)
        {
            if(Physics.Raycast(povRay, out MouseWorldPosHit))
            {
                CurrentObject.transform.position = horizontalPosition;
            }
            
        }

        if (Input.GetMouseButtonDown(0))
        {

            CurrentObject = null;
        }

        if (Input.GetMouseButtonDown(1) && currentSelection == GameObject.Find("PlayerUnit"))
        {

            FindObjectOfType<UnitReceiveCommands>().passiveMoveTo(MouseWorldPosHit.point);
        }


    }
}
