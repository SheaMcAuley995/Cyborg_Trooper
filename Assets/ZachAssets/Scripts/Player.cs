using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float score;
    public float addScore = 1;
    public float addHealth = 10;
    public float playerHealth = 10;
    int damage = 1;

    public RectTransform healthBar;

	// Use this for initialization
	void Start () 
    {
        //playerHealth = 10;
        score = 0;
	}

    void Respawn()
    {
        SceneManager.LoadScene("DevScene"); 
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Trap")
        {
            playerHealth -= playerHealth;

            healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);

            Debug.Log("You died!");
        }

        if(c.gameObject.tag == "WinGem")
        {
            SceneManager.LoadScene("WinScene");
        }

        if(c.gameObject.tag == "DEATH BOX")
        {
            SceneManager.LoadScene("DevScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreGem")
        {
            score += addScore;
            Debug.Log("Your score has increased!");           
        }

        if (other.gameObject.tag == "HealthGem")
        {
            playerHealth += addHealth;
            Debug.Log("Your health has been increased!");
        }

        if (other.gameObject.tag == "DeathGem")
        {
            playerHealth -= playerHealth;
            Debug.Log("HAHAHAHA you fell for the trap!");
        }
    }

    void Update ()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("You died!");
            Respawn();
        }
    }
}
