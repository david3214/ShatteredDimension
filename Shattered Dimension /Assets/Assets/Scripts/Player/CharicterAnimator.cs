using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CharicterAnimator : MonoBehaviour {

	const float locAnimSmoothtime = 0.1f;

	Animator animator;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent <NavMeshAgent> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float speedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat ("speedPercent",speedPercent, locAnimSmoothtime,Time.deltaTime);
	} 
}
