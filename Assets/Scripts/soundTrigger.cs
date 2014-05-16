using UnityEngine;
using System.Collections;

public class soundTrigger : MonoBehaviour {
	public bool goGoGo = false;
	public bool waiting = true;
	GameObject vomit;
	public AudioSource orgasmSound;
	bool fadeToBlack = false;
	GameObject camera, camera2;

	// Use this for initialization
	void Start () {
		vomit = GameObject.Find ("vomitOrigin");

		if (GameObject.Find("Player 1").GetComponent<useRift>().useOculusRift) {
			camera = GameObject.Find ("CameraRight");
			camera2 = GameObject.Find ("CameraLeft");
				} else {
			camera = GameObject.Find ("monoCam");
				}
	}
	
	// Update is called once per frame
	void Update () {
				if (goGoGo) {
						if (!waiting) {
								//if updateAdvance is already done, lower the volume
								audio.volume *= 0.992f;
								StartCoroutine(updateAdvance());
						}
								//StartCoroutine (auto (0.1f));

						vomit.GetComponent<secondaryAction> ().Vomit ();


						StartCoroutine (auto (3));
				}

		if (fadeToBlack) {
			camera.GetComponent<EdgeDetectEffectNormals>().edgesOnly+= 0.1f * Time.deltaTime;
			if (camera2 != null){
				camera2.GetComponent<EdgeDetectEffectNormals>().edgesOnly+= 0.1f * Time.deltaTime;}
				}

		if (camera.GetComponent<EdgeDetectEffectNormals>().edgesOnly > 0.99f){
			//if (GameObject.Find("Player 1").GetComponent<useRift>().useOculusRift) {
				//Application.LoadLevel("menu");} else {
				Application.LoadLevel("test");
			//}
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
				fadeToBlack = true;
				//Application.LoadLevel("menu");
			}
				} else {
						goGoGo = true;
				}

		yield return 0;
		StopAllCoroutines ();
		yield break;
		
	}
}
