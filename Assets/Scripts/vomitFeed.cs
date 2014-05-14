using UnityEngine;
using System.Collections;

public class vomitFeed : MonoBehaviour {
	//Collider vomitCollider;
	public GameObject[] babybirdObj;
	//GameObject vomitColliderObj;
	public AudioSource pushOffSound;
	
	// Use this for initialization
	void Start () {
		//babybird = GameObject.Find ("babybird").collider;
		//vomitCollider = vomitColliderObj.collider;
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("wut");
		
	}
	
	void OnCollisionEnter(Collision collision){// babybirdz) {
		
		//Debug.Log ("babybird collision");

		for (int i = 0; i < babybirdObj.Length; i++) {
		
						if ((collision.collider == babybirdObj [i].collider)) {
								//Vector3 oldScale = babybirdObj.transform.localScale;

				if ((babybirdObj[2].transform.localScale.x > 1.797) || (babybirdObj[0].transform.localScale.x > 1.847f) || (babybirdObj[1].transform.localScale.x > 1.233f)){// new Vector3(1.847f, 1.847f, 1.847f)) || (babybirdObj[1].transform.localScale > new Vector3(1.233f, 1.233f, 1.233f))){
					
					Rigidbody myBod = GameObject.Find ("OVRCameraController").rigidbody;
					
					if (!pushOffSound.isPlaying) {
						pushOffSound.Play ();}
					myBod.isKinematic = false;
				} else {
								babybirdObj [i].transform.localScale += new Vector3 (0.007F, 0.007f, 0.007f);
			
								//Collider destroyMe = babybirdz.collider;


								Debug.Log ("I just struck " + collision.collider);
			
								Destroy (this.gameObject);//babybirdz.collider);
				}
						}
				}
		
	}
}
