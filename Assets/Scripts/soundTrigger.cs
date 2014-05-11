using UnityEngine;
using System.Collections;

public class soundTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		if (other.name == "monoCam" || other.name == "CameraRight" || other.name == "OVRCameraController") {
			
						if (!audio.isPlaying) {
								audio.Play ();
						}
				}
	
		
	}
}
