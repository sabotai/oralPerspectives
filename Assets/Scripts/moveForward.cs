using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

	bool move = false;
	public GameObject box;
	float idealEdge = 0.246f;
	GameObject camera;

	// Use this for initialization
	void Start () {
		
		if (GameObject.Find("Player 1").GetComponent<useRift>().useOculusRift) {
			camera = GameObject.Find ("OVRCameraController");
			//camera2 = GameObject.Find ("CameraLeft");
		} else {
			camera = GameObject.Find ("monoCam");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.GetComponent<EdgeDetectEffectNormals>().edgesOnly > idealEdge) {
			camera.GetComponent<EdgeDetectEffectNormals>().edgesOnly-= 0.1f * Time.deltaTime;
			//GetComponent<EdgeDetectEffectNormals>().color = 
		}

		Vector3 newPos = transform.localPosition;
		//newPos.z += newPos.z * -1.1f;
		if (newPos.z < 0) {
			newPos.z *= -1.01f;
		} else {
			newPos.z *= 1.01f;
		}

		//Debug.Log (newPos.z);
		if (newPos.z > 3000f) {
			camera.transform.DetachChildren();
				}
		if (newPos.z > 3400f){
			Application.LoadLevel (0);
		}
		//newPos.z = (newPos.z -= newPos.z * 0.01f);
		transform.localPosition = newPos;
		//transform.position = transform.position * Vector3 (0, 0, 0);


		if (move) {
			//Vector3 sup = boxParent.transform.position;
			Vector3 sup = box.transform.localPosition;
			sup.z += 125f;
			//other.gameObject.transform.position = sup;
			box.transform.position = sup;
			move = false;


				}
	}

	void OnTriggerEnter(Collider other) {
		move = true;

		box = other.gameObject;
		Transform boxParent = other.gameObject.transform.parent;
		//Vector3 sup = boxParent.transform.position;
		Vector3 sup = box.transform.localPosition;
		sup.z += 250f;
		//other.gameObject.transform.position = sup;
		box.transform.position = sup;
	}



}
