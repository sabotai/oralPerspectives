using UnityEngine;
using System.Collections;

public class secondaryAction : MonoBehaviour {

	public GameObject vomitObject;
	public Transform vomitOrigin;
	public AudioSource vomitSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.V)) {
						//Debug.Log ("instantiating new vomit");
			Vomit ();
				} else {
			//vomitSound.Stop ();
				}
	}

	public void Vomit(){
		
		for (int i = 0; i < 3; i++) {
			GameObject clone;
			clone = Instantiate (vomitObject, vomitOrigin.transform.position, vomitOrigin.transform.rotation) as GameObject;
			//clone.transform.localScale = vomitObject.transform.localScale;
			//clone.transform.rotation = vomitOrigin.transform.localRotation;
			clone.rigidbody.velocity = vomitOrigin.transform.TransformDirection(Vector3.forward * (3+i));// * 8 * i);
			
			//clone.rigidbody.mass = 1;
			//clone.rigidbody.velocity = vomitOrigin.transform.TransformDirection(Vector3.forward);
		}
		vomitSound.Play ();


	}
}
