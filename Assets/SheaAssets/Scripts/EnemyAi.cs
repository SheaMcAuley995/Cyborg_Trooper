using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {

    public float speed;
    public LayerMask enemyMask;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;
    float myHeight;

	void Start () {
        myTrans = transform;
        myBody = GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;

    }

    private void FixedUpdate()
    {
        Vector2 lineCastPos = (Vector2)myTrans.position - (Vector2)myTrans.right * myWidth + Vector2.up * myHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGroudned = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos - (Vector2)myTrans.right *.05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - (Vector2)myTrans.right * 0.05f, enemyMask);

        if (!isGroudned || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }


        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }

}
