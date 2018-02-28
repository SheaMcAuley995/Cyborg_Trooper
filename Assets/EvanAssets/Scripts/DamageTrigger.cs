using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public HealthBar health;
    public float damage;
    public float damageSpeed;


    void TakeDamage()
    {
        if (health.hitpoint > 0)
        {
            health.hitpoint -= damage * Time.deltaTime * damageSpeed;
        }
    }


    public void Damaging()
    {
        Debug.Log("Damaging");
        TakeDamage();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damaging();
            Debug.Log("Hitting player");
        }
    }
}
