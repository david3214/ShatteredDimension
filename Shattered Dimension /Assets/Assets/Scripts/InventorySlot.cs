using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour {
	Item item;
	public Image icon;
	public Button removeButton;
	public void Start(){
		ClearSlot ();
	}
	public void AddItem(Item _item){
		item = _item;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
		removeButton.image.enabled =true;
	}
	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;

		removeButton.image.enabled = false;

	}
	public void OnRemoveButton()
	{
		Inventory.instance.Remove (item);
		Debug.Log ("RemoveButtonClicked");
	}

	public void useItem()
	{
		if (item!=null) {
			item.Use ();
		}
	}
}
