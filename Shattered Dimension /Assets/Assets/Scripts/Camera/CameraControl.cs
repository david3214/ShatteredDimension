using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {
	public List<Camera> cams = new List<Camera>();
	// Use this for initialization
	void Start () {
		AllCamsVoid ();
		cams [0].gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			AllCamsVoid ();
			cams [1].gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			AllCamsVoid ();
			cams [2].gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			AllCamsVoid ();
			cams [3].gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			AllCamsVoid ();
			cams [4].gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			AllCamsVoid ();
			cams [5].gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			AllCamsVoid ();
			cams [6].gameObject.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			AllCamsVoid ();
			cams [0].gameObject.SetActive (true);
		}

	}
	public void AllCamsVoid(){
		foreach (var cam in cams) {
			cam.gameObject.SetActive (false);
		}
	}
}
