using UnityEngine;
using System.Collections;

public class resetMono : MonoBehaviour {

	public GameObject mono = GameObject.Find ("monoCam");

	public GameObject camRight;

	// Use this for initialization
	void Start () {
		GameObject mono = GameObject.Find ("monoCam");
		mono.transform.parent = camRight.transform;// = mono.transform.parent;//.set(0,0,0,0);// = Quaternion.
	
	}
	
	// Update is called once per frame
	void Update () {
		//mono.transform.parent = camRight;//GameObject.Find ("Player 1/OVRCameraController/CameraRight").transform;
		mono.transform.localRotation = new Quaternion (0, 0, 0, 0);
	}
}
