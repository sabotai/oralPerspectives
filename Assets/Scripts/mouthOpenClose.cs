using UnityEngine;
using System.Collections;

public class mouthOpenClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKey (KeyCode.Space)) 
		{
			audio.Stop ();
			animation.Rewind ();
			animation.Play ();
			audio.Play();
		}

		if (Input.GetMouseButton (0)) {
						Debug.Log ("Pressed left click.");
						animation.Rewind ();
						animation.Play ();
						audio.Play ();
				}

		if (Input.GetMouseButton(1))
			Debug.Log("Pressed right click.");
	}
}
