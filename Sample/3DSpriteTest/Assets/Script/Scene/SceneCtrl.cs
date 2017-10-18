using UnityEngine;
using System.Collections;

public class SceneCtrl : MonoBehaviour {
	
	~SceneCtrl()
	{
//		NotificationCenter.DefaultCenter.RemoveObserver(this, "OnGameOverStart");
	}
	
	void	Awake()
	{
		NotificationCenter.DefaultCenter.AddObserver(this, "OnStartGameOver");
		NotificationCenter.DefaultCenter.AddObserver(this, "OnStartGamePause");		
		NotificationCenter.DefaultCenter.AddObserver(this, "OnEndGamePause");
		NotificationCenter.DefaultCenter.AddObserver(this, "OnStartGameBegin");
		NotificationCenter.DefaultCenter.AddObserver(this, "OnEndGameBegin");	
	}
	
	// Use this for initialization
	void Start ()
	{
		NotificationCenter.DefaultCenter.PostNotification(this, "OnStartGameBegin");	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*
	 * 	@brief	ゲームオーバー開始
	 */
	void	OnStartGameOver()
	{
		//	ポーズ実行
		Hashtable	data	= new Hashtable();
		data.Add("flg", true);
		NotificationCenter.DefaultCenter.PostNotification(this, "OnPuase", data);
		
		//	死亡したのでゲームオーバー画面を出す
		GameOverGUI	gui	= GetComponent<GameOverGUI>() as GameOverGUI;
		if( gui )
		{
			gui.enabled	= true;
		}
	}

	/*
	 * 	@brief	ゲームポーズ開始
	 */
	void	OnStartGamePause()
	{
		//	ポーズ実行
		Hashtable	data	= new Hashtable();
		data.Add("flg", true);
		NotificationCenter.DefaultCenter.PostNotification(this, "OnPuase", data);
		
		GamePauseGUI	gui	= GetComponent<GamePauseGUI>() as GamePauseGUI;
		if( gui )
		{
			gui.enabled	= true;
		}
	}
	
	/*
	 * 	@brief	ゲームポーズ終了
	 */
	void	OnEndGamePause()
	{
		Hashtable	data	= new Hashtable();
		data.Add("flg", false);
		NotificationCenter.DefaultCenter.PostNotification(this, "OnPuase", data);
		
		GamePauseGUI	gui	= GetComponent<GamePauseGUI>() as GamePauseGUI;
		if( gui )
		{
			gui.enabled	= false;
		}
	}
	
	/*
	 * 	@brief	ゲームスタート開始
	 */
	void	OnStartGameBegin()
	{
		Hashtable	data	= new Hashtable();
		data.Add("flg", true);
		NotificationCenter.DefaultCenter.PostNotification(this, "OnPuase", data);
		
		GameStartGUI	gui	= GetComponent<GameStartGUI>() as GameStartGUI;
		if( gui )
		{
			gui.enabled	= true;
		}
	}

	/*
	 * 	@brief	ゲームスタート終了
	 */
	void	OnEndGameBegin()
	{
		Hashtable	data	= new Hashtable();
		data.Add("flg", false);
		NotificationCenter.DefaultCenter.PostNotification(this, "OnPuase", data);
		
		GameStartGUI	gui	= GetComponent<GameStartGUI>() as GameStartGUI;
		if( gui )
		{
			gui.enabled	= false;
		}
	}

}
