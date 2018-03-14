using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour , IDamgeable {

    public float maxHealth;
    float currentHealth;


	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	

    public void takeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        die();
    }

    public void die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
       
    }


	// Update is called once per frame
	void Update () {
		
	}
}
