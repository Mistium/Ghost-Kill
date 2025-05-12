using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class NPCtalk : MonoBehaviour
{

    public GameObject dialougePanel;
    public Text dialougeText;
    public string[] dialouge;
    private int Index;


    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;



    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && playerIsClose)
        {

            if (dialougePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialougePanel.SetActive(true);
                StartCoroutine(Typing());

            }

        }

        if (dialougeText.text == dialouge[Index]) 
        {
            contButton.SetActive(true);
        
        }
    }




    public void zeroText() 
    {
        dialougeText.text = "";
        Index = 0;
        dialougePanel.SetActive(false);
    }

       
    IEnumerator Typing() 
    {
        foreach(char letter in dialouge[Index].ToCharArray())
        {
            dialougeText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    
    }

    void Start()
    {
        dialougeText.text = "";
    }


    public void Nextline() 
    {

        contButton.SetActive(false);

        if(Index < dialouge.Length - 1) 
        {
            Index++;
            dialougeText.text = "";
            StartCoroutine(Typing());
        
        }
        else 
        {
            zeroText();
        
        }
    
    }


    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

}
