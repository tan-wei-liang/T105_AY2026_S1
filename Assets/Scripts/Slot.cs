using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int index;  //index of the slot in the inventory

    private void Start()
    {
        //find the gameobject tagged with "Player" and get its Inventory component
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        //check if slot is empty
        if (transform.childCount <= 0)
        {
            //mark this slot as not full in the inventory
            inventory.isFull[index] = false;
        }
    }

    //TODO: Create a method to drop an item from this slot
    //TODO: Iterate through each child Transform (item) in this slot
    //TODO: For each child, call SpawnDroppedItem() on its Spawn component
    //TODO: Destroy the item GameObject after dropping
    
}
