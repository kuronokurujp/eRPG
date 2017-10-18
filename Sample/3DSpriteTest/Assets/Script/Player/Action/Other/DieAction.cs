using System;

/*
 * 	@brief	死亡アクション
 */
public class DieAction : BaseAction
{
	public DieAction( ActionId in_id, ActionPriority in_priority )
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
		
		//	プレイヤーに死亡通知
		m_player.dead();
	}

	/*
	 * 	@brief	更新
	 */
	public	override void	updateFunc()
	{
		endAction();
	}
}

