﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {

    public JumpBox daddy;
    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("PLAYER HOOKER");
        if (c.tag == "Obstacle")
        {
            //daddy.pulltome;
            daddy.transform.position = this.transform.position;
            Destroy(this);
            Debug.Log("PLAYER HOOKER");
        }
    }

}
