using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour {
	public float wait = 1;
	// Use this for initialization
	void Start () {
		StartCoroutine (Die());
	}
	IEnumerator Die()
	{
		yield return new WaitForSeconds(wait);
		Destroy (this.gameObject);
	}
}
