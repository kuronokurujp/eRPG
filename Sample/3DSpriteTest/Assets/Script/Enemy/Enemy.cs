using UnityEngine;
using System.Collections;

public class Enemy : Player
{
	public	NormalDmgAction.param	m_normalDmgActionParam	= new NormalDmgAction.param();
	
	//	トリガーを持っているコライダーには反応しない
	public	void	OnTriggerEnter( Collider in_hit )
	{
		if( in_hit.CompareTag("Player") )
		{
			if( in_hit.name.Contains("normal_atk") )
			{
				NormatlAtkActionSendData	data	= in_hit.gameObject.GetComponent<NormatlAtkActionSendData>() as NormatlAtkActionSendData;
				if( data )
				{
					NormalAtkAction.param	param	=	data.m_param;
					m_normalDmgActionParam.moveVec	= param.offsetPos.normalized;
					m_normalDmgActionParam.damage	= param.power;

					action.runFromPrority(ActionId.eNORMAL_DAMAGE, m_normalDmgActionParam);
				}
			}
		}
	}
	
	public	override	void	dead()
	{
		Destroy(gameObject);
	}
}
