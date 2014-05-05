using UnityEngine;
using System.Collections;

public class SpawnByLoudness : MonoBehaviour {
	
	public GameObject audioInputObject;
	//public float threshold; 
	public GameObject objectToSpawn;
	public int lightState, timeState;
	public float time1, time2, time3;
	public float ambient1, ambient2, ambient3;
	public float triggerLoudness;
	public bool useMicrophone;
	
	MicrophoneInput micIn;
	
	void Start() {
		useMicrophone = false;
		lightState = 1;
		timeState = 1;
		if (objectToSpawn == null)
			Debug.LogError("You need to set a prefab to Object To Spawn -parameter in the editor!");
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("AudioInputObject");
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput");
	}
	
	void Update () {
		
		if (useMicrophone) {

						/*=== ambiant noise detection ===*/
						if (micIn.loudness > 0 && timeState == 1) {
								time1 = Time.time;
								ambient1 = micIn.loudness;
								timeState = 2;
						} else if (timeState == 2) {
								time2 = Time.time;
								if (time2 - time1 >= 2) {
										ambient2 = micIn.loudness;
										timeState = 3;
								}
						} else if (timeState == 3) {
								time3 = Time.time;
								if (time3 - time2 >= 2) {
										ambient3 = (micIn.loudness + ambient1 + ambient2) / 3;
										timeState = 4;
								}
						}
		
						/*=== use sound to turn on the light ===*/
						float l = micIn.loudness - ambient3;
						if (l < 0)
								l = 0;
						Debug.Log (l);
						Debug.Log ("ambient noise: " + ambient3);
		
						if (l > triggerLoudness * ambient3) {
								//lightState = 2;
								//objectToSpawn.light.intensity = 8.0f;
								Debug.Log ("SPAWWWWNNNN");
								GameObject vomit = GameObject.Find ("vomitOrigin");
								vomit.GetComponent<secondaryAction> ().Vomit ();

						}
				}
		
		//objectToSpawn.light.intensity -= 0.1f;
	}
	
	float map(float s, float a1, float a2, float b1, float b2)	{	
		return b1 + (s-a1)*(b2-b1)/(a2-a1);	
	}
}