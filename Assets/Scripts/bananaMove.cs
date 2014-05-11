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
	public AudioSource music, thump, orgasmSound;

	bool rift;
	//Transform characterTransform;


	// Use this for initialization
	void Start () {	
		tempV = clonePhallicObj.transform.position - phallicObj.transform.position;

		
		characterTransform = GameObject.Find("Player 1/OVRCameraController/CameraRight/monoCam/character");
		bathroomScene = GameObject.Find("bathroomStallHole/bathroom");
		tongue = GameObject.Find ("Player 1/OVRCameraController/CameraRight/monoCam/character/teethClosedSimpleAnimated3");///Zunge_Plane_012");

		if (GameObject.Find ("Player 1").GetComponent<useRift> ().useOculusRift) {

						rift = true;
				} else {
			rift = false;}


		
	
	}
	
	// Update is called once per frame
	void Update () {

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

			if (currentWaypoint == 1){
				//Debug.Log ("OHHHH YEAHHH");
				// POSSIBLY ADD INTO CONDITIONAL A BOOLEAN FOR STRIKING THE TRIGGER BOX IN THE MOUTH

				if (penetration){
					audio.Pause ();
					audio.Play ();
					// INSERT CUTE YEAHHH SOUND 

					// INCREASE COUNT APPROACHING 'ORGASM' 
					// UPON ORGASM, TURN ON CAMERA COLLIDER AND DEPARENT EVERYTHING FROM IT AND TURN OFF RIGIDBODY-KINEMATIC
					// MAYBE 2 CAMERA COLLIDERS/RIGIDBODIES

				} else {
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

			if (penetrationCount >= penetrationLimit){
				//orgasm
				
				if (music.volume < 0.6f){
					music.volume += (0.1f * Time.deltaTime);
				}
				//music.Play ();
				//Debug.Log (Time.deltaTime);
				
				
			}
			
		}
		
 //phallicObj.transform.position + (oldTransform - phallicObj.transform.position);// + (oldTransform - phallicObj.transform.position); 
	
	}

	void OnTriggerEnter(Collider other){


		if (other.name == "mouthContactTrigger") {
			thump.Play();
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


			/*
			if (music.volume < 0.6f){
				music.volume += 0.1f;
			}*/
			//music.Play ();
			//Debug.Log (music.volume);


		}



	}

		void Orgasm() {
		if (rift){
			primaryRiftCam.collider.enabled = true;
			//primaryRiftCam.rigidbody.enabled = true;
			primaryCam.collider.enabled = false;
			Destroy(primaryCam.rigidbody);


			primaryRiftCam.rigidbody.isKinematic = false;
			primaryRiftCam.rigidbody.AddForce (howFastAddForce * (cameraDestination.transform.position - primaryCam.transform.position));
		} else {
			primaryRiftCam.collider.enabled = false;
			primaryCam.collider.enabled = true;
			//primaryCam.rigidbody.enabled = true;
			
			Destroy(primaryRiftCam.rigidbody);


			primaryCam.rigidbody.isKinematic = false;
			
			primaryCam.rigidbody.AddForce (howFastAddForce * (cameraDestination.transform.position - primaryCam.transform.position));
			
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
}
