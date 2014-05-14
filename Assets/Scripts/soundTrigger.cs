using UnityEngine;
using System.Collections;

public class soundTrigger : MonoBehaviour {
	public bool goGoGo = false;
	public bool waiting = true;
	GameObject vomit;
	public AudioSource orgasmSound;

	// Use this for initialization
	void Start () {
		vomit = GameObject.Find ("vomitOrigin");
	}
	
	// Update is called once per frame
	void Update () {
				if (goGoGo) {
						if (!waiting) {
								//if updateAdvance is already done, lower the volume
								audio.volume *= 0.998f;
								StartCoroutine(updateAdvance());
						}
								//StartCoroutine (auto (0.1f));

						vomit.GetComponent<secondaryAction> ().Vomit ();


						StartCoroutine (auto (3));
				}
	
				
		}

	void OnTriggerEnter(Collider other){
		if (other.name == "monoCam" || other.name == "CameraRight" || other.name == "OVRCameraController") {
			

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
		
		if (!orgasmSound.isPlaying && waiting) {
			orgasmSound.Play ();
		}
		
		if (goGoGo && !waiting) {
			if (!audio.isPlaying) {
				audio.Play ();
			}
		}

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
