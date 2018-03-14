using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown : MonoBehaviour {

    int time = 70;
    
	// Update is called once per frame
	void Update () {
        
        if(time > 0)
        {
            time--;
        }
        else
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
            rb.AddForce(transform.forward * 2, ForceMode.Impulse);
        }
		
	}
}
