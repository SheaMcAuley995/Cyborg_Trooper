using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTrigger : MonoBehaviour
{
    HealthBar health;
    public float heal;


    void HealDamage()
    {
        if (health.hitpoint < health.maxHitpoint)
        {
            health.hitpoint += heal;
        }
    }


    void Healing()
    {
        Debug.Log("Healing");
        HealDamage();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Healing();
        }
    }

}