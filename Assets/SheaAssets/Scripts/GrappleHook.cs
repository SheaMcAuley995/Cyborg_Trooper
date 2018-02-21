using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {

    public Camera cam;
    public GameObject hook;
 

    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Find mouse position
            Vector3 mouseInput = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector2 mouseClick = cam.ScreenToWorldPoint(mouseInput);


            //Find direction (ray)
            Vector3 rayDirection = mouseClick - (Vector2)this.transform.position;
            Vector3 rayNormalised = rayDirection.normalized;
            Vector3 r = Quaternion.Euler(0, 90, 0) * rayNormalised;
            Instantiate(hook, transform.position, Quaternion.Euler(r), transform);

           // RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position, rayDirection, grapple.grapplingHookRange, ~(1 << grapple.playerLayer));
            
        }

        }

    }
