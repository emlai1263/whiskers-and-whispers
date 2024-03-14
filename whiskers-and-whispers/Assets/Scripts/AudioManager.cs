using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip defaultBgMusic;
    public AudioClip murderBgMusic;
    
    public static AudioManager instance;
    private void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    private void Start(){
        musicSource.clip = defaultBgMusic;
        musicSource.Play();
    }

    public void switchMusicMurder(){
        musicSource.clip = murderBgMusic;
        musicSource.Play();
    }

    public void switchMusicDefault(){
        musicSource.clip = defaultBgMusic;
        musicSource.Play();
    }
}
