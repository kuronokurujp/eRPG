using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	protected Player m_player	= null;
	protected	Vector3	m_dir	=	Vector3.zero;

	// 	スクリプト追加した段階で呼ばれる
	public virtual void Awake ()
	{
		//	スクリプト追加した段階で呼ばれる
		m_player = GetComponent<Player>() as Player;
	}

	// 	スクリプト追加した段階で呼ばれる
	public virtual void Update ()
	{
		m_dir	= Vector3.zero;
	}
	
	public	Vector3	getAxis
	{
		get
		{
			return	m_dir;
		}
	}
}
