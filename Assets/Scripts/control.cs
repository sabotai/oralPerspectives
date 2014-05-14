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
	public AudioSource audioToStart4;

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
	GameObject blurryMirror;

	public bool arrivedAtSink;






	public Transform startMarker;
	public Transform endMarker;
	public float walkSpeed = 1.0F;
	public float startTime;
	public float journeyLength;
	public float smooth = 5.0F;
	public GameObject player;
	Vector3 relativeEndMarker, relativeStartMarker;

	public bool autoadvance = true;
	bool advance;

	GameObject obj;

	public float fracJourney;


	// Use this for initialization
	void Start () {
		arrivedAtSink = false;
		blurryMirror = GameObject.Find ("mirrorBlur");
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
			//stepSound.Stop();
			//Debug.Log ("stepSound stopped");
				}

		if (((autoadvance == false) && Input.GetMouseButtonUp (1)) || soundUpdate) {

			if (clickCount == 0) {
				//do sound
				startTime = Time.time;   
				if (!stepSound.isPlaying) {
					stepSound.Play();}

			} else if (clickCount == 2) {
				
				if (!wallThump.isPlaying) {
					wallThump.Play ();}
			} else if (clickCount == 3){        
				if (!shiftSound.isPlaying) {
					shiftSound.Play();
				}
				//shiftSound.Play();
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


		/* // ////////////////////////////////// THIS GOT MOVED TO playerStepBounce
		if (clickCount > 0) {


			if (player.transform.position != endMarker.position){

				//walk forward, only works if you right click first
				float distCovered = (Time.time - startTime) * walkSpeed;
				fracJourney = distCovered / journeyLength;
				player.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);


				float blurSize = Mathf.Lerp (20, 5, fracJourney);
				//Mathf.PingPong(Time.time, 1.0F);

				blurryMirror.GetComponent<Renderer>( ).material.SetFloat("_Size", blurSize);
			}
}
		*/	




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
					StartCoroutine (auto(12));
						} else if (clickCount == 1){
							//Debug.Log ("START ADVANCING 1");
							StartCoroutine (auto(8));
							
					//clickCount = 2;
							
							
						}
				
			}


			if (player.transform.position == endMarker.position) {
				arrivedAtSink = true;
				Debug.Log ("Player arrived at position");

				if (obj.GetComponent<toothBrushMove>().startBrushing == false){
					advance = true;
					//Debug.Log ("FLIPPING SWITCH ON ADVANCE");
				} 
			}



			
		}
	}



	IEnumerator auto(float seconds){
		
		yield return new WaitForSeconds (seconds); 
		//Debug.Log ("BEFORE");

		StartCoroutine(updateAdvance ());

		yield break;

		
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
			audioToStart4.volume = 0.5f - (audioVolDecrease / audioVol);
			
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

