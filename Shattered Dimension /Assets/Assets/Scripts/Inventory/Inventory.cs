using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory : MonoBehaviour {

	#region Singleton
	public static Inventory instance;

	void Awake()
	{
		if (instance != null) {
			Debug.LogWarning ("More than one instance of Inventory found");
			return;
		}
		instance = this;
	}
	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallBack;

	public List<Item> items = new List<Item> ();
	public int space = 20;

	public bool Add (Item item){
		if (!item.isDefaultItem) {
			if (items.Count>= space) {
				Debug.Log ("Not enough room");
				return false;
			}
			Debug.Log ("Added to inv : "+item.name);
			items.Add (item);

			if (onItemChangedCallBack != null) {
				onItemChangedCallBack.Invoke ();
				Debug.Log ("called OnItemChangedCallback");
			}

		}
		return true;
	}
	public void Remove (Item item){
		items.Remove (item);
		if (onItemChangedCallBack != null) {
			onItemChangedCallBack.Invoke ();
			Debug.Log ("called OnItemChangedCallback");
		}
	}
}
