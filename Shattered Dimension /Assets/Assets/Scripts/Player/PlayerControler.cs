using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerControler : MonoBehaviour {
	bool FP = false;
	Camera cam;
	public LayerMask movementMask;
	PlayerMotor motor;
	Interactable focus;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent <PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
		if (FP) 
		{
			
		}
		else
		{
			if(Input.GetMouseButtonDown (0))
			{
				Ray ray = cam.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast (ray,out hit,100,movementMask))
				{
					//move to hit
					motor.MoveToPoint (hit.point);
					//stop focusing object
					Removefocus ();
				}
			}
			if(Input.GetMouseButtonDown (1))
			{
				Ray ray = cam.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast (ray,out hit,100))
				{
					//check for interactable
					Interactable interactable = hit.collider.GetComponent <Interactable> ();
					if(interactable!= null){
						SetFocus (interactable);
					}
				}
			}
		}
	}
	void SetFocus(Interactable newFocus)
	{
		if (newFocus != focus) {
			if (focus!=null) {
				focus.OnDefocus ();
			}

			focus = newFocus;
			motor.FollowObject (newFocus);
		}
		newFocus.OnFocused (transform);
	}
	void Removefocus(){
		if (focus!=null) {
			focus.OnDefocus ();
		}
		focus = null;
		motor.StopTarget ();
	}
}
