using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
	
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;

	public virtual void Use()
	{
		//use item
		//something Might happen
		//meant to be overloaded

		Debug.Log ("Using " + name);
	}
	public virtual void RemoveFromInventory(){
		Inventory.instance.Remove (this);
	}
}
