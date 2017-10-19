using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.NavMeshAgent;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {
	
	NavMeshAgent agent;

	Transform target;
//	bool contFollow = false;
	// Use this for initialization
	void Start () {
		agent = GetComponent <NavMeshAgent> ();
	}
	void Update()
	{
		if (target!=null) {
			agent.SetDestination (target.position);
			FaceTarget ();
		}
	}
	public void MoveToPoint(Vector3 point){
		agent.SetDestination (point);
	}
	public void FollowObject(Interactable folow)
	{
		agent.stoppingDistance = folow.radius * 0.8f;
		agent.updateRotation = false;
		target = folow.interactionTransform;

//		contFollow = true;
//		StartCoroutine (Folow());
	}

	public void StopTarget(){
		agent.stoppingDistance = 0f;
		agent.updateRotation = true;
		target = null;
//		contFollow = false;
	}
	void FaceTarget(){
		Vector3 dir = (target.position - this.transform.position).normalized;
		Quaternion rot = Quaternion.LookRotation (new Vector3 (dir.x, 0, dir.z));
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * 5f);

	}
//	IEnumerator Folow ()
//	{
//		while (contFollow) {
//			MoveToPoint (target.position);
//			yield return new WaitForSeconds (1f);
//		}
//	}
}

