using UnityEngine;
using System.Collections;

public class OnRenderGUITexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public RenderTexture m_TargetTexture;

	void OnGUI ()
	{
		BeginRenderTextureGUI (m_TargetTexture);
		
		GUILayout.Box ("This box goes on a render texture!");
		
		EndRenderTextureGUI ();
	}
	
	
	RenderTexture m_PreviousActiveTexture = null;
	
	
	protected void BeginRenderTextureGUI (RenderTexture targetTexture)
	{
		if (Event.current.type == EventType.Repaint)
		{
			m_PreviousActiveTexture = RenderTexture.active;
			if (targetTexture != null)
			{
				RenderTexture.active = targetTexture;
				GL.Clear (false, true, new Color (0.0f, 0.0f, 0.0f, 0.0f));
			}
		}
	}
	
	
	protected void EndRenderTextureGUI ()
	{
		if (Event.current.type == EventType.Repaint)
		{
			RenderTexture.active = m_PreviousActiveTexture;
		}
	}
}
