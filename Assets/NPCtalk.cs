using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class NPCtalk : MonoBehaviour
{
    [Header("Dialogue Settings")]
    [Space (10)]
    public GameObject dialougePanel;
    public Text dialougeText;
    public string[] dialouge;
    public GameObject contButton;
    public float wordSpeed;
    private int Index;
    public GameObject NPCInScene;
    [Space(10)]
    [Header("NPC Name")]
    [Space (10)]
    public Text npcNameText;
    public string npcName = "Jeffory";
    [Space(10)]
    [Header("NPC Icon")]
    [Space(10)]
    public Sprite npcImage;
    public Image npcIcon;
    [Space(10)]
    [Header("Checks")]

    public bool playerIsClose;
    
    

    void Update()
    {

        if (playerIsClose) 
        {
            npcNameText.text = npcName;

            npcIcon.sprite = npcImage;
        }

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
        npcNameText.text = "";
        Index = 0;
        dialougePanel.SetActive(false);
    }

       
    IEnumerator Typing() 
    {
        foreach (char letter in dialouge[Index].ToCharArray()) 
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


    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
            
        }
    }

}
