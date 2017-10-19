using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ConvertToRegularMesh : MonoBehaviour {

	[ContextMenu("Convert to regular mesh")]
	public virtual void Convert(){
		SkinnedMeshRenderer smr = GetComponent <SkinnedMeshRenderer> ();
		MeshRenderer  meshrend = gameObject.AddComponent <MeshRenderer> ();
		MeshFilter meshfilt = gameObject.AddComponent <MeshFilter> ();

		meshfilt.sharedMesh = smr.sharedMesh;
		meshrend.sharedMaterials = smr.sharedMaterials;
		DestroyImmediate (smr);
		DestroyImmediate (this);
	}
}
