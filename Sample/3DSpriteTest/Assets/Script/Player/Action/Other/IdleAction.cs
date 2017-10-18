using System;

public class IdleAction : BaseAction
{
	public IdleAction( ActionId in_id, ActionPriority in_priority )
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
}

