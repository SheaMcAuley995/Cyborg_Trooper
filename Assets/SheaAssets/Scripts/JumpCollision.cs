using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollision : MonoBehaviour {

    public float jumpVelocity = 5;

    bool jumpRequest;
    List<Collider2D> groundTouched = new List<Collider2D>();   


    void Update()
    {
        if (Input.GetButtonDown("Jump") && groundTouched.Count != 0)
        {
            
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);

        jumpRequest = false;
    }
}

//    void Oncollision2DEnter(Collision2D c)
//    {
//        ContactPoint2D[] points = new ContactPoint2D[2];
//        c.GetContacts(points);

//        for (int i = 0; i < points.Length; i++)
//        {
//            if(points [i].normal == Vector2.up && groundTouched.)
//        {
//            groundTouched.Add(c.collider);
//            return;
//        }
//        } 
//    }
//}