using UnityEngine;
using System.Collections;

public class useRift : MonoBehaviour {

	public bool useOculusRift = false;
	public bool useMouthController = false;
	public bool useMenu = true;

	private OVRDevice ovrdevice;

	// Use this for initialization
	void Start () {
		if (useMenu) {
						if (PlayerPrefs.GetInt ("Rift") == 1) {
								useOculusRift = true;
						}

		
						if (PlayerPrefs.GetInt ("Mouth") == 1) {
								useMouthController = true;
			
						}
				}


		if (useOculusRift) {


						GameObject.Find ("CameraLeft").camera.enabled = true;
						GameObject.Find ("CameraRight").camera.enabled = true;
			GameObject.Find ("CameraRight").GetComponent<fixRiftPosition>().correctBool = true;
			GameObject.Find ("monoCam").camera.enabled = false;
			GameObject.Find ("monoCam").GetComponent<MouseLook>().enabled = false;
			GameObject.Find ("CameraRight").GetComponent<raycast>().enabled = true;
			GameObject.Find ("monoCam").GetComponent<raycast>().enabled = false;
			
			if (Application.loadedLevelName == "birdSceneB 2"){
			GameObject.Find ("guiPlane").GetComponent<animateMat>().useRiftGui = true;

			GameObject.Find ("guiPlane").transform.parent = GameObject.Find ("CameraRight").transform;

				
				GameObject.Find ("CameraRight").GetComponent<AudioListener>().enabled = true;
				GameObject.Find ("monoCam").GetComponent<AudioListener>().enabled = false;
			}

		} else {
			GameObject.Find ("CameraLeft").camera.enabled = false;
			GameObject.Find ("CameraRight").camera.enabled = false;
			GameObject.Find ("CameraRight").GetComponent<fixRiftPosition>().correctBool = false;
			GameObject.Find ("monoCam").camera.enabled = true;
			GameObject.Find ("monoCam").GetComponent<MouseLook>().enabled = true;
			GameObject.Find ("CameraRight").GetComponent<raycast>().enabled = false;
			GameObject.Find ("monoCam").GetComponent<raycast>().enabled = true;
			GameObject.Find ("CameraRight").GetComponent<AudioListener>().enabled = false;
			GameObject.Find ("monoCam").GetComponent<AudioListener>().enabled = true;

			if (Application.loadedLevelName == "birdSceneB 2"){
				GameObject.Find ("guiPlane").GetComponent<animateMat>().useRiftGui = false;}

				}

		if (useMouthController) {
						GameObject.Find ("teethClosedSimpleAnimated3").GetComponent<mouthOpenClose>().usingMouthController = true;

		} else {
			GameObject.Find ("teethClosedSimpleAnimated3").GetComponent<mouthOpenClose>().usingMouthController = false;

				}
		
		//ovrdevice = GameObject.Find(OVRCameraController).GetComponent<OVRDevice>();
		//ovrdevice.ResetOrientation(0);
	
	}
	
	// Update is called once per frame
	void Update () {


	}
}
