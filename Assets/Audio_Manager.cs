using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager Instance;
    public Sound[] bgSounds,sfxSounds;
    public AudioSource bgSource, sfxSource;

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    private void Start(){
        PlayAudio("Theme");
    }
    public void PlayAudio(string name){
        Sound s = Array.Find(bgSounds, x => x.name == name);
        if (s==null){
            Debug.Log("Sound Not Found");
        }

        else{
            bgSource.clip = s.clip;
            bgSource.Play();
        }
    }
      public void PlaySFX(string name){
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s==null){
            Debug.Log("Sound Not Found");
        }

        else{
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
