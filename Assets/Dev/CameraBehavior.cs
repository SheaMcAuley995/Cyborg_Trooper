using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {


    public Transform target;
    [SerializeField]
    float smoothSpeed = 0.125f;
    public Vector3 offset;


    private void FixedUpdate()
    {
        if(smoothSpeed < 4)
        {
            smoothSpeed += 0.01f * Time.deltaTime;
            if (smoothSpeed > 0.15f)
            {
                smoothSpeed += 0.125f;
            }
        }
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }


}
