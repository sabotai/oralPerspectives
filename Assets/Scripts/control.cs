using UnityEngine;
using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {

	//public Transform mouth;
	public float speed;
	public Transform target;
	public Transform lightTarget;
	public Transform light;

	bool begin;

	// Use this for initialization
	void Start () {
		//float upTransform = 11.5;
		begin = false;
		
	}

	void Update() {
		float step = speed * Time.deltaTime;

		if ( Input.GetKey (KeyCode.Space)) 
		{
			//GetComponent<Rigidbody> ().AddForce (new Vector3 (1f,10f, 0f));
			//GetComponent<Rigidbody> ().AddForce (transform.up * 15f);//, ForceMode.Acceleration);
			//rigidbody.Addforce.... <-shortcut
			//transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);

			
			transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
			light.rotation = Quaternion.RotateTowards(transform.rotation, lightTarget.rotation, step);

			//transform.position = Quaternion.RotateTowards(transform.position, target.position, step);
			begin = true;
		}

		if (begin) {

				}

	}


}


	/*
	// Update is called once per frame ---- FixedUpdate is called every ___ seconds
	void FixedUpdate () {


		if ( Input.GetKey (KeyCode.Space)) 
		{
			//GetComponent<Rigidbody> ().AddForce (new Vector3 (1f,10f, 0f));
			//GetComponent<Rigidbody> ().AddForce (transform.up * 15f);//, ForceMode.Acceleration);
			//rigidbody.Addforce.... <-shortcut
			//transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);
			Quaternion.RotateTowards(transform.rotation, transform.down, step)
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			rigidbody.AddForce (transform.forward * 15f);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			rigidbody.AddForce (-transform.right * 15f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			rigidbody.AddForce (transform.right * 15f);
		}
	}
}


*/