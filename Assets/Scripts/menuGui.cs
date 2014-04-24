using UnityEngine;
using System.Collections;

public class menuGui : MonoBehaviour {
	
	public Texture2D controlTexture;
	public Color bgColor;
	public Font guiFont;
	public GUIStyle myGuiStyle;
	public GUISkin myGuiSkin;
	Texture2D texture = new Texture2D(128, 128);
	
	void start()
	{
				for (int y = 0; y < texture.height; ++y) {
						for (int x = 0; x < texture.width; ++x) {
								float r = Random.value;
								Color color = new Color (r, r, r);
								texture.SetPixel (x, y, color);
						}
				}
				texture.Apply ();

		}

	void OnGUI () {// Make a background box
		//mainGui.font = guiFont;
		myGuiStyle.normal.background = texture;
		GUI.skin.font = guiFont;

		//GUI.contentColor = bgColor;
		//GUI.backgroundColor = new Color(0,1,1,1);

		GUI.Box(new Rect(Screen.width / 16, Screen.height / 6, (Screen.width / 16) * 14, (Screen.height / 12) * 9), "", myGuiStyle);
		GUI.Label (new Rect (Screen.width / 12,Screen.height / 5, (Screen.width / 6) * 5, (Screen.height / 3) * 20), controlTexture, myGuiStyle);

		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Level 2", myGuiStyle)) {
			Application.LoadLevel(2);
		}
	}
}