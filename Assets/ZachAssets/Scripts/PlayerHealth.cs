using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float addHealth = 10;
    public float playerHealth = 10;
    int damage = 1;

    public RectTransform healthBar;

    public GUIText healthText;

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
        healthText.text = "Health: " + playerHealth;
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Trap")
        {
            playerHealth -= playerHealth;

            healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);

            Debug.Log("You died!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthGem")
        {
            playerHealth += addHealth;
            UpdateHealth();
            Debug.Log("Your health has been increased!");
        }
    }

        // Update is called once per frame
    void Update ()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("You died!");
            Respawn();
        }
    }
}
