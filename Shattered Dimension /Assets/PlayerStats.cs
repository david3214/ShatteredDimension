using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
	
	// Update is called once per frame
	void OnEquipmentChanged (Equipment newItem,Equipment oldItem) {
		if (newItem != null) {
			armor.AddModifier (newItem.armorMod);
			damage.AddModifier (newItem.damageMod);
		}
		if (oldItem != null) {
			armor.RemoveModifier (oldItem.armorMod);
			damage.RemoveModifier (oldItem.damageMod);
		}
	}
}
