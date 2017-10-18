using UnityEngine;
using System.Collections;

public class NormalDmgAction : BaseAction
{
	[System.Serializable]
	public	class param
	{
		public	float	vecInv	= 0.8f;
		public	float	speedPow	= 1000;
		
		[System.NonSerializedAttribute]
		public	Vector3	moveVec	= Vector3.zero;
		public	int	damage	= 1;
	}

	private	Vector3	m_vec	= Vector3.zero;
	private	param	m_param	= null;

	public	NormalDmgAction( ActionId in_id, ActionPriority in_priority )
		: base( in_id, in_priority )
	{
	}
	
	/*
	 * 	@brief
	 */
	public	override	bool	initialize( ref Player in_player, object in_data )
	{
		base.initialize( ref in_player, in_data );
		if( (in_data != null) && (in_data.GetType() == typeof(NormalDmgAction.param)) )
		{
			m_param	= in_data as NormalDmgAction.param;
		}
		else
		{
			m_param	= new param();
		}
		
		in_player.param.hp	= Mathf.Max( 0, in_player.param.hp - m_param.damage );

		m_vec	= m_param.moveVec * m_param.speedPow;
		
		return	true;
	}

	/*
	 * 	@brief
	 */
	public	override	void	finalize()
	{
		base.finalize();
	}

	public	override	bool	isAction( ref Player in_player )
	{
		if( in_player.param.hp > 0 )
		{
			return	true;
		}
		
		return	false;
	}

	public	override	void	updateFunc()
	{
		m_vec *= m_param.vecInv;
		if( m_vec.magnitude <= 1.0f )
		{
			if( m_player.param.hp <= 0 )
			{
				m_player.action.run(ActionId.eDIE);
			}
			else
			{
				m_player.action.run(ActionId.eIDLE);
			}
		}
		else
		{
			m_player.charBase.move	= m_vec;
		}
	}
}
