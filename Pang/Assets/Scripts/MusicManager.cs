using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip gameMusic;

    public AudioSource thisAudioSource;
    public AudioSource sfxAudio;

    public AudioClip[] sfxAudioClips;

    


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

    }


    public void UISelectNoise()
    {
        sfxAudio.volume = 0.7f;
        thisAudioSource.pitch = Random.Range(1f, 1.5f);
        thisAudioSource.PlayOneShot(sfxAudioClips[1]);
    }

    public void playGameNoise(int clipNum)
    {
        sfxAudio.volume = 0.7f;
        sfxAudio.PlayOneShot(sfxAudioClips[clipNum]);
    }

    public void SaveAndExit()
    {
        thisAudioSource.volume = PlayerPrefsManager.GetMusicVolume();
        sfxAudio.volume = PlayerPrefsManager.GetSFXVolume();
    }
}
