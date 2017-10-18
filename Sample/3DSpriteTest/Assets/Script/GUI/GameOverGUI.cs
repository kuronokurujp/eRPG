using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void	OnGUI()
	{
		Rect	rect	= RectifyScreenGUI.calcRect( new Rect(0, 0, RectifyScreenGUI.widthScreen, RectifyScreenGUI.heightScreen));

		GUILayout.BeginArea (rect);
		
		{
			Rect	lablRect	= RectifyScreenGUI.calcRect(new Rect(RectifyScreenGUI.widthScreen * 0.5f, RectifyScreenGUI.heightScreen * 0.2f,
																	 64, 64 ) );
			GUI.Label(lablRect, "GameOver");
		}
		
		{
			Rect	btnRect	= RectifyScreenGUI.calcRect(new Rect(0, RectifyScreenGUI.heightScreen * 0.5f,
																 RectifyScreenGUI.widthScreen, 64 ) );
			if(GUI.Button ( btnRect, "retry"))
			{
				Application.LoadLevel("scene");
			}
		}

		GUILayout.EndArea (); 
	}
}
