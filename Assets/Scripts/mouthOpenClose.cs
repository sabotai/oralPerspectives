﻿using UnityEngine;
using System.Collections;

public class mouthOpenClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKey (KeyCode.Space)) 
		{

			animation.Rewind ();
			animation.Play ();
			//AudioSource.Play();
		}
	}
}
