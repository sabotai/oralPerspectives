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
	public bool useMicrophone = false;

	
	public float sensitivity = 100;
	public float loudness = 0;
	public bool audioMute = true;

	bool doOnce = true;

	
	MicrophoneInput micIn;
	
	void Start() {
		///////////////
		/// 

						Debug.Log (Microphone.devices);
		
		//audio.clip = Microphone.Start (null, false, 999, 44100);
		//audio.loop = false; 

						audio.clip = Microphone.Start (null, true, 1, AudioSettings.outputSampleRate);
						audio.loop = true; // Set the AudioClip to loop
						audio.mute = audioMute; // Mute the sound, we don't want the player to hear it
		
						//while (!(Microphone.GetPosition(AudioInputDevice) > 0)) { // Wait until the recording has started
						audio.Play (); // Play the audio source!





		
						lightState = 1;
						timeState = 1;
						if (objectToSpawn == null)
								Debug.LogError ("You need to set a prefab to Object To Spawn -parameter in the editor!");
				
		/*
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("AudioInputObject");
		micIn = (MicrophoneInput) this.GetComponent("SpawnByLoudness");*/

		/* original
		lightState = 1;
		timeState = 1;
		if (objectToSpawn == null)
			Debug.LogError("You need to set a prefab to Object To Spawn -parameter in the editor!");
		if (audioInputObject == null)
			audioInputObject = GameObject.Find("AudioInputObject");
		micIn = (MicrophoneInput) audioInputObject.GetComponent("MicrophoneInput");
		*/
	}
	
	void Update () {
		/////////
		/// 
		if (useMicrophone) {
		
						loudness = GetAveragedVolume () * sensitivity;


						if (loudness > 0 && timeState == 1) {
								time1 = Time.time;
								ambient1 = loudness;
								timeState = 2;
						} else if (timeState == 2) {
								time2 = Time.time;
								if (time2 - time1 >= 2) {
										ambient2 = loudness;
										timeState = 3;
								}
						} else if (timeState == 3) {
								time3 = Time.time;
								if (time3 - time2 >= 2) {
										ambient3 = (loudness + ambient1 + ambient2) / 3;
										timeState = 4;
								}
						}


						if (useMicrophone && (ambient3 > 0)) {

								/*
			if (doOnce){
				Microphone.End(null);
				
				audio.clip = Microphone.Start(null, false, 999, 44100);
				doOnce = false;
			}
			*/
								/*=== use sound to turn on the light ===*/
								float l = loudness - ambient3;
								if (l < 0)
										l = 0;
								Debug.Log (l);
				//Debug.Log ("ambient noise: " + ambient3);
				GameObject vomit = GameObject.Find ("vomitOrigin");
				
				if (l > triggerLoudness * ambient3) {
										//lightState = 2;
										//objectToSpawn.light.intensity = 8.0f;
										//Debug.Log ("SPAWWWWNNNN");
										vomit.GetComponent<secondaryAction> ().Vomit ();

								} else {
					
					if (vomit.GetComponent<secondaryAction> ().vomitSound.isPlaying) {
						vomit.GetComponent<secondaryAction> ().vomitSound.Pause ();
					}
				}
						}
				}
		
		//objectToSpawn.light.intensity -= 0.1f;
	}
	
	float map(float s, float a1, float a2, float b1, float b2)	{	
		return b1 + (s-a1)*(b2-b1)/(a2-a1);	
	}

	
	float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		audio.GetOutputData(data,0);
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/256;
	}
}