using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;
    AudioSource AudioSrc;

    public float FadeDuration = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            AudioSrc = gameObject.GetComponent<AudioSource>();
        }
    }

    public IEnumerator PlayBGM(AudioClip music, float Target)
    {
        //if music set to play is same as one already playing, dont restart playing
        if (AudioSrc.clip != music)
        {
            //if nothing was playing, skip fade out
            if (AudioSrc.clip != null)
            {
                //fade out old
                yield return StartCoroutine(FadeVolume(0, FadeDuration));
            }

            //make sure the volume is 0
            AudioSrc.volume = 0;

            AudioSrc.clip = music;
            AudioSrc.Play();


            //fade in new
            yield return StartCoroutine(FadeVolume(Target, FadeDuration));
        }
    }

    public IEnumerator FadeVolume(float Target, float Duration)
    {
        float StartVolume = AudioSrc.volume;

        for (float t = 0; t < Duration; t += Time.deltaTime)
        {   
            AudioSrc.volume = Mathf.Lerp(StartVolume, Target, t / Duration);
            yield return null;
        }
    }

}
