using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraFollow : MonoBehaviour {
	public Transform target;

	public Vector3 offset;

	public float zoomSpeed=4f;
	public float maxZoom=5f,minZoom=15f;
	public float currentZoom = 10f,pitch =2f;
	void Update(){
		//currentZoom -= Input.GetAxis ("Mouse ScrollWheel")*zoomSpeed;
		//currentZoom = Mathf.Clamp (currentZoom,minZoom,maxZoom);
	}
	void LateUpdate(){
		transform.position = target.position - offset * currentZoom;
		transform.LookAt (target.position+Vector3.up*pitch);
	}
}
