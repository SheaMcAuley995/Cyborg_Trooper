using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

    public int rotationOffset = 90;
	void Update ()
    {
      //  Vector3 mouseInput = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
      //  Vector2 mouseClick = Camera.main.ScreenToWorldPoint(mouseInput);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      //  Vector3 rayDirection = mouseClick - (Vector2)Parent.transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
      //  Debug.Log(difference);
        //Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(mouseInput), Color.red);
       // Debug.DrawLine(transform.position,transform.position + (Vector3)mouseClick, Color.green);

    }
}
