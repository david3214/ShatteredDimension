using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ItemConvert : ConvertToRegularMesh {
	[ContextMenu("Convert to regular mesh")]
	public override void Convert ()
	{
		this.gameObject.AddComponent <MeshCollider>();
		this.gameObject.AddComponent <ItemPickup>();
		base.Convert ();

	}
}
