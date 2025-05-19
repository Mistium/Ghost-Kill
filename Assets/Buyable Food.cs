using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableFood : MonoBehaviour
{
    public GameObject FoodBuy;
    public GameObject ShopText;
    public GameObject MoneyText;
    public bool playerNearby;
    public int foodCost;

   
    void Start()
    {
      
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            playerNearby = true;
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

        }
    }


    void Update()
    {
        
        if (playerNearby) 
        {
            ShopText.SetActive(true);
            MoneyText.SetActive(true);
        
        }
        else 
        {
            ShopText.SetActive(false); 
            MoneyText.SetActive(false);
        
        }

        if (playerNearby && Input.GetKeyUp(KeyCode.Space))
        {
            FoodBuy.SetActive(true);
        }
       
        if (playerNearby ==false) 
        {
            FoodBuy.SetActive(false) ;
        }

    
        



    }
}
