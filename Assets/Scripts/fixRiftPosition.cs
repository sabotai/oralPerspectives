using UnityEngine;
using System.Collections;

public class fixRiftPosition : MonoBehaviour {

	Transform riftRightOriginalTransform, characterTransform;
	public bool correctBool = true;
	Vector3 correction, riftPos, charPos;


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
			correction = charPos - riftPos;
			charPos = characterTransform.localPosition;
			Debug.Log("Correction = " + correction + "  and CharPos = " + charPos);
			characterTransform.localPosition = charPos - correction/4;
			Debug.Log("Attempted to Correct Rift Child");
			correctBool = false;
		}

	
	}
}
