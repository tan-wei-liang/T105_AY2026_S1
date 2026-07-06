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
		if (collision.CompareTag("Player"))
		{
			//TODO: loop through the inventory slots using a for loop
			for (int i = 0; i < inventory.isFull.Length; i++)
			{
				//TODO: check if the current slot is not full
				if (inventory.isFull[i] == false)
				{
					//TODO: mark the slot as full
					inventory.isFull[i] = true;
					//instantiate the button in the current slot and remove pickup from scene
					Instantiate(itemButton, inventory.slots[i].transform);
					Destroy(gameObject);
					//TODO: break out of the loop after filling one slot
					break;
				}
			}
		}
	}
}
