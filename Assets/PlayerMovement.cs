using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


 


    CharacterController CC;

    Vector3 moveDirection;

    void Start()
    {
        CC = GetComponent<CharacterController>(); 

       
    }

   
    void Update()
    {

        transform.Rotate(0, 0, 0);

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        moveDirection = transform.rotation * moveDirection;

  

      
      

        CC.SimpleMove(moveDirection * 5);
    }
}
