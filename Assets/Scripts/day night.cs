using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class daynight : MonoBehaviour
{
    bool day = true;
    int hour = 0;
    float timer = 0;
    public Material daySkybox;
    public Material nightSkybox;
    GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        light = GameObject.Find("/Directional Light");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 60)
        {
            hour += 1;
            timer = 0;
            Debug.Log(hour);
            if (hour > 7 && hour < 19)
            {
                Debug.Log("dayyyyy");
                day = true;
                UnityEngine.RenderSettings.skybox = daySkybox;

                light.SetActive(true);


            } else
            {
                day = false;
                UnityEngine.RenderSettings.skybox = nightSkybox;

                light.SetActive(false);
            }
            if (hour > 24)
            {
                hour = 0;

            }

        }
    }
}
