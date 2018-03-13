using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour {

    AudioSource source;
    public bool isMuted;
	// Use this for initialization
	void Start () {
		
	}
	

    public void mute()
    {
        isMuted = !isMuted;
        source.mute = isMuted;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
