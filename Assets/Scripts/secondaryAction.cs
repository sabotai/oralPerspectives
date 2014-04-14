using UnityEngine;
using System.Collections;

public class secondaryAction : MonoBehaviour {

	public GameObject vomitObject;
	public Transform vomitOrigin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ( Input.GetKey (KeyCode.V)) {
			Debug.Log ("instantiating new vomit");

			for (int i = 0; i < 3; i++){
				GameObject clone;
				clone = Instantiate(vomitObject, vomitOrigin.transform.position, vomitObject.transform.rotation) as GameObject;
				//clone.transform.localScale = vomitObject.transform.localScale;
				clone.rigidbody.velocity = vomitOrigin.transform.TransformDirection(Vector3.forward * 5 *i);
			}
		}
	}
}
