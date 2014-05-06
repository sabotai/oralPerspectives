using UnityEngine;
using System.Collections;

public class toothBrushMove : MonoBehaviour {

	public static toothBrushMove main;
	
	void Awake(){
		
		main = this;
	}

	public Transform[] waypoint;
	public GameObject toothbrushObj;
	public bool startBrushing;
	public float waySpeed = 5;
	private int currentWaypoint;
	private Vector3 velo;
	private int counter;
	public int howManyCycles;
	private bool started;
	public AudioSource buildupSound;

	// Use this for initialization
	void Start () {
		counter = 0;
		started = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (counter == howManyCycles - 4) {
			//find a way to change how many it subtracts by the speed of the brushing
						buildupSound.Play ();
				}


		if (counter > howManyCycles - 2) {
			
			ParticleSystem emission = GameObject.Find ("brushEmission").transform.particleSystem;
			ParticleSystem emission2 = GameObject.Find ("brushEmission2").transform.particleSystem;
			ParticleSystem emission3 = GameObject.Find ("brushEmission3").transform.particleSystem;
			ParticleSystem emission4 = GameObject.Find ("brushEmission4").transform.particleSystem;
			emission2.Stop();
			emission3.Stop ();
			emission4.Stop ();
			emission.Stop();
			/*
			Debug.Log ("wut " + emission2.isPlaying);
			Debug.Log (emission.isPlaying);
			Debug.Log (emission3.isPlaying);
			Debug.Log (emission4.isPlaying);*/
				}

		if (startBrushing && counter <= howManyCycles) {
			started = true;
						//GameObject obj = GameObject.Find("monoCam");
						//transform.parent= obj.transform;

						if (currentWaypoint < waypoint.Length) {
								//Debug.Log ("current toothbrush waypoint = " + currentWaypoint);
								Vector3 target = waypoint [currentWaypoint].position;
								Vector3 moveDirection = target - toothbrushObj.transform.position;
								velo = toothbrushObj.rigidbody.velocity;
				
								if (moveDirection.magnitude < 0.3f) {
										currentWaypoint++;
								} else {
										velo = moveDirection.normalized * waySpeed;
								}
						} else {
								currentWaypoint = 1;
								waySpeed *= 1.2f;
								counter += 1;
						}
			
						toothbrushObj.rigidbody.velocity = velo;

				} else {

			if (started) {
					
				// blow the toothbrush away once done

				toothbrushObj.rigidbody.AddForce (10,0,0);

				GameObject obj = GameObject.Find("bathroomScene");
				//obj.GetComponent<control>().clickCount = 3;
				obj.GetComponent<control>().soundUpdate = true;
				//obj.GetComponent<control>().shiftSound.Play();
				started = false;
				
			}

			/*

			currentWaypoint = 0;
			if (currentWaypoint < waypoint.Length) {
				Debug.Log ("sending it back to  " + currentWaypoint);
				Vector3 target = waypoint [currentWaypoint].position;
				Vector3 moveDirection = target - toothbrushObj.transform.position;
				velo = toothbrushObj.rigidbody.velocity;								
				if (moveDirection.magnitude < 0.3f) {

				} else {
					velo = moveDirection.normalized * waySpeed;
				}
			}


				toothbrushObj.rigidbody.velocity = velo;*/
				

				}
}
}
