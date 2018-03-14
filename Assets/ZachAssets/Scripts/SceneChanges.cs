using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanges : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "WinGem")
        {
            SceneManager.LoadScene("WinScene");
        }

        if(c.gameObject.tag == "DEATH BOX")
        {
            SceneManager.LoadScene("SheaDevScene");
        }
    }
}
