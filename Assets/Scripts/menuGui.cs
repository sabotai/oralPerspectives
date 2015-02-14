using UnityEngine;
using System.Collections;

public class menuGui : MonoBehaviour {
	
	public Texture2D controlTexture;
	public Color bgColor;
	public Font guiFont;
	public GUIStyle myGuiStyle;
	public GUISkin myGuiSkin;
	Texture2D texture = new Texture2D(128, 128);
	private GUIStyle myGuiStyle2 = null;
	private string riftText, mouthText;
	public bool useRift = true;
	public bool useMouth = false;

	void start()
	{
		PlayerPrefs.DeleteAll ();
		if (useRift) {
			riftText = "Use Oculus Rift :)";
			PlayerPrefs.SetInt("Rift", 1);
		} else {
			riftText = "No Oculus Rift :(";
			PlayerPrefs.SetInt("Rift", 0);
		}
		if (useMouth) {
			mouthText = "Use Mouth Control :)";
			PlayerPrefs.SetInt("Mouth", 1);
		} else {
			mouthText = "No Mouth Control :(";
			PlayerPrefs.SetInt("Mouth", 0);
		}

		/*
				for (int y = 0; y < texture.height; ++y) {
						for (int x = 0; x < texture.width; ++x) {
								float r = Random.value;
								Color color = new Color (r, r, r);
								texture.SetPixel (x, y, color);
						}
				}
				texture.Apply ();

		*/

		}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Application.LoadLevel ("birdSceneB 2");
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Application.LoadLevel ("gloryHole");
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Application.LoadLevel ("test");
		}
	}

	void OnGUI () {// Make a background box
		if (!useRift) {
			riftText = "No Rift :(";
			PlayerPrefs.SetInt("Rift", 0);
		} else {
			riftText = "Use Rift! :)";
			PlayerPrefs.SetInt("Rift", 1);
		}
		if (!useMouth) {
			mouthText = "No Mouth :(";
			PlayerPrefs.SetInt("Mouth", 0);
		} else {
			mouthText = "Use Mouth! :)";
			PlayerPrefs.SetInt("Mouth", 1);
		}

		InitStyles ();
		//mainGui.font = guiFont;
		//myGuiStyle.normal.background = texture;
		GUI.skin.font = guiFont;

		//GUI.contentColor = bgColor;
		//GUI.backgroundColor = new Color(0,1,1,1);

		GUI.Box(new Rect(Screen.width / 16, Screen.height / 6, (Screen.width / 16) * 14, (Screen.height / 12) * 9), "", myGuiStyle2);
		GUI.Label (new Rect (Screen.width / 12,Screen.height / 5, (Screen.width / 6) * 5, (Screen.height / 3) * 20), controlTexture, myGuiStyle);


		float buttonWidth = Screen.width / 6;
		float buttonHeight = Screen.height / 12;

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width / 3, (Screen.height / 5) * 2,buttonWidth, buttonHeight), "Play", myGuiStyle)) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width / 3 , ((Screen.height / 5) * 2) + buttonHeight*1.5f,Screen.width / 6, Screen.height / 12), riftText, myGuiStyle)) {
			useRift = !useRift;
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width / 3 , ((Screen.height / 5) * 2) + buttonHeight*3,Screen.width / 6, Screen.height / 12), mouthText, myGuiStyle)) {
			useMouth = !useMouth;
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width / 3 , ((Screen.height / 5) * 2) + buttonHeight*4.5f,Screen.width / 6, Screen.height / 12), "Exit", myGuiStyle)) {
			Application.Quit ();
		}
	}

	private void InitStyles()
		
	{
		
		if( myGuiStyle2 == null )
			
		{
			
			myGuiStyle2 = new GUIStyle( GUI.skin.box );
			
			myGuiStyle2.normal.background = MakeTex( 2, 2, new Color( 1f, 0.8666f, 0.922f, 0.5f ) );
			myGuiStyle2.border.left = 109;
			myGuiStyle2.border.top = 5;
			myGuiStyle2.border.bottom = 20;
			myGuiStyle2.border.right = 10;
			
		}
		
	}
	
	
	
	private Texture2D MakeTex( int width, int height, Color col )
		
	{
		
		Color[] pix = new Color[width * height];
		
		for( int i = 0; i < pix.Length; ++i )
			
		{
			
			pix[ i ] = col;
			
		}
		
		Texture2D result = new Texture2D( width, height );
		
		result.SetPixels( pix );
		
		result.Apply();
		
		return result;
		
	}
}