using UnityEngine;
using System.Collections;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof(CharacterController))]
//	強制追加コンポーネント
[AddComponentMenu ("Character/Platform Input Controller")]

[System.Serializable]
public class CharMoveParam
{
	//	基本スピード
	public	float	baseSpeed	= 1;
	
	//	重力
	public float	gravity	= 200;
}

/*
 * 	@brief	キャラクター制御クラス
 */
public class CharCtrl : MonoBehaviour
{
	//	インスペクター設定可能
	public	CharMoveParam	m_moveParam	= new CharMoveParam();
	
	private	Vector3	m_dir;
	private	Vector3	m_inputMoveDirection;
	private	Vector3	m_moveVec;
	private	Vector3	m_groundNormal;
	private	bool	mb_jump;
	private	bool	mb_pause	= false;
	private CharacterController m_controller;

	/*
	 * 	@brief	最初から呼ばれる
	 * 
	 */
	void	Awake ()
	{
		m_controller = GetComponent<CharacterController> () as CharacterController;
		
		NotificationCenter.DefaultCenter.AddObserver(this, "OnPuase");
	}
	
	/*
	 *	@brief
	 */
	void	Start()
	{
		m_moveVec	= Vector3.zero;
		m_dir	= Vector3.forward;
		mb_jump	= false;
		m_inputMoveDirection	= Vector3.zero;
		m_groundNormal	= Vector3.zero;
	}
	
	/*
	 * 	@brief	更新
	 */
	void	Update()
	{
		if( mb_pause )
		{
			return;
		}
		
		Vector3	vec	= m_inputMoveDirection;
		if( vec != Vector3.zero )
		{
			m_dir	= m_inputMoveDirection;
			vec = vec * m_moveParam.baseSpeed;
		}

		//	常に重力値を与える
		vec.y	= Mathf.Min(0, vec.y) - m_moveParam.gravity;
		vec += m_moveVec;
		
		m_groundNormal	= Vector3.zero;

		//	速度単位を１メートルから１センチメートルへ
		m_controller.Move( vec * 0.001F );
		
		//	移動結果後地面に接しているか
		if( isGroundTest() )
		{
			
		}
		
		m_inputMoveDirection	= Vector3.zero;
		m_moveVec	= Vector3.zero;
	}

	/*
	 * 	@brief	衝突発生
	 */
	public void	OnControllerColliderHit(ControllerColliderHit in_hit)
	{
		if (in_hit.normal.y > 0)
		{
			m_groundNormal	= in_hit.normal;
		}
	}
	
	/*
	 * 	@brief	地面に接触しているか
	 */
	public	bool	isGroundTest()
	{
		return	(m_groundNormal.y > 0.01F);
	}

	/*
	 * 	@brief
	 */
	public	Vector3	inputMoveDir
	{
		get
		{
			return	m_inputMoveDirection;
		}
		set
		{
			//	あくまで方向のみ与える
			m_inputMoveDirection	= value;
		}
	}
	
	/*
	 * 	@brief	強制移動
	 */
	public	Vector3	move
	{
		set
		{
			m_moveVec	= value;
		}
	}
	
	/*
	 * 	@brief	
	 */
	
	/*
	 * 	@brief
	 */
	public	bool	inputJump
	{
		get
		{
			return	mb_jump;
		}
		set
		{
			mb_jump	= value;
		}
	}
	
	public	Vector3	dir
	{
		get
		{
			return	m_dir;
		}
		
		set
		{
			m_dir	= value;
		}
	}
	
	/*
	 * 	@brief
	 */
	public	bool	pause
	{
		get
		{
			return	mb_pause;
		}
		
		set
		{
			mb_pause	= value;
		}
	}
	
	/*
	 * 	@brief	ポーズ設定呼び出し
	 */
	void	OnPuase(Notification in_notification )
	{
		mb_pause	= false;
		if( in_notification != null )
		{
			mb_pause	= (bool)in_notification.data["flg"];
		}		
	}
}
