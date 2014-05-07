using UnityEngine;
using System.Collections;

public class mouthOpenClose : MonoBehaviour {

	public bool usingMouthController = false;
	public bool biting;

	// Use this for initialization
	void Start () {

	
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
		}

	public void Go() {
		biting = true;
		audio.Stop ();
		audio.Play();
		animation.Rewind ();
		animation.Play ();
	}
}
