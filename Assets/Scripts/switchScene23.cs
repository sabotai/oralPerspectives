using UnityEngine;
using System.Collections;

public class switchScene23 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody myBod = GameObject.Find ("OVRCameraController").rigidbody;

		if (myBod.isKinematic == false){
			StartCoroutine(switch3());
		}
	
	}

	IEnumerator switch3(){
		yield return new WaitForSeconds (5);

		GameObject mouth = GameObject.Find ("teethClosedSimpleAnimated3");
		mouth.GetComponent<mouthOpenClose>().Go ();
		yield return new WaitForSeconds (1);
		//myMouth.Update();
		Application.LoadLevel(2);

	}
}
