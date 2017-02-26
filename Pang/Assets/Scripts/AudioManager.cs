using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager> {

    public AudioSource menuSource;
    public AudioClip menuClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayMenuSound()
    {
        menuSource.pitch = Random.Range(1f, 1.75f);
        menuSource.PlayOneShot(menuClip);
    }

    public void PlaySoundOnce(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
