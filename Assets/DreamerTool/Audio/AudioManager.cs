/*****************************
Created by 师鸿博
*****************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.Util;
using DreamerTool.Singleton;
public class AudioManager : MonoSingleton<AudioManager>
{
    private AudioSource _audio;
    AudioClips _clips;
    private void Awake()
    {
        if (!GetComponent<AudioSource>())
            _audio = gameObject.AddComponent<AudioSource>();

        _clips = DreamerUtil.GetScriptableObject<AudioClips>() ;
 
    }
 
    public void PlayBGM(string audio_name)
    {
        _audio.clip = _clips.GetClip(audio_name);
        _audio.Play();
    }

    public void PlayOneShot(string audio_name)
    {
        var clip = _clips.GetClip(audio_name);
        _audio.pitch = Random.Range(1.0f, 2.0f);
        _audio.PlayOneShot(clip);
    }
}
