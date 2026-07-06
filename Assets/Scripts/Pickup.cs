using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;  //prefab for item
    private void Start()
    {
        //find the gameobject tagged as "Player" and get its Inventory component
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //TODO: check if the colliding object has a tag of "Player"
        
        //TODO: loop through the inventory slots using a for loop
            
        //TODO: check if the current slot is not full
                
        //TODO: mark the slot as full

         //TODO: break out of the loop after filling one slot
                   
    }
}
