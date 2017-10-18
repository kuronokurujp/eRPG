using UnityEngine;
using System.Collections;

public class EnemyInput : PlayerInput
{
	public EnemyInput ()
	{
	}
	
	public override void	Update()
	{
		if( m_player.charBase.pause )
		{
			return;
		}
		
		base.Update();
		
		//	AI
//		m_dir	= Vector3.forward;
//		m_player.action.runFromPrority(ActionId.eMOVE);
	}
}

