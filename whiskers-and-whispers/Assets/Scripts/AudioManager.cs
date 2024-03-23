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

    public void PlayDefaultMusic(){
        musicSource.clip = defaultBgMusic;
        musicSource.Play();
    }

    public void PlayMurderMusic(){
        musicSource.clip = murderBgMusic;
        musicSource.Play();
    }
}
