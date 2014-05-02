using UnityEngine;
using System.Collections;

public class raycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit rayHit = new RaycastHit ();//blank container for info
		
		//actually shoot the raycast now
		
		//if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, 1000f))
		//if (Physics.Raycast (Camera.main.transform.position, out rayHit, 1000f))
		//if (Physics.Raycast (ray, out rayHit, 1000f))
		if (Physics.Raycast (transform.position, transform.forward, out rayHit, 1000f))
		{
			//Debug.DrawRay(ray, Camera.main.transform.forward * rayHit.distance);
			//Debug.Log("RAYCASTING");	
			Collider collider1 = rayHit.collider;
			//Debug.Log(collider1.name);
			
			
			
			if (collider1.name == "babybird1" || collider1.name == "babybird2" || collider1.name == "babybird3"  ){
				//startBox = true;
				
				GameObject obj = GameObject.Find("birdGui");
				obj.GetComponent<animateMat>().raycastGo=true;
				//Application.LoadLevel ("dancingBaby"); //dancingBaby as example of scene title
			}  else {
				
				GameObject obj = GameObject.Find("birdGui");
				obj.GetComponent<animateMat>().raycastGo=false;

			}
		}
		

	
	}
}
