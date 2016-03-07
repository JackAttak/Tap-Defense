using UnityEngine;
using System.Collections;

public class BuildingZone : Global
{

    public GameObject Global;
    public GameObject built;
    public Material mouseOver;
    public Material regular;

    //buildings
    public bool arching;
    public bool colleging;
    public bool barracking;

    private bool allFalse;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (arching || colleging || barracking)
        {
        }
        else
        {
            allFalse = true;
        }
	}

    private void OnMouseOver()
    {
        if(Global.GetComponent<Global>().building == false)
        {
            GetComponent<Renderer>().sharedMaterial = mouseOver;

            if (Input.GetButtonDown("Fire1"))
            {
                if (allFalse == true)
                {
                    Global.GetComponent<Global>().building = true;
                    Global.GetComponent<Global>().selected = this.gameObject;
                }

                if(arching)
                {

                }
                else if(colleging)
                {

                }
                else if(barracking)
                {

                }
                else
                {
                }
            }
        } 
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().sharedMaterial = regular;
    }
}
