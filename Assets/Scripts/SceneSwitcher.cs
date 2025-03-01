using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneSwitcher : MonoBehaviour
{

    public static SceneSwitcher Instance;


    GameObject Position;
    GameObject Player;

    CharacterController CC;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadScene(string Scene, string Target)
    {
        StartCoroutine(LoadSceneCoroutine(Scene, Target));
    }
    IEnumerator LoadSceneCoroutine(string Scene, string Target)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //wait a frame to make sure stuff loads right
        yield return null;

        Player = GameObject.Find("Player");
        Position = GameObject.Find(Target);
        Debug.Log(Position);
        CC = Player.GetComponent<CharacterController>();

        //CC is enabled/disabled because transform cannot be set while its active, thanks unity!
        CC.enabled = false;
        Player.transform.position = Position.transform.position;
        CC.enabled = true;

        //to make sure player doesnt clip into floor
        CC.Move(new Vector3(0, 1, 0));

        //disable and enable player movement so they dont accidently go back and forth between 2 teleporters.
        Player.GetComponent<PlayerMovement>().toggleMovement(false);
        yield return new WaitForSeconds(0.5f);
        Player.GetComponent<PlayerMovement>().toggleMovement(true);


    }
}
