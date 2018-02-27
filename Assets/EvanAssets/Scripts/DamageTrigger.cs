using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damaging();
        }
    }

    void damaging()
    {
        Debug.Log("Damaging");
    }
}
