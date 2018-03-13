using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnModel : MonoBehaviour {

    Transform myTrans;
    public Rigidbody2D playerRB;
    


    private void Awake()
    {
        myTrans = GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 currentRot = myTrans.eulerAngles;
        if (playerRB.velocity.x > 0)
        {
            currentRot.y = 90;
        }
        else if(playerRB.velocity.x < 0)
        {
            currentRot.y = 270;
        }
        myTrans.eulerAngles = currentRot;
    }


}
