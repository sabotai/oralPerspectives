using UnityEngine;
using System.Collections;
using System.Reflection;

public class mouthOpenClose : MonoBehaviour {

	public bool usingMouthController = false;
	public bool biting;
	public GameObject monoCam, cameraLeft, cameraRight;
	float origFocal;

	// Use this for initialization
	void Start () {
		
		origFocal = monoCam.GetComponent <DepthOfFieldScatter> ().focalLength;
	
	}
	
	// Update is called once per frame
	void Update () {

				if (usingMouthController) {

						if (Input.GetKeyDown (KeyCode.X)) {
								Debug.Log ("Pressed X.");
								biting = false;
						} else {

								animation["Default Take"].speed = 1.5f;
								biting = true;
								audio.Stop ();
								audio.Play ();
								animation.Rewind ();
								animation.Play ();

						}

				} else {
		

						if (Input.GetMouseButton (0)) {
				//Debug.Log ("Pressed left click.");
				animation["Default Take"].speed = 1.5f;
				audio.Stop ();
								audio.Play ();
								animation.Rewind ();
								animation.Play ();
								biting = true;
						} else {
								biting = false;
			}
				}

		if (biting) {
						//change focal distance
						//monoCam.GetComponent<DepthOfFieldScatter>().focusOnTransform = GameObject.Find ("bird2Vomit");
			//Camera.main.GetComponent <DepthOfFieldScatter>().focusOnThis = GameObject.Find ("bird2Vomit").transform;
			monoCam.GetComponent <DepthOfFieldScatter> ().focalLength = 0.6f;
			cameraLeft.GetComponent <DepthOfFieldScatter> ().focalLength = 0.6f;
			cameraRight.GetComponent <DepthOfFieldScatter> ().focalLength = 0.6f;


						/*
			Component dofs = Camera.main.GetComponent <DepthOfFieldScatter>();
			FieldInfo fi = dofs.GetType().GetField("focalLength");
			fi.SetValue(dofs, 99.0f);
		*/
		} else {
			monoCam.GetComponent <DepthOfFieldScatter> ().focalLength = origFocal;
			cameraLeft.GetComponent <DepthOfFieldScatter> ().focalLength = origFocal;
			cameraRight.GetComponent <DepthOfFieldScatter> ().focalLength = origFocal;

				}
		}

	public void Go() {
		biting = true;
		audio.Stop ();
		audio.Play();
		animation.Rewind ();
		animation.Play ();
	}
}
