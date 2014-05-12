using UnityEngine;
using System.Collections;

public class bananaMove : MonoBehaviour {

	public Transform[] waypoint;
	public GameObject phallicObj; 
	public GameObject clonePhallicObj;
	public GameObject primaryCam, primaryRiftCam;//, primaryRiftCam2;
	public bool startThrusting;
	public float waySpeed = 5;
	private int currentWaypoint;
	private Vector3 velo;
	private int counter;
	public int howManyCycles;
	private bool started;
	Vector3 tempV;
	bool penetration;
	int penetrationCount;
	public int penetrationLimit = 10;
	GameObject bathroomScene, tongue;
	public GameObject cameraDestination;
	GameObject characterTransform;
	public float howFastAddForce = 135;
	public AudioSource music, thump, orgasmSound, missSound, ouchSound;
	public AudioSource whoosh;

	bool rift;
	bool init = true;
	//Transform characterTransform;
	GameObject mouth;

	// Use this for initialization
	void Start () {	
		tempV = clonePhallicObj.transform.position - phallicObj.transform.position;

		
		characterTransform = GameObject.Find("Player 1/OVRCameraController/CameraRight/monoCam/character");
		bathroomScene = GameObject.Find("bathroomStallHole/bathroom");
		tongue = GameObject.Find ("Player 1/OVRCameraController/CameraRight/monoCam/character/teethClosedSimpleAnimated3");///Zunge_Plane_012");
		mouth = GameObject.Find ("Player 1/OVRCameraController/CameraRight/monoCam/character/teethClosedSimpleAnimated3");

		if (GameObject.Find ("Player 1").GetComponent<useRift> ().useOculusRift) {

						rift = true;
				} else {
			rift = false;}


		
	
	}
	
	// Update is called once per frame
	void Update () {

		if (init) {
			StartCoroutine (auto(1));
		} else {
			//if (thump.isPlaying){
			//	thump.Pause ();}
			if (audio.isPlaying && audio.time > 0.25f) { //stop kitten from squeeling too long
			audio.Pause ();
		}
		

						if (startThrusting && counter <= howManyCycles) {

								started = true;
			
								if (currentWaypoint < waypoint.Length) {
										//Debug.Log ("current toothbrush waypoint = " + currentWaypoint);
										Vector3 target = waypoint [currentWaypoint].position;
										Vector3 moveDirection = target - phallicObj.transform.position;
										velo = phallicObj.rigidbody.velocity;
				
										if (moveDirection.magnitude < 0.2f) {
												currentWaypoint++;



										} else {
												velo = moveDirection.normalized * waySpeed;
										}
								} else {
										currentWaypoint = 1;
										waySpeed *= 1.2f;
										counter += 1;
								}

								if (currentWaypoint == 1) {
					
					if (!whoosh.isPlaying){
						whoosh.Play();
					} else {
						whoosh.pitch *= 1.01f;
					}
										//Debug.Log ("OHHHH YEAHHH");
										// POSSIBLY ADD INTO CONDITIONAL A BOOLEAN FOR STRIKING THE TRIGGER BOX IN THE MOUTH

										if (penetration) {
											if (!audio.isPlaying){
							audio.Play ();}
												// INSERT CUTE YEAHHH SOUND 

												// INCREASE COUNT APPROACHING 'ORGASM' 
												// UPON ORGASM, TURN ON CAMERA COLLIDER AND DEPARENT EVERYTHING FROM IT AND TURN OFF RIGIDBODY-KINEMATIC
												// MAYBE 2 CAMERA COLLIDERS/RIGIDBODIES

					} else {
						Debug.Log ("play miss sound");
						if (!missSound.isPlaying){
							missSound.Play ();}
						// INSERT CUTE SAD SOUND
										}
								} else {
										//audio.Pause ();
								}

								clonePhallicObj.transform.position = phallicObj.transform.position + tempV;//new Vector3(0,0,tempZ);
								phallicObj.rigidbody.velocity = velo;
								//Vector3 oldTransform = clonePhallicObj.transform.position;
								//clonePhallicObj.transform.position.x = temp;
						
								//clonePhallicObj.rigidbody.velocity = velo;			
								//Debug.Log ("thrust " + currentWaypoint);


								//if (

								if (penetrationCount >= penetrationLimit) {
										//orgasm
										GameObject temp = GameObject.Find("musicSound");
										if ((music.volume < 0.6f) && (!temp.GetComponent<soundTrigger>().goGoGo)) {
												music.volume += (0.02f * Time.deltaTime);
										}
										//music.Play ();
										//Debug.Log (Time.deltaTime);
				
				
								}
			
						}
				}
		
 //phallicObj.transform.position + (oldTransform - phallicObj.transform.position);// + (oldTransform - phallicObj.transform.position); 
	
		
		if (ouchSound.isPlaying && ouchSound.time > 2) { //stop kitten from squeeling too long
						ouchSound.Stop ();
				}

	}

