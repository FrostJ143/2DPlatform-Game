using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance {get; private set;}
    
    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    private AudioSource _audioSource;
    private float _bgmVolume;
    
    
    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _bgmVolume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, .5f);
        _audioSource.volume = _bgmVolume;
    }
    
    public void ChangeVolume()
    {
        _bgmVolume += .1f;
        
        if (_bgmVolume >= 1.1f)
        {
            _bgmVolume = 0f;
        }
        
        _audioSource.volume = _bgmVolume;

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, _bgmVolume);
        PlayerPrefs.Save();
    }
    
    public float GetVolume()
    {
        return Mathf.RoundToInt(_bgmVolume * 10);
    }
    
}
