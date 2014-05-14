using UnityEngine;
using System.Collections;

public class collisionSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if ((other.collider.name == "digestiveFlip3") || (other.collider.name == "SphereColliderDigestive")|| (other.collider.name == "Sphere") ){
			audio.pitch = 1 - (Random.value * 0.3f);
						audio.Play ();
						Debug.Log ("boom");

				}
		if (other.collider.name == "bananaLarge") {
			//audio.Play ();
				}

	}

}
