﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    HealthBar health;
    public float damage;


    void TakeDamage()
    {
        if (health.hitpoint < 0)
        {
            health.hitpoint -= damage;
        }
    }


    void Damaging()
    {
        Debug.Log("Damaging");
        TakeDamage();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damaging();
        }
    }

}
