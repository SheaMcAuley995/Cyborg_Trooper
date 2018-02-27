using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {

    public int playerHealth = 10;
    int damage = 10;

	// Use this for initialization
	void Start ()
    {
        
	}

    void Respawn()
    {
        transform.position = Vector2.zero;
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
            transform.position = Vector2.zero;
        }
    }
}
