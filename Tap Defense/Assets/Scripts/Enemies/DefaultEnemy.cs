using UnityEngine;
using System.Collections;

public class DefaultEnemy : Enemy 
{
    public int damage;
	public float health;
	public float speed;
    public float healthBarHeight;
    public Texture healthTex;
    public Texture background;

    private float healthBarLength;
    private float maxHealth;
	private Vector3 originalScale;
    private Vector3 healthBarScreenPosition;
    private Transform wall;

    void Awake()
	{
        originalScale = transform.localScale;
        wall = GameObject.Find("Wall").transform;

        transform.localScale = SizeChange(transform.position.z, originalScale);

        maxHealth = health;
	}

	void Update()
	{
        StartCoroutine(Attack(atkSpeed));

        if (health > 0)
        {
            float percentOfHealth = health / maxHealth;
            healthBarLength = percentOfHealth * 100;
        }

        if (mouseOver)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				health = Tap(health, damage);

				if(health <= 0)
				{
					Destroy(gameObject);
				}
			}
		}

		if(transform.position.z < Camera.main.transform.position.z)
		{
			Destroy(gameObject);
		}

		transform.localScale = SizeChange(transform.position.z, originalScale);
	}

    void OnGUI()
    {
        Vector3 healthBarScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        healthBarScreenPosition.y = Screen.height - (healthBarScreenPosition.y + 1);

        if (health > 0 && health < maxHealth)
        {
            Rect rect2 = new Rect(healthBarScreenPosition.x - 25, healthBarScreenPosition.y - 50, maxHealth * 25, 10);
            GUI.DrawTexture(rect2, background);
            Rect rect = new Rect(healthBarScreenPosition.x - 25, healthBarScreenPosition.y - 50, healthBarLength * 0.5f, 10);
            GUI.DrawTexture(rect, healthTex);
        }
    }

    IEnumerator Attack(float wait)
    {
        if (attacking)
        {
            Debug.Log("hit");
            wall.GetComponent<Wally>().health -= strength;
            attacking = false;
            yield return new WaitForSeconds(wait);
            attacking = true;
        }
    }
}