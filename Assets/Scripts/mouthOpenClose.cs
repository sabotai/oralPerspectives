using UnityEngine;
using System.Collections;

public class mouthOpenClose : MonoBehaviour {

	public bool usingMouthController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

				if (usingMouthController) {

						if (Input.GetKeyDown (KeyCode.X)) {
								Debug.Log ("Pressed X.");
						} else {
								audio.Stop ();
								audio.Play ();
								animation.Rewind ();
								animation.Play ();

						}

				} else {
		

						if (Input.GetMouseButton (0)) {
								Debug.Log ("Pressed left click.");
								audio.Stop ();
								audio.Play ();
								animation.Rewind ();
								animation.Play ();
						}
						if (Input.GetMouseButtonUp (0)) {
								Debug.Log ("mouseUp");
						}

						if (Input.GetMouseButton (1)){
								Debug.Log ("Pressed right click.");
			}
				}
		}

	void Go() {
		audio.Stop ();
		audio.Play();
		animation.Rewind ();
		animation.Play ();
	}
}
