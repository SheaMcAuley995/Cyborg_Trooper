using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update () {
		
	}
}
