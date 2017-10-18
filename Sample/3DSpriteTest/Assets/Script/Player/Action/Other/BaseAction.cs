using UnityEngine;
using System.Collections;

public class BaseAction //: MonoBehaviour
{
	protected	ActionId	m_id;
	protected	ActionPriority	m_priority	= 0;
	protected	Player	m_player	= null;

	private	bool	mb_update	= false;

	public	BaseAction( ActionId in_id, ActionPriority in_priority )
	{
		m_id	= in_id;
		mb_update	= false;
		m_priority	= in_priority;
	}
	
	/*
	 * 	@brief
	 */
	public	virtual	bool	initialize( ref Player in_player )
	{
		mb_update	= true;
		m_player	= in_player;
		
		return	true;
	}

	public	virtual	bool	initialize( ref Player in_player, object in_data )
	{
		return	initialize( ref in_player );
	}

	/*
	 * 	@brief
	 */
	public	virtual	void	finalize()
	{
		mb_update	= false;
	}

	/*
	 * 	@brief	アクション実行可能かどうか
	 */
	public virtual	bool	isAction( ref Player in_player )
	{
		return	true;
	}
	
	/*
	 * 	@brief	更新
	 */
	public	virtual void	updateFunc()
	{
		
	}
	
	/*
	 * 	@brief	アクション終了したか
	 */
	public	bool	isEndAction()
	{
		return	mb_update == false;
	}
	
	public	void	endAction()
	{
		mb_update	= false;
	}
	
	public	ActionId	id
	{
		get
		{
			return	m_id;
		}
	}
	
	public	ActionPriority	priority
	{
		get
		{
			return	m_priority;
		}
	}
}
