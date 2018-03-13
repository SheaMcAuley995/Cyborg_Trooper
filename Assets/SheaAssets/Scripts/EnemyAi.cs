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
    float time;
    int bulletdir = 10;
    public GameObject bullet;
    public float detectionDistance = 10;

    public Transform target;

    bool rightLeft; //right is true
    int dir = -1; // left is and right is -1;

	void Start () {
        myTrans = transform;
        myBody = GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;

    }
    public bool isGrounded;
    private void FixedUpdate()
    {
        Vector2 lineCastPos = (Vector2)myTrans.position - (Vector2)( dir * myTrans.right) * myWidth + Vector2.up * myHeight;
        Debug.DrawLine(lineCastPos, (Vector2)lineCastPos + Vector2.down, Color.red);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(lineCastPos, Vector2.down,1);
        Debug.DrawLine(lineCastPos, lineCastPos - (Vector2)myTrans.right *.05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - (Vector2)myTrans.right * 0.05f, enemyMask);

        if(hit.collider == null)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }




        if (Mathf.Abs(target.position.x) - Mathf.Abs(transform.position.x) <= detectionDistance
          &&
          Mathf.Abs(target.position.x) - Mathf.Abs(transform.position.x) >= 0
         )
        {
            if (time >= 60)
            {
                GameObject spawnedBullet = Instantiate(bullet);
                spawnedBullet.transform.position = transform.position;

                //spawnedBullet.GetComponent<BulletTr>().moveSpeed = bulletdir;
                time = 0;
            }
            else
            {
                time++;
            }
        }
        else if (Mathf.Abs(target.position.x) - Mathf.Abs(transform.position.x) >= -detectionDistance
            &&
            Mathf.Abs(target.position.x) - Mathf.Abs(transform.position.x) <= 0
           )
        {
            if (time >= 60)
            {
                GameObject spawnedBullet = Instantiate(bullet);
                spawnedBullet.transform.position = transform.position;

                spawnedBullet.GetComponent<MoveTrail>().moveSpeed = bulletdir;
                time = 0;
            }
            else
            {
                time++;
            }
        }







        if (!isGrounded)
        {
            bulletdir *= dir;
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

      
            Vector2 myVel = myBody.velocity;
            myVel.x = myTrans.right.x * (speed * -dir);
            myBody.velocity = myVel;
       
        
    }

}
