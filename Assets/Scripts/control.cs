using UnityEngine;
using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {

	//public Transform mouth;
	public float speed;
	//public Transform sceneTarget;
	//public Rigidbody sceneTargetAgain;
	//public Transform target2;
	//public Transform destinationTransform;
	Vector3 destination;

	public GameObject sceneTarget;
	public GameObject playerTarget;
	public GameObject destinationPosition;

	public GameObject breakaway1;
	public GameObject breakaway2;


	public AudioSource audioToStop1;
	public AudioSource audioToStop2;
	public AudioSource audioToStart;
	public AudioSource audioToStart2;
	public AudioSource audioToStart3;

	public AudioSource wallThump;
	public AudioSource shiftSound;

	bool begin;
	int clickCount;
	float audioVol;
	float originalVol, originalVol2;

	// Use this for initialization
	void Start () {
		//float upTransform = 11.5;
		begin = false;
		destination = Random.insideUnitSphere * 100f;
		clickCount = 0;
		audioVol = playerTarget.transform.position.y - destinationPosition.transform.position.y;


		originalVol = audioToStop1.volume;
		originalVol2 = audioToStop2.volume;
		Debug.Log (originalVol);


		
	}

	void Update() {
		float step = speed * Time.deltaTime;


		if (Input.GetMouseButtonDown(1)) 
		{
			if (clickCount == 0) {
				wallThump.Play ();
			} else if (clickCount == 1){
				shiftSound.Play();
			}

			//GetComponent<Rigidbody> ().AddForce (new Vector3 (1f,10f, 0f));
			//GetComponent<Rigidbody> ().AddForce (transform.up * 15f);//, ForceMode.Acceleration);
			//rigidbody.Addforce.... <-shortcut
			//transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);

			
			//transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
			//light.rotation = Quaternion.RotateTowards(transform.rotation, lightTarget.rotation, step);

			clickCount++;
			Debug.Log("clickCount is " + clickCount);

		}

		if (clickCount == 1) {
			//Debug.Log ("wall should be moving");

			breakaway1.rigidbody.AddForce (Vector3.Normalize (destination - sceneTarget.transform.position));
			breakaway1.rigidbody.isKinematic = false;
		}
		if (clickCount >= 2) {
			//Debug.Log ("scene1 should be moving");
			//shiftSound.Play();

			//VIBRATE AS IT GOES DOWN
			StartCoroutine (vibrate());

			







		}

		/*
		if (clickCount == 3) {
			Debug.Log ("floor should be moving");
			breakaway2.rigidbody.AddForce (Vector3.Normalize (destination - sceneTarget.transform.position));
			breakaway2.rigidbody.isKinematic = false;
		}

		*/
		
		//audioToStop1.Stop();
	}

	IEnumerator vibrate() {


		if (destinationPosition.transform.position.y < playerTarget.transform.position.y) {
			//Debug.Log ("user should be moving");
			//sceneTarget.transform.position.y -= 1 ;
			Vector3 newPosition2 = playerTarget.transform.position;
			newPosition2.y -= speed * Time.deltaTime;
			Debug.Log (newPosition2.y);
			
			playerTarget.transform.position = newPosition2;
			
			float audioVolDecrease = playerTarget.transform.position.y - destinationPosition.transform.position.y;	
			
			//audioToStop1.volume -= speed * Time.deltaTime;
			audioToStop1.volume = (audioVolDecrease / audioVol) * originalVol;
			audioToStop2.volume = (audioVolDecrease / audioVol) * originalVol2;
			audioToStart.volume = 0.5f - (audioVolDecrease / audioVol);
			audioToStart2.volume = 0.5f - (audioVolDecrease / audioVol);
			audioToStart3.volume = 0.5f - (audioVolDecrease / audioVol);
			
			//Debug.Log ("chick volume = " + audioToStart.volume);
			//Debug.Log ("scene volume = " + audioToStop1.volume);
			//yield return 0;
		}



		float time = 0.05f;
		Vector3 originalPosition = sceneTarget.transform.position;

		while (time > 0f) {
			time -= Time.deltaTime;









			sceneTarget.transform.position = originalPosition + Vector3.right * Mathf.Sin (Time.time * 113f) * time; 
			
			Vector3 newPosition = sceneTarget.transform.position;
			newPosition.y -= speed * Time.deltaTime;
			
			sceneTarget.transform.position = newPosition;


			originalPosition = sceneTarget.transform.position;





			
			yield return 0;
		}
		//sceneTarget.transform.position = originalPosition;
		//audio.Stop ();
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

using UnityEngine;
using System.Collections;

public class fishActorScript : MonoBehaviour {

	public Vector3 destination;


	//one idea is to use this for the sun and the moon
	// Use this for initialization
	void Start () {
		InvokeRepeating ("RandomizeDestination", 0f, 3f); //after 1 second, it will randomize destination every 10 seconds
	
	}
	
	void RandomizeDesination(){
		
			destination = Random.insideUnitSphere * 100f; //if you see "unit," it = 1; unit sphere is circle with radius of 1

		}


	// Update is called once per frame
	void FixedUpdate () { //using fixedupdate because it will do some physics
		rigidbody.AddForce (Vector3.Normalize (destination - transform.position));
		
	}

	void Update () {
		transform.rotation = Quaternion.LookRotation (rigidbody.velocity); // look rotation rigidbody velocity turns the fish to look towards destination

*/