using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Image currentHealthBar;
    public Text healthValue;

    public float hitpoint = 150.0f;
    public float maxHitpoint = 150.0f;

    // Use this for initialization
    void Start()
    { 
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        healthValue.text = (ratio * 100).ToString("0") + '%';
        if (hitpoint <= 0)
        {
            Debug.Log("Player killed");
        }
        if (hitpoint >= maxHitpoint)
        {
            hitpoint = maxHitpoint;
            Debug.Log("Player at max health");
        }
    }

    void TakeDamage(float damage)
    {
        if (hitpoint < 0)
        {
            hitpoint -= damage;
        }
     }

    void HealDamage(float heal)
    {
        if (hitpoint < maxHitpoint)
        {
            hitpoint += heal;
        }
    }
}
