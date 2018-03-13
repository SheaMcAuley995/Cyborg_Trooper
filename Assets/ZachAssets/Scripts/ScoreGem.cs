using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ScoreGem : MonoBehaviour {

    //AudioClip pickup;

    public static float score;
    public float addScore = 1;

	// Use this for initialization
	void Start ()
    {
        score = 0;
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //AudioSource.PlayClipAtPoint(pickup, transform.position);
        }
    }

        // Update is called once per frame
        void Update ()
    {
		
	}
}
