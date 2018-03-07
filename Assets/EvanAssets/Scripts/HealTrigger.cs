using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTrigger : MonoBehaviour
{
    public HealthBar health;
    public float heal;
    public float healSpeed;


    void HealDamage()
    {
        if (health.hitpoint < health.maxHitpoint)
        {
            health.hitpoint += heal * Time.deltaTime * healSpeed;
        }
    }


    public void Healing()
    {
        Debug.Log("Healing");
        HealDamage();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Healing();
            //Debug.log("hitting the player");
        }
    }

}