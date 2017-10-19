using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int hp = 100;
	public float dieTime =1;
	GameObject deadObj;
	public int dmgHigh = 1,dmgLow =1;
 	bool dead =false;

	// Use this for initialization
	void Start () {
		deadObj = GameObject.Find ("WorldController").GetComponent <Storage>().DeathAnim;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp < 0 && dead != true) {
			dead = true;
			StartCoroutine(Die());
		}
		if(this.transform.position.y<(-1024)){ hp -= 1;}

	}
	IEnumerator Die()
	{
		this.GetComponent <playerControlDB> ().Die ();
		yield return new WaitForSeconds(dieTime);
		Instantiate (deadObj,this.transform.position,this.transform.rotation);
		Destroy (this.gameObject);
	}
	public void TakeDmg(int amnt){
		hp -= amnt;
	}
	public int GetDmg(bool crit){
		if (crit) {
			return dmgHigh;
		}
		return Random.Range (dmgLow, dmgHigh);
	}
}

