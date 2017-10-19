using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryUI : MonoBehaviour {
	Inventory inv;

	public Transform itemsParent;
	public GameObject invUI;
	InventorySlot[] slots;
	// Use this for initialization
	void Start () {
		inv = Inventory.instance;
		inv.onItemChangedCallBack+= UpdateUI;
		slots = itemsParent.GetComponentsInChildren <InventorySlot> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Inventory")) {
			invUI.SetActive (!invUI.activeSelf);
		}
	}

	void UpdateUI()
	{
		//slots = itemsParent.GetComponentsInChildren <InventorySlot> ();

		Debug.Log ("Updating UI");
		for (int i = 0; i < slots.Length; i++) {
			if (i < inv.items.Count) {
				slots [i].AddItem (inv.items [i]);
			} else {
				slots[i].ClearSlot ();
			}
		}
	}
}
