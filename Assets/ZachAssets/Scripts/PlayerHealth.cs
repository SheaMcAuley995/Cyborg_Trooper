using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public AudioClip pickup;

    public float addHealth = 10;
    static public float Health = 10;
    int damage = 1;

    public RectTransform healthBar;

    public TMPro.TextMeshProUGUI healthText;

    // Use this for initialization
    void Start ()
    {
        UpdateHealth();
    }

    void Respawn()
    {
        SceneManager.LoadScene("ZachDevScene");
    }

    void UpdateHealth()
    {
        healthText.text = "Health: " + Health;
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Trap")
        {
            Health -= Health;

            healthBar.sizeDelta = new Vector2(Health, healthBar.sizeDelta.y);

            Debug.Log("You died!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthGem")
        {
            Health += addHealth;
            UpdateHealth();

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.clip = pickup;

            Debug.Log("Your health has been increased!");
        }
    }

        // Update is called once per frame
    void Update ()
    {
        if (Health <= 0)
        {
            Debug.Log("You died!");
            Respawn();
        }
    }
}
