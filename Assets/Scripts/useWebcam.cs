using UnityEngine;
using System.Collections;

public class useWebcam : MonoBehaviour {

	// Use this for initialization
	void Start () {

		/*

		WebCamDevice[] devices = WebCamTexture.devices;
		WebCamTexture webcamTexture = new WebCamTexture();
		//if(devices.length > 0){
			webcamTexture.deviceName = devices[1].name;
			
			renderer.material.mainTexture = webcamTexture;
			webcamTexture.Play();
		//}
*/

		/* original */
		WebCamTexture webcamTexture = new WebCamTexture();
		//renderer.material.SetTextureScale("_MainTex", new Vector2(-1,1));
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
