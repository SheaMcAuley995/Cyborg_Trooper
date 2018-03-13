using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float score;
    public float addScore = 1;

    public GUIText scoreText;

    // Use this for initialization
    void Start ()
    {
        score = 0;

        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "ScoreCheck")
        {
            if (score < 6)
            {
                Debug.Log("Your score isn't high enough to progress!");
            }
            if (score >= 6)
            {
                Destroy(GameObject.FindGameObjectWithTag("ScoreCheck"));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ScoreGem")
        {
            score += addScore;
            UpdateScore();
            Debug.Log("Your score has increased!");
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
