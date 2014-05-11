using UnityEngine;
using System.Collections;

public class playerStepBounce : MonoBehaviour {

	private GameObject bathroom;
	private float time;
	public float speed;
	bool doneBouncing = true;
	float totalTime;
	Vector3 originalPosition;



	public Transform startMarker, endMarker;
	float journeyLength;
	float walkSpeed = 1;
	float fracJourney;
	GameObject blurryMirror;
	//float startTime;

	Vector3 tempTransform;

	// Use this for initialization
	void Start () {
		bathroom = GameObject.Find ("bathroomScene");
		blurryMirror = GameObject.Find ("mirrorBlur");
		transform.position = startMarker.position;
		//bounceSetup ();

		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

		//startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

				//find when /3 distance travelled
				int stepSize = 3;
				//int temp = (int)(10f * ((bathroom.GetComponent<control> ().journeyLength / stepSize) % bathroom.GetComponent<control> ().fracJourney));
		int temp = (int)(10f * ((journeyLength / stepSize) % fracJourney));
				//Debug.Log (temp);

				if (bathroom.GetComponent<control> ().clickCount > 0) {
			//////////// COPY AND PASTED FROM CONTROL////////
			if (transform.position != endMarker.position){
				float startTime = bathroom.GetComponent<control>().startTime;
			
				//walk forward, only works if you right click first
				float distCovered = (Time.time - startTime) * walkSpeed;
				fracJourney = distCovered / journeyLength;
				//transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
				tempTransform = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
				
				
				float blurSize = Mathf.Lerp (20, 2, fracJourney);
				//Mathf.PingPong(Time.time, 1.0F);
				
				blurryMirror.GetComponent<Renderer>( ).material.SetFloat("_Size", blurSize);
				Debug.Log ("still running walk");
			}







						if (bathroom.GetComponent<control> ().arrivedAtSink == false) {

								//if (doneBouncing) { //if youre done bouncing
								if (temp == 0) {
										if (doneBouncing) {//and if its bounce time                        player.transform.position & Mathf.Lerp (20, 0, fracJourney)   == blurSize
										
												bounceSetup ();
										}
								}

								if (!doneBouncing) {
										walkBounce ();
								} else {

				
					transform.position = tempTransform;
				}
								


						} else {	
								Debug.Log ("destroy'd");
								Destroy (this);

						}
				
				}
		}

	void bounceSetup(){
		
		time = .2f; //was 0.05f, time = how high
		totalTime = time;
		originalPosition = tempTransform;
		Debug.Log (tempTransform);
		Debug.Log ("BOUNCCCCCCEEE setup");
		doneBouncing = false;
	}

	void walkBounce(){


	
				if (time > 0f) { 
						//while (time > 0f) {
						time -= Time.deltaTime;

						Vector3 jump = originalPosition + Vector3.down * 0.01f;// previously .03f when in while loop
			//transform.position = originalPosition + Vector3.up * Mathf.Sin (Time.time * 10f) * time; 
			//transform.position = Vector3.Lerp (originalPosition, jump, time / totalTime);
			transform.position = Vector3.Lerp (tempTransform, jump, time / totalTime);
						
		

						/*
						Vector3 newPosition = transform.position;
						newPosition.y -= speed * Time.deltaTime;
		
						transform.position = newPosition;
						*/
		
			originalPosition = transform.position;
			//Debug.Log (transform.position);
		
		
			//Debug.Log ("time is " + time + "    deltaTime = " + Time.deltaTime);
		
						
		
						//yield return 0;
				} else {
			Debug.Log ("done bouncing");
						doneBouncing = true;
		
			}
		}
}
