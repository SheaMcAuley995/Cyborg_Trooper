using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwhook : MonoBehaviour {

    public GameObject hook;

    GameObject curHook;

    public bool ropeActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            if (!ropeActive)
            {


                Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);

                curHook.GetComponent<RopeScript>().destiny = destiny;
                ropeActive = true;
            }
            else
            {
                Destroy(curHook);
                ropeActive = false;
            }
        }

		
	}
}
