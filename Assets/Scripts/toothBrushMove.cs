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

	// Use this for initialization
	void Start () {
		counter = 0;
		started = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (startBrushing && counter <= howManyCycles) {
			started = true;
						//GameObject obj = GameObject.Find("monoCam");
						//transform.parent= obj.transform;

						if (currentWaypoint < waypoint.Length) {
								Debug.Log ("current toothbrush waypoint = " + currentWaypoint);
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
					
				
				toothbrushObj.rigidbody.AddForce (10,0,0);
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
