using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject currentSelection;
    public Camera pov;
    public GameObject towerTemplate;

    private Ray povRay;
    RaycastHit MouseWorldPosHit;
    Vector3 MouseWorldPos;

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = true;
        pov = this.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        povRay = pov.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(povRay, out MouseWorldPosHit);
        MouseWorldPos = MouseWorldPosHit.point;
        Debug.Log(MouseWorldPos);

        //force mousepos to snap to 5x5 grid
        MouseWorldPos.x = Mathf.Round(MouseWorldPos.x / 5) * 5;
        MouseWorldPos.z = Mathf.Round(MouseWorldPos.z / 5) * 5;

        //Move Unit
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSelection = GameObject.Find("PlayerUnit");
        }
        //Spawn Tower
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject tower = GameObject.Instantiate(towerTemplate, GameObject.Find("Grid").transform);
            tower.transform.localPosition = MouseWorldPos;
            GameObject.Find("EnvironmentManager").GetComponent<EnvironmentManagerScript>().Rebake();
        }

		if(Input.GetMouseButtonDown(1) && currentSelection == GameObject.Find("PlayerUnit"))
        {

            FindObjectOfType<UnitReceiveCommands>().passiveTravelTo(MouseWorldPosHit.point);
        }


	}
}
