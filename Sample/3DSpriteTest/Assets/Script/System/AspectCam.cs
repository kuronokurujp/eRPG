using UnityEngine;
using System.Collections;

public class AspectCam : MonoBehaviour
{
	// 縦横比です。インスペクタから修正します。
	public float xAspect = 4.0f;
	public float yAspect = 3.0f;

	void Awake()
	{
		// カメラを検索します。
		Camera camera = GetComponent<Camera>();
		// 指定された比率からサイズを出します。
		Rect rect = calcAspect(xAspect, yAspect);
		// カメラの比率を変更します。
		camera.rect = rect;
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	// アスペクト比計算
	public Rect calcAspect(float in_width, float in_height)
	{
		float target_aspect = in_width / in_height;
		float window_aspect = (float)Screen.width / (float)Screen.height;
		float scale_height = window_aspect / target_aspect;

		Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
		if(1.0f > scale_height)
		{
			rect.x = 0;
			rect.y = (1.0f - scale_height) / 2.0f;
			rect.width = 1.0f;
			rect.height = scale_height;
		}
		else
		{	
			float scale_width = 1.0f / scale_height;
			rect.x = (1.0f - scale_width) / 2.0f;
			rect.y = 0.0f;
			rect.width = scale_width;
			rect.height = 1.0f;
		}

		return rect;
	}
}
