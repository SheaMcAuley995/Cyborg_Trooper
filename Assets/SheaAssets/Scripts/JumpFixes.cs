using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFixes : MonoBehaviour {

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }


    private void FixedUpdate()
    {
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
    }
}
