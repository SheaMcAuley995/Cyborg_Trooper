using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {

    public Camera cam;
    public GameObject hook;


    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D rb;

    public float jumpVelocity;
    bool jumpRequest;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier;
            //rb.velocity += Vector2.up * Physics2D.gravity.y * 
        }
        else
        {
            rb.gravityScale = 1f;
        }

    }

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
