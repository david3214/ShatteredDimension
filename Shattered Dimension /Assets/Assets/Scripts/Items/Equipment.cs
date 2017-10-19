using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "New Equipment",menuName = "Inventory/Equipment")]
public class Equipment : Item{

	public EquipmentSlot equipSlot;
	public SkinnedMeshRenderer mesh;
	public EquipmentMeshRegion[] coveredMeshRegions;
	public int armorMod;
	public int damageMod;

	public override void Use()
	{
		base.Use ();
		//equip item
		EquipmentManager.instance.Equip (this);
		//remove from inventory
		RemoveFromInventory ();
	}
}

public enum EquipmentSlot{Head, Chest, Legs, Weapon, Sheild, Feet, Sword2}
public enum EquipmentMeshRegion{Legs, Arms, Torso}