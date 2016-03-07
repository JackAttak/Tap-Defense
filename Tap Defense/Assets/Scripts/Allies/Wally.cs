using UnityEngine;
using System.Collections;

public class Wally : MonoBehaviour
{
    public float health;
    public Texture healthTex;
    public Texture background;

    private float maxHealth;
    private float healthBarLength;

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        if (health > 0)
        {
            float percentOfHealth = health / maxHealth;
            healthBarLength = percentOfHealth * 200;
        }
    }

    void OnGUI()
    {
        Vector3 healthBarScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        healthBarScreenPosition.y = Screen.height - (healthBarScreenPosition.y + 1);

        if (health > 0 && health < maxHealth)
        {
            Rect rect2 = new Rect(healthBarScreenPosition.x - 100, healthBarScreenPosition.y + 100, maxHealth * 10, 10);
            GUI.DrawTexture(rect2, background);
            Rect rect = new Rect(healthBarScreenPosition.x - 100, healthBarScreenPosition.y + 100, healthBarLength, 10);
            GUI.DrawTexture(rect, healthTex);
        }
    }
}
