using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunRotation : MonoBehaviour
{

    public float rotationSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed, 0, rotationSpeed / 3);
    }
}
