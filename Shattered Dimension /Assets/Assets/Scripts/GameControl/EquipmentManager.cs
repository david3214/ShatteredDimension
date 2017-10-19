using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EquipmentManager : MonoBehaviour {
	#region Singleton
	public static EquipmentManager instance;

	void Awake()
	{
		if (instance != null) {
			Debug.LogWarning ("More than one instance of Inventory found");
			return;
		}
		instance = this;
	}
	#endregion

	Equipment[] currentEquipment;
	SkinnedMeshRenderer[] currentMeshes;
	public Equipment[] DefaultItems;
	public delegate void OnEquipmentChanged(Equipment newItem,Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;
	public SkinnedMeshRenderer targetMesh;
	void Start(){
		int numslots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numslots];
		currentMeshes = new SkinnedMeshRenderer[numslots];
		EquipDefaultItems ();
	}
	public void Equip(Equipment newItem){
		int slotIndex = (int)newItem.equipSlot;

		Equipment oldItem = Unequip (slotIndex);;

		if (currentEquipment[slotIndex]!=null) {
			oldItem = currentEquipment [slotIndex];
			Inventory.instance.Add (oldItem);
		}
		currentEquipment [slotIndex] = newItem;
		if (onEquipmentChanged!=null) {
			onEquipmentChanged.Invoke (newItem,oldItem);
		}
		SkinnedMeshRenderer newmesh = Instantiate <SkinnedMeshRenderer> (newItem.mesh);
		newmesh.transform.parent = targetMesh.transform;

		newmesh.bones = targetMesh.bones;
		newmesh.rootBone = targetMesh.rootBone;
		currentMeshes [slotIndex] = newmesh;

		SetEquipmentblendShapes (newItem,100);
	}
	public Equipment Unequip(int slotIndex){
		if (currentEquipment[slotIndex]!=null) {
			if (currentMeshes[slotIndex]!=null) {
				Destroy (currentMeshes[slotIndex].gameObject);
			}
			Equipment oldItem = currentEquipment[slotIndex];
			Inventory.instance.Add (oldItem);

			currentEquipment [slotIndex] = null;

			if (onEquipmentChanged!=null) {
				onEquipmentChanged.Invoke (null,oldItem);
			}
			SetEquipmentblendShapes (oldItem,0);
			return oldItem;
		}
		return null;
	}
	public void UnequipAll()
	{
		for (int i = 0; i < currentEquipment.Length; i++) {
			Unequip (i);
		}
		EquipDefaultItems ();
	}
	void EquipDefaultItems()
	{
		foreach (var item in DefaultItems) {
			Equip (item);
		}
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.U)) {
			UnequipAll ();
		}
	}
	void SetEquipmentblendShapes(Equipment item, int weight)
	{
		foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegions) {
			targetMesh.SetBlendShapeWeight ((int)blendShape,weight);
		}
	}
}
