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

	public AudioSource elevatorSound;

	public AudioSource stepSound;

	bool begin;
	int stepCount;
	public int clickCount;
	float audioVol;
	float originalVol, originalVol2;
	bool first;
	public bool soundUpdate;






	public Transform startMarker;
	public Transform endMarker;
	public float walkSpeed = 1.0F;
	private float startTime;
	private float journeyLength;
	public float smooth = 5.0F;
	public GameObject player;
	Vector3 relativeEndMarker, relativeStartMarker;

	public bool autoadvance = true;
	bool advance;

	GameObject obj;



	// Use this for initialization
	void Start () {
		//float upTransform = 11.5;
		begin = false;
		destination = Random.insideUnitSphere * 100f;
		clickCount = 0;
		audioVol = playerTarget.transform.position.y - destinationPosition.transform.position.y;


		originalVol = audioToStop1.volume;
		originalVol2 = audioToStop2.volume;
		//Debug.Log (originalVol);
		
		startTime = Time.time;

		


		relativeEndMarker = startMarker.InverseTransformDirection(endMarker.transform.position);
		relativeStartMarker = player.transform.InverseTransformDirection(startMarker.transform.position);
		//Debug.Log ("relativeEndMarker = " + relativeEndMarker);


		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

		player.transform.position = startMarker.position;


		if (autoadvance) {
			advance = true;
				}

		obj = GameObject.Find("toothbrush2");
		
	}

	void Update() {
		//float step = speed * Time.deltaTime;
		//Debug.Log("clickCount is " + clickCount);
		//advance = true;
		
		if (player.transform.position == endMarker.position) {
			stepSound.Stop();
				}

		if (((autoadvance == false) && Input.GetMouseButtonUp (1)) || soundUpdate) {

			if (clickCount == 0) {
				//do sound
				startTime = Time.time;
				stepSound.Play();

			} else if (clickCount == 2) {
				wallThump.Play ();
			} else if (clickCount == 3){
				shiftSound.Play();
			}

			//GetComponent<Rigidbody> ().AddForce (new Vector3 (1f,10f, 0f));
			//GetComponent<Rigidbody> ().AddForce (transform.up * 15f);//, ForceMode.Acceleration);
			//rigidbody.Addforce.... <-shortcut
			//transform.rotation = Quaternion.FromToRotation(Vector3.up, transform.forward);

			
			//transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
			//light.rotation = Quaternion.RotateTowards(transform.rotation, lightTarget.rotation, step);

			clickCount++;
			soundUpdate = false;

		}		
		if (clickCount > 0) {

			

			//walk forward, only works if you right click first
			float distCovered = (Time.time - startTime) * walkSpeed;
			float fracJourney = distCovered / journeyLength;
			player.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);




		}		
		if (clickCount == 2) {
			//Debug.Log ("toothbrush is moving");

			//bool isBrushing = GetComponent(toothBrushMove);
			//toothBrushMove.main.isBrushing = true;


			obj.GetComponent<toothBrushMove>().startBrushing=true;
		}
		
		if (clickCount == 3) {
			//Debug.Log ("wall should be moving");
			//soundUpdate = true;
			
			breakaway1.rigidbody.AddForce (Vector3.Normalize (destination - sceneTarget.transform.position));
			breakaway1.rigidbody.isKinematic = false;
			StartCoroutine (waitElevator());
		}

		if (clickCount == 4) {
			//Debug.Log ("wall should be moving");

			breakaway1.rigidbody.AddForce (Vector3.Normalize (destination - sceneTarget.transform.position));
			breakaway1.rigidbody.isKinematic = false;
			elevatorSound.Play();
			clickCount = 5;
		}
		if (clickCount >= 4) {
			//Debug.Log ("scene1 should be moving");
			//shiftSound.Play();
			//VIBRATE AS IT GOES DOWN
			//soundUpdate = true;
			//audio.PlayOneShot (elevatorSound, 0.8f);

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
		if (autoadvance) {
			/*else {
					advance = false;
				}

*/
			/*if ((clickCount == 1) && (soundUpdate == false)){
				advance = true;
			}*/
			
			soundUpdate = false;
			
			if (advance) {
							if (clickCount < 1){
								//Debug.Log ("START ADVANCING 0");
					StartCoroutine (auto(5));
						} else if (clickCount == 1){
							//Debug.Log ("START ADVANCING 1");
							StartCoroutine (auto(3));
							
					//clickCount = 2;
							
							
						}
				
			}


			if (player.transform.position == endMarker.position) {
				
				if (obj.GetComponent<toothBrushMove>().startBrushing == false){
					advance = true;
					//Debug.Log ("FLIPPING SWITCH ON ADVANCE");
				} 
			}



			
		}
	}

	/*using UnityEngine;
	using System.Collections;
	
	public class ballFeel : MonoBehaviour {
		
		public Transform ball1, ball2; //assign in inspector
		
		// Use this for initialization
		void Start () {
			// BallSwap(); //DO NOT DO THIS
			StartCoroutine (BallSwap ()); //if you put it in update, it will create new coroutines going in parallel each time update runs
			
		}
		
		IEnumerator BallSwap () {
			Debug.Log ("the coroutine started!");
			yield return 0; // wait a frame, must be 0 -- cant wait 3 frames with yield return 3
			Debug.Log ("one frame elapsed");
			yield return 0;
			yield return null; // wait 2 frames
			Debug.Log ("2 additional frame elapsed!");
			yield return new WaitForSeconds( 2.0f ); //better way of doing this, automatically calculate the frames per second
			Debug.Log ("2 seconds elapsed");
			
			
			while (true) { //ok to use infinite loop, because we will take it to break after it
				float time = 0f;
				Vector3 originalBall1Pos = ball1.position;
				Vector3 originalBall2Pos = ball2.position;
				
				while (time < 1f) {
					time += Time.deltaTime;
					ball1.position = Vector3.Lerp (originalBall1Pos, originalBall2Pos, time); //Lerp = linear interpolation
					ball2.position = Vector3.Lerp (originalBall2Pos, originalBall1Pos, time);
					
					if (time > 0.49f && time < 0.51f){ 
						audio.Play ();
						StartCoroutine (ScreenShake ());
					}
					
					yield return 0; //wait a frame
				}
				
			}
		}
		
		IEnumerator ScreenShake() {
			float time = 0.3f;
			Vector3 originalCamPosition = Camera.main.transform.position;
			
			while (time > 0f) {
				time -= Time.deltaTime;
				Camera.main.transform.position = //Camera.main.transform.position
					originalCamPosition
						+ Vector3.right * Mathf.Sin (Time.time * 113f) * time; 
				
				
				
				yield return 0;
			}
			Camera.main.transform.position = originalCamPosition;
		}
	}
	*/

	IEnumerator auto(float seconds){
		
		yield return new WaitForSeconds (seconds); 
		//Debug.Log ("BEFORE");

		StartCoroutine(updateAdvance ());

		yield break;

		/*
		if (clickCount < 1) {
						yield return new WaitForSeconds (seconds); // initial wait for 10 seconds}
						updateAdvance ();
			Debug.Log ("clickCount<1 in coroutine = " + clickCount);
			yield break;
			
		} 
				if ((clickCount == 1)){// && (advance == true)) {
						yield return new WaitForSeconds (seconds); // initial wait for 10 seconds}
						//soundUpdate = true;
						updateAdvance ();
						Debug.Log ("clickCount==1 in coroutine = " + clickCount);
						yield break;
				} 

				
		Debug.Log ("YOU ARE IN AUTO COROUTINE");
		yield break;
		
		
		*/
		
	}

	IEnumerator updateAdvance(){


						advance = false;
		if (clickCount < 2) {
			//Debug.Log ("AFTER");
			soundUpdate = true;
				
						}
			yield return 0;
		StopAllCoroutines ();
		yield break;

		}


		/*
	IEnumerator updateAdvance(){
		Debug.Log ("YOU ARE IN UPDATEADVANCE COROUTINE");
		soundUpdate = true;
				
		yield break;
		yield return 0;

		}
		*/

	IEnumerator waitElevator() {

		//clickCount++;
		yield return new WaitForSeconds (2);

		//yield return clickCount;
		//Update ();
		StartCoroutine (waitElevator2 ());
		//vibrate ();

		}
	IEnumerator waitElevator2(){
		soundUpdate = true;
		yield return soundUpdate;

		}

	IEnumerator vibrate() {



		if (destinationPosition.transform.position.y < playerTarget.transform.position.y) {
						//Debug.Log ("user should be moving");
						//sceneTarget.transform.position.y -= 1 ;
						Vector3 newPosition2 = playerTarget.transform.position;
						newPosition2.y -= speed * Time.deltaTime;
						//Debug.Log (newPosition2.y);
			
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
				} else {
			
					GameObject startMic = GameObject.Find ("AudioInputObject");
					startMic.GetComponent<SpawnByLoudness> ().useMicrophone = true;
		}
		


		float time = 0.018f; //was 0.05f
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

		StopAllCoroutines ();
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