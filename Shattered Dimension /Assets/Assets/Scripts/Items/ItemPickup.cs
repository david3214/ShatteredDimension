using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemPickup : Interactable {

	public Item item;

	public override void Interact(){
		base.Interact ();
		Pickup ();
	}
	void Pickup()
	{
		Debug.Log ("Picking up "+ item.name);
		bool wasPickedUp = Inventory.instance.Add (item);
		//add item to inventory
		if (wasPickedUp) Destroy (gameObject);
	}
}
