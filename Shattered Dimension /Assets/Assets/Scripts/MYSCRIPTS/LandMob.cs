using UnityEngine;
using System.Collections;

public class LandMob : MonoBehaviour {
	public GameObject player;
	public float walkTime=1f,speed = 1f;
	bool move = true,forward = false;

	//int xyz = 0;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(move) {
			StartCoroutine (Move ());
			move = false;
		}
		if (forward) {
			transform.Translate(transform.forward * speed * Time.deltaTime,Space.World);
		}
	}
	IEnumerator Move()
	{
		this.GetComponent <playerControlDB> ().Walk ();
		forward = true;
		yield return new WaitForSeconds(walkTime);
		move = true;
		forward = true;
	}
}
