using UnityEngine;
using System.Collections;

public class Hero : Player
{
	public	NormalDmgAction.param	m_normalDmgActionParam	= new NormalDmgAction.param();
	public	NormalAtkAction.param	m_normalAtkActionParam	= new NormalAtkAction.param();

	public override	void	Awake()
	{
		base.Awake();
	}
	
	public	override	void	dead()
	{
		base.dead();
		//	ゲームオーバー通知
		NotificationCenter.DefaultCenter.PostNotification(this, "OnStartGameOver");
	}

	public	void	OnTriggerEnter( Collider in_hit )
	{
		if( in_hit.CompareTag("Enemy") )
		{
			Enemy	hitEnemy	= in_hit.gameObject.GetComponent<Enemy>() as Enemy;
			if( hitEnemy )
			{
				//	死亡中かチェック
				Player	enemy	= hitEnemy as Player;
				if( ManagerAction.isDie( ref enemy ) )
				{
				}
				//	相手にダメージを与えた
				else if( ManagerAction.isDamage( ref enemy ) )
				{
				}
				else
				{
					m_normalDmgActionParam.moveVec	= charBase.dir;
					if( m_normalDmgActionParam.moveVec == Vector3.zero )
					{
						m_normalDmgActionParam.moveVec	= Vector3.forward;
					}
			
					m_normalDmgActionParam.moveVec	= -m_normalDmgActionParam.moveVec;

					action.runFromPrority(ActionId.eNORMAL_DAMAGE, m_normalDmgActionParam);
				}
			}
		}
	}	
}
