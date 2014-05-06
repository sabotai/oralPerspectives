using UnityEngine;
using System.Collections;

public class Authorization : MonoBehaviour {
	IEnumerator Start() {
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
		if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone)) {
		} else {
		}
	}
}