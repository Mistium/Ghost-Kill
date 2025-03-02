using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneGeneric : MonoBehaviour
{
    public AudioClip Music;
    public float MusicVolume = 1;

    void Start()
    {
        StartCoroutine(BGMManager.Instance.PlayBGM(Music, MusicVolume));
    }
}
