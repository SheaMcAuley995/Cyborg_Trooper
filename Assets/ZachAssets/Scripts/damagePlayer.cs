using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour {

    public float score;
    public float addScore = 1;
    public float addHealth = 10;
    public float playerHealth;
    int damage = 10;

	// Use this for initialization
	void Start () 
    {
        playerHealth = 10;
        score = 0;
	}

    void Respawn()
    {
        SceneManager.LoadScene("ZachDev"); 
    }


    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Obstacle")
        {
            playerHealth -= damage;
            Debug.Log("You Died!");
        }

        if(c.gameObject.tag == "WinGem")
        {
            SceneManager.LoadScene("DevScene");
        }

        if(c.gameObject.tag == "DEATH BOX")
        {
            SceneManager.LoadScene("ZachDev");
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
    }

    void Update ()
    {
        if (playerHealth <= 0)
        {
            Respawn();
        }
    }
}
