using UnityEngine;
using System.Collections;

public class animateMat : MonoBehaviour {

	public Texture[] pictureArray;
	Texture picture;
	int delay;
	int count;
	public bool raycastGo = false;
	public bool useRiftGui = false;

	// Use this for initialization
	void Start () {

		if (GameObject.Find ("Player").GetComponent<useRift>().useOculusRift == true) {
			useRiftGui = true;

		} //else {


			//previously used to switch ovrgui and guitexture, but replaced with the hovering instructions

			GameObject obj = GameObject.Find("birdGui");
			GameObject obj2 = GameObject.Find("guiPlane");
			obj2.transform.position = obj.transform.position;
			obj2.transform.localScale = obj.transform.localScale;
			obj2.transform.rotation = obj.transform.rotation;
			Debug.Log("Relocated to birdGui");



			//}
	
	}
	
	// Update is called once per frame
	void Update () {

		//raycastGo = true;


		if (raycastGo){
						delay++;
						if (delay % 10 == 0) {
									if (count == pictureArray.Length) {
											count = 0;
									}
									picture = pictureArray [count];  

									if (useRiftGui){
										//renderer.enabled = true;
										renderer.material.mainTexture = picture;
									} 
									guiTexture.texture = picture;


									delay = 0;        
									count++;
									//Debug.Log ("changing");
						}    
						//Debug.Log ("delay is " + delay);
				} else {
			
			guiTexture.texture = null;
			renderer.material.mainTexture = null;
			//renderer.enabled = false;
				}
	}
}