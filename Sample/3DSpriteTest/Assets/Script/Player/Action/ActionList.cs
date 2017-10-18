using System;

public	enum ActionId 
{
	eIDLE	= 0,
	eMOVE,
	eNORMAL_DAMAGE,
	eDIE,
	eNORAML_ATK,
	eFREE_ACT01,
	eFREE_ACT20	= eFREE_ACT01 + 20,
	eMAX,
	eNONE,
}

public	enum ActionPriority 
{
	eNONE	= -1,
	eNORMAL	= 0,
	eMOVE,
	eATK,
	eDAMAGE,
	eDIE
}

public class ActionList
{
	public	class DataAction
	{
		public	bool	flg	= true;
		public	BaseAction	action	= null;
	}
	
	public	DataAction[]	dataList	= new DataAction[(int)ActionId.eMAX];
	
	public	ActionList()
	{
		for( int i = 0; i < (int)ActionId.eMAX; ++i )
		{
			dataList[i]	= new DataAction();
		}

		dataList[(int)ActionId.eIDLE].action	= new IdleAction(ActionId.eIDLE, ActionPriority.eNORMAL);
		dataList[(int)ActionId.eMOVE].action	= new MoveAxisAction(ActionId.eMOVE, ActionPriority.eMOVE);
		dataList[(int)ActionId.eNORMAL_DAMAGE].action	= new NormalDmgAction(ActionId.eNORMAL_DAMAGE, ActionPriority.eDAMAGE);
		dataList[(int)ActionId.eDIE].action	= new DieAction(ActionId.eDIE, ActionPriority.eDIE);
		dataList[(int)ActionId.eNORAML_ATK].action	= new NormalAtkAction(ActionId.eNORAML_ATK, ActionPriority.eATK);
	}
}
