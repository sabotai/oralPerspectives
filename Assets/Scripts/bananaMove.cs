using UnityEngine;
using System.Collections;

public class bananaMove : MonoBehaviour {

	public Transform[] waypoint;
	public GameObject phallicObj, clonePhallicObj;
	public bool startThrusting;
	public float waySpeed = 5;
	private int currentWaypoint;
	private Vector3 velo;
	private int counter;
	public int howManyCycles;
	private bool started;
	Vector3 tempV;

	// Use this for initialization
	void Start () {	
		tempV = clonePhallicObj.transform.position - phallicObj.transform.position;

	
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
				Debug.Log ("OHHHH YEAHHH");

				// POSSIBLY ADD INTO CONDITIONAL A BOOLEAN FOR STRIKING THE TRIGGER BOX IN THE MOUTH

				if (true){
					// INSERT CUTE YEAHHH SOUND 

					// INCREASE COUNT APPROACHING 'ORGASM' 
					// UPON ORGASM, TURN ON CAMERA COLLIDER AND DEPARENT EVERYTHING FROM IT AND TURN OFF RIGIDBODY-KINEMATIC
					// MAYBE 2 CAMERA COLLIDERS/RIGIDBODIES

				} else {
					// INSERT CUTE SAD SOUND
				}
			}

			clonePhallicObj.transform.position = phallicObj.transform.position + tempV;//new Vector3(0,0,tempZ);
			phallicObj.rigidbody.velocity = velo;
			//Vector3 oldTransform = clonePhallicObj.transform.position;
			//clonePhallicObj.transform.position.x = temp;
						
			//clonePhallicObj.rigidbody.velocity = velo;			
						Debug.Log ("thrust " + currentWaypoint);
			
		}
		
 //phallicObj.transform.position + (oldTransform - phallicObj.transform.position);// + (oldTransform - phallicObj.transform.position); 
	
	}
}
