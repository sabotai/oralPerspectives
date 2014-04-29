using UnityEngine;
using System.Collections;

public class feedChicks : MonoBehaviour {
	Collider babybirdz;
	public GameObject babybirdObj;
	public GameObject vomitColliderObj;

	// Use this for initialization
	void Start () {
		//babybird = GameObject.Find ("babybird").collider;
		babybirdz = babybirdObj.collider;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("wut");
	
	}

	void OnCollisionEnter(Collision babybirdz){// babybirdz) {

		//Debug.Log ("babybird collision");

		if (babybirdz.collider == vomitColliderObj.collider){
			Vector3 oldScale = babybirdObj.transform.localScale;
			babybirdObj.transform.localScale += new Vector3 (0.001F, 0.001f, 0.001f);

			Collider destroyMe = babybirdz.collider;

			Destroy (destroyMe);//babybirdz.collider);
			Debug.Log("I just destroyed " + babybirdz.collider);
		}

		}
}
