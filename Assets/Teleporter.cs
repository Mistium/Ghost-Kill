using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Teleporter : MonoBehaviour
{
    public Transform Target;
    public GameObject Player;

    private void OnTriggerEnter()
    {

        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = Target.position;
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
