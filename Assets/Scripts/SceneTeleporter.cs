using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleporter : MonoBehaviour
{
    public string Scene;
    public string Target;

    public void OnTriggerEnter()
    {
        SceneSwitcher.Instance.LoadScene(Scene, Target);
    }
}
