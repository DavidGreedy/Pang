using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource thisSource;
    public AudioClip audioClip;


    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayMenuSound()
    {
       thisSource.pitch = Random.Range(1f, 1.75f);
       thisSource.PlayOneShot(audioClip);
    }

    public void PlaySoundOnce(AudioSource source, AudioClip clip)
    {
        thisSource.pitch = 1f;
        thisSource = source;
        thisSource.PlayOneShot(clip);
    }
}