	void OnTriggerEnter(Collider other){


		if (other.name == "mouthContactTrigger") {
			//thump.Play();
			penetration = true;
			penetrationCount++;
			Debug.Log ("penetrate!");
				} else {
			penetration = false;
			
			Debug.Log ("no penetrate");
				}

		if (penetrationCount == penetrationLimit){
			//orgasm
			orgasmSound.Play ();
			Orgasm ();

		}



	}
	void OnCollisionEnter(Collision other){		
		//if (other.name != "mouthContactTrigger") {

		//}
		
	}

	void OnTriggerStay(Collider other){		
				if (other.name == "mouthContactTrigger") {
						if (!thump.isPlaying) {
								thump.Play ();
						}
				}

				if (mouth.GetComponent<mouthOpenClose> ().biting) {
						if (!ouchSound.isPlaying) {
								ouchSound.Play ();
				Debug.Log ("OUCH");
						}
				}
		}

		void Orgasm() {
		if (GameObject.Find ("Player 1").GetComponent<useRift> ().useOculusRift) {
			
			rift = true;
		} else {
			rift = false;}

		if (rift){
			primaryRiftCam.collider.enabled = true;
			//primaryRiftCam.rigidbody.enabled = true;
			primaryCam.collider.enabled = false;
			Destroy(primaryCam.rigidbody);


			primaryRiftCam.rigidbody.isKinematic = false;
			primaryRiftCam.rigidbody.AddForce (howFastAddForce * (cameraDestination.transform.position - primaryCam.transform.position));
			Debug.Log ("rift orgasm");
		} else {
			primaryRiftCam.collider.enabled = false;
			primaryCam.collider.enabled = true;
			//primaryCam.rigidbody.enabled = true;
			
			Destroy(primaryRiftCam.rigidbody);


			primaryCam.rigidbody.isKinematic = false;
			
			primaryCam.rigidbody.AddForce (howFastAddForce * (cameraDestination.transform.position - primaryCam.transform.position));
			Debug.Log ("monoCam orgasm");
			
		}


		Debug.Log ("Orgasm triggered");
		primaryCam.transform.parent = null;
		characterTransform.transform.parent = null;
		primaryCam.transform.DetachChildren();




		Destroy (bathroomScene);
		Destroy (tongue);
		

		
		
		//pushOffSound.Play ();
		//trigger orgasm sound

		//rigidbody no longer kinetic for monocam, cameraright, cameraleft

		//turn off mouseLook on monocam

		//StartCoroutine(WaitInStomach());


	}

	
	IEnumerator auto(float seconds){
		
		yield return new WaitForSeconds (seconds); 
		//Debug.Log ("BEFORE");
		
		StartCoroutine(updateAdvance ());
		
		yield break;
		
		
	}
	
	IEnumerator updateAdvance(){
		
		
		init = false;
		
		yield return 0;
		StopAllCoroutines ();
		yield break;
		
	}
}

