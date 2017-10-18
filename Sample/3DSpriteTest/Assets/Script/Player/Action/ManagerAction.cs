using UnityEngine;
using System.Collections;

public class ManagerAction
{	
	private	ActionList	m_actionlist	= null;
	private	BaseAction	m_runAction	= null;
	private	Player	m_player	= null;
		
	/*
	 * 	@brief	死亡中かチェック
	 */
	public static	bool	isDie( ref Player in_player )
	{
		if( in_player )
		{
			ActionId	runActId	= in_player.action.runningId;
			if( (runActId == ActionId.eDIE) || in_player.isDie )
			{
				return	true;
			}
		}
		
		return	false;
	}
	
	/*
	 * 	@brief	ダメージ中かチェック
	 */	
	public	static	bool	isDamage( ref Player in_player )
	{
		if( in_player )
		{
			ActionId	runActId	= in_player.action.runningId;
			if( runActId == ActionId.eNORMAL_DAMAGE )
			{
				return	true;
			}
		}
		
		return	false;
	}

	public	ManagerAction( ref Player in_player, ref ActionList in_actionList )
	{
		m_actionlist	= in_actionList;
		m_player	= in_player;
	}

	/*
	 * 	@brief
	 */
	public	void	update()
	{
		if( m_runAction != null )
		{
			m_runAction.updateFunc();

			if( m_runAction.isEndAction() )
			{
				m_runAction.finalize();
				m_runAction	= null;
			}
		}
	}

	/*
	 * 	@brief	実行中のアクションID
	 */
	public	ActionId	runningId
	{
		get
		{
			return	m_runAction != null ? m_runAction.id : ActionId.eNONE;
		}
	}
	
	/*
	 * 	@brief	アクション実行中のアクション優先度
	 */
	public	ActionPriority	runningPriority
	{
		get
		{
			return	m_runAction != null ? m_runAction.priority : ActionPriority.eNONE;
		}
	}
	
	/*
	 * 	@brief	指定したアクション実行(強制的に変更可能)
	 */
	public	bool	run( ActionId in_id )
	{
		return	run ( in_id, null );
	}

	public	bool	run( ActionId in_id, object in_obj )
	{
		return	run ( in_id, in_obj, ActionPriority.eNONE );
	}

	public	bool	runFromPrority( ActionId in_id )
	{
		return	runFromPrority( in_id, null );
	}
	
	/*
	 * 	@brief	優先度を参照して変更するか決める
	 */
	public	bool	runFromPrority( ActionId in_id, object in_obj )
	{
		ActionPriority	priority	= ActionPriority.eNORMAL;
		if( m_runAction != null )
		{
			priority	= m_runAction.priority;
		}

		return	run ( in_id, in_obj, priority );
	}

	/*
	 * 	@brief	指定したアクション実行
	 */
	private	bool	run( ActionId in_id, object in_obj, ActionPriority in_priority )
	{
		if( (m_runAction != null) && (m_runAction.id == in_id) )
		{
			//	同じアクションは実行できない
	//		Debug.Log("error: running: " + m_runAction + " = " + in_id);
			return	false;
		}

		bool	bRun	= false;
		BaseAction	action	= null;
		foreach( ActionList.DataAction dataAct in m_actionlist.dataList )
		{
			action	= dataAct.action;
			if( (action != null) && (action.id == in_id) )
			{				
				break;
			}
		}

		if( (action != null) && (action.isAction( ref m_player )) )
		{
			bRun	= true;
			if( m_runAction != null )
			{
				//	変更アクションの優先度が実行アクションの優先度未満だと実行できない
				if(in_priority <= action.priority)
				{
					m_runAction.finalize();
				}
				else
				{
					bRun	= false;
				}
			}
				
			if( bRun == true )
			{
				if( action.initialize( ref m_player, in_obj ) )
				{
					m_runAction	= action;
		//			Debug.Log ("change action: " + action);	
					
					return	true;
				}
			}
		}

	//	Debug.Log ("error: runAction= " + in_id);
		
		return	false;
	}
}
