using UnityEngine;
using System.Collections;

public class animateMat : MonoBehaviour {

	public Texture[] pictureArray;
	Texture picture;
	int delay;
	int count;
	public bool raycastGo;

	// Use this for initialization
	void Start () {
		raycastGo = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (raycastGo) {
						delay++;
						if (delay % 10 == 0) {
								if (count == pictureArray.Length) {
										count = 0;


								}
								picture = pictureArray [count];    
								//renderer.material.mainTexture = picture;
								guiTexture.texture = picture;
								delay = 0;        
								count++;
								Debug.Log ("changing");
						}    
						Debug.Log ("delay is " + delay);
				} else {
			
					guiTexture.texture = null;
				}
	}
}