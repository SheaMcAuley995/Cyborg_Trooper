using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public AudioClip pickup;

    public float score;
    public float addScore = 1;

    public TMPro.TextMeshProUGUI scoreText;

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

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.clip = pickup;

            Debug.Log("Your score has increased!");
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
