using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour
{
    public BezierSpline spline;
	public Transform spawnObject;
	public Transform enemy;
	public bool canSpawn;
	public float waitTime;

    //variables for building menu
    public bool building;
    public bool archeryMenu;
    public bool collegeMenu;
    public bool barracksMenu;
    public GameObject buildingPanel;
    public GameObject archeryPanel;
    public GameObject collegePanel;
    public GameObject barracksPanel;
    public GameObject activeBuilding;

    public GameObject archer;
    public GameObject wizard;
    public GameObject soldier;
    public GameObject archery;
    public GameObject college;
    public GameObject barracks;
    public GameObject selected;


	void Start() 
	{

	}
	
	void Update() 
	{
		StartCoroutine(Spawn(waitTime));

        if(building)
        {
            buildingPanel.SetActive(true);
            Time.timeScale = 0.01f;
        }
        else
        {
            buildingPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
	}

    public void Archers()
    {
        if (selected.GetComponent<BuildingZone>().arching != true)
        {
            selected.GetComponent<BuildingZone>().built = Instantiate(archery, selected.transform.position, Quaternion.identity) as GameObject;
            selected.GetComponent<BuildingZone>().arching = true;
            building = false;
        }
    }

    public void Wizards()
    {
        if (selected.GetComponent<BuildingZone>().colleging != true)
        {
            selected.GetComponent<BuildingZone>().built = Instantiate(college, selected.transform.position, Quaternion.identity) as GameObject;
            selected.GetComponent<BuildingZone>().colleging = true;
            building = false;
        }
    }

    public void Soldiers()
    {
        if (selected.GetComponent<BuildingZone>().barracking != true)
        {
            selected.GetComponent<BuildingZone>().built = Instantiate(barracks, selected.transform.position, Quaternion.identity) as GameObject;
            selected.GetComponent<BuildingZone>().barracking = true;
            building = false;
        }
    }

    public void Exit()
    {
        building = false;
    }

    IEnumerator Spawn(float wait)
	{
		float randOffset = Random.Range(4f, -4f);

		if(canSpawn)
		{
            GameObject newEnemy = Instantiate(enemy, new Vector3(spawnObject.position.x + randOffset, spawnObject.position.y, spawnObject.position.z), enemy.transform.rotation) as GameObject;
            canSpawn = false;
      		yield return new WaitForSeconds(wait);
      		canSpawn = true;
        }
	}
}
