using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{

    public Image currentHealthBar;
    public Text healthValue;

    HealthBar health;

    public float hitpoint = 150.0f;
    private float maxHitpoint = 150.0f;

    int damage = 50;

    // Use this for initialization
    void Start()
    {
        hitpoint = health.hitpoint;
    }

    void Respawn()
    {
        SceneManager.LoadScene("ZachDev");
    }

    void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Obstacle")
        {
            hitpoint -= damage;
            Debug.Log("BLEEHHHH");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        healthValue.text = (ratio * 100).ToString("0") + '%';
        if (hitpoint <= 0)
        {
            Respawn();
            Debug.Log("Player killed");
        }
        if (hitpoint >= maxHitpoint)
        {
            hitpoint = maxHitpoint;
            Debug.Log("Player at max health");
        }
    }
}
