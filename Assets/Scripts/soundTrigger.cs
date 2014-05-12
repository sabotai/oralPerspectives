using UnityEngine;
using System.Collections;

public class soundTrigger : MonoBehaviour {
	public bool goGoGo = false;
	bool waiting = true;
	GameObject vomit;

	// Use this for initialization
	void Start () {
		vomit = GameObject.Find ("vomitOrigin");
	}
	
	// Update is called once per frame
	void Update () {
		if (goGoGo){
			if (!waiting){
				audio.volume *= 0.97f;
				StartCoroutine(updateAdvance());}
			
			vomit.GetComponent<secondaryAction> ().Vomit ();
			StartCoroutine (auto (30));
		}
	
	}


	void OnTriggerEnter(Collider other){
		if (other.name == "monoCam" || other.name == "CameraRight" || other.name == "OVRCameraController") {
			
						if (!audio.isPlaying) {
								audio.Play ();
			}
			StartCoroutine (auto (7));
				}
	
		
	}

	
	IEnumerator auto(float seconds){
		
		yield return new WaitForSeconds (seconds); 
		//Debug.Log ("BEFORE");
		
		StartCoroutine(updateAdvance ());
		
		yield break;
		
		
	}
	
	IEnumerator updateAdvance(){
		
		if (goGoGo) {
			waiting = false;
			if (audio.volume > 0.05f)  {
				//audio.volume *= 0.9f;
			} else {
				Application.LoadLevel("menu");}
				} else {
						goGoGo = true;
				}
		yield return 0;
		StopAllCoroutines ();
		yield break;
		
	}
}
