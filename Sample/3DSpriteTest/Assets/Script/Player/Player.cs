using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharCtrl))]
[RequireComponent(typeof(DebugUtils))]

//	強制追加コンポーネント
[AddComponentMenu ("Character/Platform Input Controller")]

/*
 * 	@brief	基本パラメータ
 */
[System.Serializable]
public	class PlayerParam
{
	public	int	hp	= 1;
}

public class Player : MonoBehaviour {
	
	public	PlayerParam	playerParam	= new PlayerParam();
	private	ActionList	actionList	= new ActionList();
	
	protected	bool	mb_dead	= false;

	private	CharCtrl	m_charCtrl	= null;
	private	ManagerAction	m_managerAction	= null;
	
	public virtual void Awake ()
	{
		m_charCtrl	= GetComponent<CharCtrl>() as CharCtrl;
		DebugUtils.Asseert(m_charCtrl);
		
		Player	play	= this;
		m_managerAction	= new ManagerAction(ref play, ref actionList);
		DebugUtils.Asseert(m_managerAction != null);
	}

	// Use this for initialization
	public virtual void Start ()
	{
		mb_dead	= false;
	}

	// Update is called once per frame
	public virtual void Update ()
	{
		if( m_charCtrl.pause == true )
		{
			return;
		}
		
		m_managerAction.update();
	}
	
	/*
	 * 	@brief	死亡宣告
	 */
	public	virtual	void	dead()
	{
		mb_dead	= true;
	}
	
	/*
	 * 	@brief	独自に用意したアクションに切り替え
	 */
	public	void	setAction( ref BaseAction in_act, ActionId in_id )
	{
		DebugUtils.Asseert(in_act != null);
		//	
		actionList.dataList[(int)in_id].action	= in_act;
		actionList.dataList[(int)in_id].flg	= true;
	}
	
	public	CharCtrl	charBase
	{
		get
		{
			return	m_charCtrl;
		}
	}
	
	public	ManagerAction	action
	{
		get
		{
			return	m_managerAction;
		}
	}
	
	public	Vector3	getAxisInput
	{
		get
		{
			PlayerInput	input	= GetComponent<PlayerInput>() as PlayerInput;
			if( input )
			{
				return	input.getAxis;
			}
			
			return	Vector3.zero;
		}
	}
	
	public	PlayerParam	param
	{
		get
		{
			return	playerParam;
		}
		
		set
		{
			playerParam	= value;
		}
	}
	
	public	bool	isDie
	{
		get
		{
			return	mb_dead;
		}
	}
}
