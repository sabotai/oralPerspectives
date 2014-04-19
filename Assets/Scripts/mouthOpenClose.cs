using UnityEngine;
using System.Collections;

public class mouthOpenClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown (KeyCode.Space)) 
		{
			Go ();/*
			audio.Stop ();
			audio.Play();
			animation.Rewind ();
			animation.Play ();*/
		}

		if (Input.GetMouseButton (0)) {
			Debug.Log ("Pressed left click.");
			audio.Stop ();
			audio.Play();
			animation.Rewind ();
			animation.Play ();
				}
		if (Input.GetMouseButtonUp (0)) {
			Debug.Log ("mouseUp");
				}

		if (Input.GetMouseButton(1))
			Debug.Log("Pressed right click.");
	}

	void Go() {
		audio.Stop ();
		audio.Play();
		animation.Rewind ();
		animation.Play ();
	}
}
