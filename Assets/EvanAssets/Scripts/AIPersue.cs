using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIPersue : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 dVelocity;
    Vector2 ProjectedPos;

    Rigidbody2D targetrb;

    public float projdis;
    public float speed;
    public Transform target;

    float dist;
    public float acceptableDistance;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetrb = target.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position)
        {
            //acceptableDistance = (speed - targetrb.velocity.magnitude);
            dist = Vector2.Distance(transform.position, target.position);
            projdis = dist;
            

            if (dist > acceptableDistance)
            {
                Vector2 tempTargetPos = new Vector2(target.position.x, target.position.y);
                ProjectedPos = tempTargetPos + (targetrb.velocity.normalized * ((projdis - (speed - targetrb.velocity.magnitude) + 1)));
                dVelocity = speed * ((Vector3)(tempTargetPos + ProjectedPos) - transform.position).normalized;
                rb.AddForce(dVelocity - rb.velocity);
            }
            else
            {
                Debug.Log("(He's calling you a bitch)");

                //dVelocity = speed * (target.position - transform.position).normalized;

                //rb.AddForce(dVelocity - rb.velocity);
            }
        }

        Debug.DrawLine(transform.position, transform.position + ((Vector3)rb.velocity * 20), Color.black);
        Vector3 dir = target.position - transform.position;
        Debug.DrawLine(transform.position + Vector3.up/2,transform.position + dir.normalized * acceptableDistance, Color.magenta);
        Debug.DrawLine(transform.position + Vector3.up, ProjectedPos, Color.green);
        Debug.DrawLine(transform.position, transform.position + ((Vector3)dVelocity * 20), Color.red);
        Debug.DrawLine(targetrb.transform.position, ProjectedPos, Color.blue);

    }

    //void EATMYASS(int timesToEatAss)
    //{
    //    evan = bitchnugget;

    //    evan.mouth.position = Ass.position;
    //    for (int eats = timesToEatAss; eats > 0; eats--)
    //    {
    //        evan.mouth.eat();
    //    }
    //}

    //void eat()
    //{
    //    eat;
    //}
}