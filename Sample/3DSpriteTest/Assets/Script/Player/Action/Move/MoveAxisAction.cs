using UnityEngine;
using System.Collections;

/*
 * 
 */
public class MoveAxisAction : BaseAction
{
	public	MoveAxisAction( ActionId in_id, ActionPriority in_priority )
		: base( in_id, in_priority )
	{
	}

	/*
	 * 	@brief
	 */
	public	override	bool	initialize( ref Player in_player )
	{
		return	base.initialize( ref in_player );
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
		return	true;
	}

	public	override	void	updateFunc()
	{
		//	入力方向を受け取る
		Vector3 directionVector = m_player.getAxisInput;
		if( directionVector != Vector3.zero )
		{
			//	キャラ更新
			m_player.charBase.inputMoveDir	= directionVector;
		}
		else
		{
			//	待機アクションへ
			m_player.action.run(ActionId.eIDLE);
		}		
	}
}
