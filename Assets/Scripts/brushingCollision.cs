using UnityEngine;
using System.Collections;

public class brushingCollision : MonoBehaviour {

	public AudioClip brushSound;
	public AudioClip brushMissSound;
	public Collider mouthCollider;

	public ParticleSystem foam;
	Transform emission2, emission3, emission4;

	// Use this for initialization
	void Start () {
		emission2 = GameObject.Find ("brushEmission2").transform;
		emission3 = GameObject.Find ("brushEmission3").transform;
		emission4 = GameObject.Find ("brushEmission4").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		//audio.Stop ();
		if (audio.time > 0.3f) {
			audio.Stop ();
				}
	
	}
	
	void OnTriggerEnter(Collider mouthCollider) {
		Debug.Log("toothbrush collision explicit");
		//scoreDisplay.GetComponent<displayScore>().iScore++;
		//play sound
		audio.Stop ();
		audio.Play ();
		audio.PlayOneShot (brushSound);
		//crumbs
		emission2.particleSystem.Play();
		emission3.particleSystem.Play ();
		emission4.particleSystem.Play ();
		foam.particleSystem.Play ();
		//Destroy(this);
		
		
	}
}
