using UnityEngine;
public class Interactable : MonoBehaviour {
	
	public float radius = 3f;
	bool isfocus = false,hasInteracted = false;
	Transform player;
	public Transform interactionTransform;
	public virtual void Interact(){
	//this is meant to be overidden
		Debug.Log ("Interact");
	}
	void Start(){
		if (interactionTransform == null) {
			interactionTransform = this.transform;
		}
	}
	void Update()
	{
		if (isfocus&&!hasInteracted) {
			float distance = Vector3.Distance (player.position, interactionTransform.position);
			if (distance<=radius) {
				Interact ();
				hasInteracted = true;
			}
		}
	}
	public void OnFocused(Transform pl)
	{
		isfocus = true;
		player = pl;
		hasInteracted = false;
	}
	public void OnDefocus()
	{
		player = null;
		isfocus = false;
		hasInteracted = false;
	}
	void OnDrawGizmosSelected(){
		if (interactionTransform == null) {
			interactionTransform = transform;
		}
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (interactionTransform.position, radius);
	}
}
