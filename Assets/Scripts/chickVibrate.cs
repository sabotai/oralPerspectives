using UnityEngine;
using System.Collections;

public class chickVibrate : MonoBehaviour {

	public float waitTime;

	// Use this for initialization
	void Start () {
		StartCoroutine (chick ());
	}




	IEnumerator chick () {
		yield return new WaitForSeconds( waitTime ); //better way of doing this, automatically calculate the frames per second
		
		
		while (true) { //ok to use infinite loop, because we will take it to break after it
			float time = 0f;

			
			while (time < 1f) {

				time += Time.deltaTime;
				//ball1.position = Vector3.Lerp (originalBall1Pos, originalBall2Pos, time); //Lerp = linear interpolation
				//ball2.position = Vector3.Lerp (originalBall2Pos, originalBall1Pos, time);
				
				if (time > 0.49f && time < 0.51f){ 
					audio.Stop ();
					audio.Play ();
					StartCoroutine (ScreenShake ());
				}
				
				yield return 0; //wait a frame
			}
			
		}
	}
	
	IEnumerator ScreenShake() {
		float time = 0.3f;
		Vector3 originalPosition = transform.position;
		
		while (time > 0f) {
			time -= Time.deltaTime;
			transform.position = originalPosition + Vector3.right * Mathf.Sin (Time.time * 113f) * time; 
			
			
			
			yield return 0;
		}
		transform.position = originalPosition;
		//audio.Stop ();
	}
}


