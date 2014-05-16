using UnityEngine;
using System.Collections;

public class secondaryAction : MonoBehaviour {

	public GameObject vomitObject;
	public Transform vomitOrigin;
	public AudioSource vomitSound;
	bool switchy;
	int count;
	GameObject bathroom;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevel == 1){
			bathroom = GameObject.Find ("bathroomScene");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.loadedLevel == 1) { // only have vomit controls in level one
						if (bathroom.GetComponent <control> ().scene2) {
								if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
										Vomit ();


								}


								if (Input.GetKey (KeyCode.V)) {
										//Debug.Log ("instantiating new vomit");
										Vomit ();
								}
						}
				}
	}

	public void Vomit(){

		
		if (Application.loadedLevelName != ("gloryHole")) {
						for (int i = 0; i < 3; i++) {
								GameObject clone;
								clone = Instantiate (vomitObject, vomitOrigin.transform.position, vomitOrigin.transform.rotation) as GameObject;
								//clone.transform.localScale = vomitObject.transform.localScale;
								//clone.transform.rotation = vomitOrigin.transform.localRotation;

								clone.rigidbody.velocity = vomitOrigin.transform.TransformDirection (Vector3.forward * (3 + i));// * 8 * i);
			
								//clone.rigidbody.mass = 1;
								//clone.rigidbody.velocity = vomitOrigin.transform.TransformDirection(Vector3.forward);
						}
				} else {
						GameObject clone;

						if (count % 2 == 0) {	
										clone = Instantiate (vomitObject, vomitOrigin.transform.position, vomitOrigin.transform.rotation) as GameObject;
										clone.rigidbody.velocity = vomitOrigin.transform.TransformDirection (Vector3.down * (Time.deltaTime * (2 * Time.time)));// * 8 * i);
										count+= count;
				//Debug.Log ("vomit " + Time.time);
										//clone.rigidbody.velocity = vomitOrigin.transform.TransformDirection (Vector3.back * (2 * Time.time));// * 8 * i);

						
						}
				}


		
		if (!vomitSound.isPlaying) {
						vomitSound.Play ();
				} else {
					if (vomitSound.time > 0.1f){
				vomitSound.Stop ();
			}
				}
		Debug.Log (vomitSound.isPlaying + " vomit sound");

	}
}
