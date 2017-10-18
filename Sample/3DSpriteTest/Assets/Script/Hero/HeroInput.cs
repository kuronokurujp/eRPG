using UnityEngine;
using System.Collections;

public class HeroInput : PlayerInput
{
    public Camera MainCamera = null;

	//	カメラ座標のオフセット
	public	Vector3	m_camPosOffset	= Vector3.zero;

	private	Vector3	m_camVector	= Vector3.zero;
	
	public	override	void	Awake()
	{
		base.Awake();

		m_camVector	= MainCamera.transform.position - transform.position;
		
		_rotCam( 0 );
	}

	public override void Update ()
	{
		if( m_player.charBase.pause )
		{
			return;
		}
		
		base.Update();
		
		//	ポーズメニュー呼び出し
		if( Input.GetButton("Fire3") )
		{
			NotificationCenter.DefaultCenter.PostNotification(this, "OnStartGamePause");
			return;
		}

		//	移動
		Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (directionVector != Vector3.zero)
		{			
			//	入力ベクトルを方向ベクトルにする
			directionVector = directionVector.normalized;

			//	カメラのY軸回転に合わせた方向にする
			Quaternion	camPutch	= Quaternion.Euler( new Vector3( 0, MainCamera.transform.eulerAngles.y, 0 ) );
			directionVector	= camPutch * directionVector;

			m_dir	= directionVector;
			if( m_player.action.runningId != ActionId.eMOVE )
			{
				m_player.action.runFromPrority (ActionId.eMOVE);
			}
		}
		
		//	攻撃開始
		if( Input.GetButton("Jump") )
		{
			if( m_player is Hero )
			{
				Hero	hero	= m_player as Hero;
				
				hero.m_normalAtkActionParam.offsetPos	= m_player.charBase.dir * hero.m_normalAtkActionParam.length;
				hero.m_normalAtkActionParam.offsetPos	+= hero.m_normalAtkActionParam.pos;
				
				m_player.action.runFromPrority(ActionId.eNORAML_ATK, hero.m_normalAtkActionParam);
			}			
		}

		//	カメラの回転
		if( Input.GetButton("Fire1") )
		{
			_rotCam( 1 );
		}
		else if( Input.GetButton("Fire2") )
		{
			_rotCam( -1 );
		}
	}

	/*
	 * 	@brief	キャラを中心を基本位置にしてのカメラ回転
	 */
	private	void	_rotCam( float angleSpeed )
	{
		Matrix4x4	mat	= new Matrix4x4();
		mat.SetTRS( Vector3.zero, Quaternion.AngleAxis(angleSpeed, Vector3.up), Vector3.one);
			
		m_camVector	= mat.MultiplyVector(m_camVector);
		Vector3	centerPos	= transform.position + m_camPosOffset;
		Vector3	camPos	= m_camVector + centerPos;

        MainCamera.transform.position	= camPos;
        //	カメラの軸回転
        MainCamera.transform.rotation	= Quaternion.LookRotation(centerPos - camPos);		
	}
}
