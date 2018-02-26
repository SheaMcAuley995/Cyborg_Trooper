using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRaycast : MonoBehaviour {

    [Range(1,10)]
    public float jumpVelocity;
    public float groundedSkin = 0.05f;

    public LayerMask mask;

    bool jumpRequest;
    bool grounded;

    Vector2 playerSize;


    private void Awake()
    {
        playerSize = GetComponent<BoxCollider2D>().size;

    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

            grounded = false;
            jumpRequest = false;
        }
        else
        {
            Vector2 rayStart = (Vector2)transform.position + Vector2.down * playerSize.y * 0.5f;
            grounded = Physics2D.Raycast(rayStart, Vector2.down, groundedSkin, mask);
        }
    } 
    

}