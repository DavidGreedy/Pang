using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    public bool musicMuted, sfxMuted;

    const string SFX_VOLUME_KEY = "sfx_volume";

    const string MUSIC_VOLUME_KEY = "music_volume";
    public MusicManager musicManager;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (musicMuted)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, 0f);
        }
        else
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, 0.3f);
        }

        if (sfxMuted)
        {
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, 0f);
        }
        else
        {
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, 0.7f);
        }
    }

    public void MuteMusic()
    {
        musicMuted = !musicMuted;
        musicManager.SaveAndExit();
    }

    public void MuteSFX()
    {
        sfxMuted = !sfxMuted;
        musicManager.SaveAndExit();
    }



    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
    }

    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
    }
}
