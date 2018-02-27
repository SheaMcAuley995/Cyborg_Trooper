using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class damagePlayer : MonoBehaviour {

    HealthBar health;
    public float playerHealth;
    int damage = 10;

	// Use this for initialization
	void Start ()
    {
        playerHealth = health.hitpoint;
	}

    void Respawn()
    {
        SceneManager.LoadScene("ZachDev");
    }

    void OnCollisionEnter2D (Collision2D _collision)
    {
		if (_collision.gameObject.tag == "Obstacle")
        {
            playerHealth -= damage;
            Debug.Log("BLEEHHHH");
        }
	}  

    void Update ()
    {
        if (playerHealth == 0)
        {
            Respawn();
        }
    }
}
