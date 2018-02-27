using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    [Header("Rotate Speeds")]
    [Range(-25,25)]
    public float rotationSpeedX;
    [Range(-25, 25)]
    public float rotationSpeedY;
    [Range(-25, 25)]
    public float rotationSpeedZ;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ);
    }
}
