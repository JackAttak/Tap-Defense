using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	private Transform global;
    private GameObject spawnObj;
	private float spawnZ;

	protected bool mouseOver;
	protected bool damaged;
    protected bool clicked;

    public bool attacking;
    public float atkSpeed;
    public float strength;

    void Awake()
	{
		global = GameObject.Find("Global").transform;
        spawnObj = GameObject.Find("SpawnObject");

		spawnZ = spawnObj.transform.position.z;
	}

	void OnMouseOver()
	{
		mouseOver = true;
	}

	void OnMouseExit()
	{
		mouseOver = false;
	}

	// Deal damage based on the damage variable.
	public virtual float Tap(float health, int damage)
	{
		health -= damage;

		damaged = true;

		return health;
	}

	// Changes the size of the enemy depending on how close they are to the camera.
	protected Vector3 SizeChange(float currZ, Vector3 originalScale)
	{
		Vector3 newScale;
		float multiplyBy = 0f;
		float multiple = 0f;

		float maxDist = Vector3.Distance(new Vector3(0f, 0f, spawnZ), new Vector3(0f, 0f, Camera.main.transform.position.z + 10f));

		float currDist = Vector3.Distance(new Vector3(0f, 0f, currZ), new Vector3(0f, 0f, Camera.main.transform.position.z + 10f));

        if (currZ > spawnZ - 13f)
        {
            multiple = 2f;
        }
        else if (currZ < spawnZ - 13f && currZ > Camera.main.transform.position.z + 10f)
        {
            multiple = 1.5f;
        }
        else
        {

        }

        multiplyBy = 1.0f - (currDist / maxDist) * multiple;
		newScale = originalScale * multiplyBy;

		return newScale;
	}

    protected int Damage(int damage)
    {
        return damage;
    }
}