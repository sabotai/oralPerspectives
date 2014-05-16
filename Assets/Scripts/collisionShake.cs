using UnityEngine;
using System.Collections;

public class collisionShake : MonoBehaviour {


	float duration = 0.25f;
	float magnitude = 0.01f;
	bool shaking;
	GameObject whichCam;
	public AudioClip collisionSound;

	// Use this for initialization
	void Start () {

		if (Application.loadedLevel == 1) {
						if (GameObject.Find ("Player").GetComponent<useRift> ().useOculusRift) {
								whichCam = GameObject.Find ("OVRCameraController");
						} else {
								whichCam = GameObject.Find ("monoCam");
						}
		} else if (Application.loadedLevel == 2) {
			if (GameObject.Find ("Player 1").GetComponent<useRift> ().useOculusRift) {
				whichCam = GameObject.Find ("OVRCameraController");
			} else {
				whichCam = GameObject.Find ("monoCam");
			}

				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if ((collision.collider.name == "bananaLarge") || (collision.collider.name == "toothbrushParticleCollider")) {
			//Debug.Log ("some collision");
			audio.PlayOneShot (collisionSound);
					if (!shaking){
						StartCoroutine (Shake ());
						shaking = true;
					}
				}
		}

	IEnumerator Shake() {
		
		Debug.Log ("shake cam");

		float elapsed = 0.0f;
		
		Vector3 originalCamPos = whichCam.transform.position;//GameObject.Find ("Player 1").transform.position;//Camera.main.transform.position;
		
		while (elapsed < duration) {
			originalCamPos.z = whichCam.transform.position.z;//GameObject.Find ("Player 1").transform.position.z;
			
			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
			
			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;

			//whichCam.transform.position = new Vector3(x, y, originalCamPos.z);
			//Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);
			//GameObject.Find ("Player 1").transform.position = new Vector3(x + originalCamPos.x, y + originalCamPos.y, originalCamPos.z);
			whichCam.transform.position = new Vector3(x + originalCamPos.x, y + originalCamPos.y, originalCamPos.z);

			yield return null;
		}
		
		//Camera.main.transform.position = originalCamPos;
		//GameObject.Find ("Player 1").transform.position = originalCamPos;
		whichCam.transform.position = originalCamPos;
		shaking = false;
	}
}