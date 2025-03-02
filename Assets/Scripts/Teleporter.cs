using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Teleporter : MonoBehaviour
{
    public Transform Target;
    GameObject Player;
    CharacterController CC;
    private void Start()
    {
        Player = GameObject.Find("Player");
        CC = Player.GetComponent<CharacterController>();
    }
    IEnumerator OnTriggerEnter()
    {
        StartCoroutine(BGMManager.Instance.FadeVolume(0.33f,3f));
        //CC is enabled/disabled because transform cannot be set while its active, thanks unity!
        CC.enabled = false;
        Player.transform.position = Target.position;
        CC.enabled = true;

        //to make sure player doesnt clip into floor
        CC.Move(new Vector3(0, 1, 0));

        //disable and enable player movement so they dont accidently go back and forth between 2 teleporters.
        Player.GetComponent<PlayerMovement>().toggleMovement(false);
        yield return new WaitForSeconds(0.5f);
        Player.GetComponent<PlayerMovement>().toggleMovement(true);



    }
}
