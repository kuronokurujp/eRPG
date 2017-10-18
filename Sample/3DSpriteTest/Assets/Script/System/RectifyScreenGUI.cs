using UnityEngine;
using System.Collections;

public class RectifyScreenGUI : MonoBehaviour {
	
	public	static float	widthScreen	= 320;
	public	static float	heightScreen	= 480;

	public	float	width	= widthScreen;
	public	float	height	= heightScreen;
	
	/*
	 * 	@brief	設定した画面サイズから修正したのを取得
	 */
	public	static	Rect	calcRect( Rect in_rect )
	{
		float	invWidthcScreen		= 1.0F / widthScreen;
		float	invHeightcScreen	= 1.0F / heightScreen;
		
		float	x	= in_rect.x * invWidthcScreen * Screen.width;
		float	y	= in_rect.y * invHeightcScreen * Screen.height;
		float	width	= in_rect.width * invWidthcScreen * Screen.width;
		float	height	= in_rect.height * invHeightcScreen * Screen.height;		

		return	new Rect( x, y, width, height );
	}

	public	static Vector2	calcVec2( Vector2 in_vec )
	{
		float	invWidthcScreen		= 1.0F / widthScreen;
		float	invHeightcScreen	= 1.0F / heightScreen;		
		
		float	x	= in_vec.x * invWidthcScreen * Screen.width;
		float	y	= in_vec.y * invHeightcScreen * Screen.height;

		return	new Vector2(x, y);
	}
	
	void	Awake()
	{
		widthScreen		= width;
		heightScreen	= height;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
