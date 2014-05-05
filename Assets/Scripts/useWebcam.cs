using UnityEngine;
using System.Collections;

public class useWebcam : MonoBehaviour {

	// Use this for initialization
	void Start () {WebCamTexture webcamTexture = new WebCamTexture();
		//renderer.material.SetTextureScale("_MainTex", new Vector2(-1,1));
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
