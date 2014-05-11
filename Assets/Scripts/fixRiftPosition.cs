using UnityEngine;
using System.Collections;

public class fixRiftPosition : MonoBehaviour {

	Transform riftRightOriginalTransform, characterTransform;
	public bool correctBool = true;
	Vector3 correction, correctionYZ, riftPos, charPos;
	//public GameObject ovrcamera;


	// Use this for initialization
	void Start () {
		
		
		characterTransform = transform.Find("monoCam/character");



		//tempV = clonePhallicObj.transform.position - phallicObj.transform.position;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (correctBool) {
			characterTransform.parent = transform;

			riftPos = transform.position;
			charPos = characterTransform.position;
			correction.Set(charPos.x - riftPos.x, 0, 0);
			charPos = characterTransform.localPosition;
			Debug.Log("Correction = " + correction + "  and CharPos = " + charPos);
			//characterTransform.localPosition = charPos - correction/4;
			characterTransform.localPosition = charPos - correction/4;
			Debug.Log("Attempted to Correct Rift Child");
			correctBool = false;



			/////trying to fix y value
			/// 
			/// 
			/*
			riftPos = transform.localPosition;
			correctionYZ.Set (0,riftPos.y, riftPos.z);
			
			correctionYZ.Set (0, 3.61f, 2.16f);
			//ovrcamera.transform.position -= correctionYZ;
*/
		}

	
	}
}
