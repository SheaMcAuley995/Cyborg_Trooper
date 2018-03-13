using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeRender : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject player;
    Transform startMarker;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        startMarker.position = player.transform.position;
       if(rb.velocity.y >= 10.0f || rb.velocity.x >= 10.0f)
        {
            rb.velocity *= 0.8f;
        }
	}
}
