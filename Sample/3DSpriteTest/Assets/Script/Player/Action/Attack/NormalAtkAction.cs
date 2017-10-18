using UnityEngine;
using System.Collections;

/*
 * 	@brief	コールバックで呼ばれたコリジョン先のデータ受け渡し
 * 	@note	もっといい方法がないかな～
 */
public class NormatlAtkActionSendData : MonoBehaviour
{
	public NormalAtkAction.param	m_param;
}

public class NormalAtkAction : BaseAction
{
	[System.Serializable]
	public	class param
	{
		public	Vector3	pos	= Vector3.zero;
		public	int	power	= 1;
		public	float	length	= 1;
		public	float	radius	= 1;
		public	float	time	= 0.5f;

		[System.NonSerializedAttribute]
		public	Vector3	offsetPos	= Vector3.zero;
	}

	private	GameObject	m_hitObject	= null;
	private	param	m_param	= null;
	private	float	m_timer	= 0;

	public NormalAtkAction( ActionId in_id, ActionPriority in_priority ) :
		base( in_id, in_priority )
	{
	}
	
	public	override	bool	initialize( ref Player in_player, object in_data )
	{
		//	
		base.initialize( ref in_player, in_data );
		
		if( in_data != null )
		{
			m_param	= in_data as param;
		}
		else
		{
			m_param	= new param();
		}

		m_hitObject	= new GameObject();
		m_hitObject.transform.parent	= in_player.transform;

		SphereCollider	collider	= m_hitObject.AddComponent<SphereCollider>();
		
		/*
		 * コンポーネントに追加することでデータの受け渡しを成立させている( このやり方はかなりむりやりな感じ)
		 */
		NormatlAtkActionSendData	sendData	= m_hitObject.AddComponent<NormatlAtkActionSendData>();
		sendData.m_param	= m_param;

		collider.radius	= m_param.radius;
		collider.isTrigger	= true;
		collider.name	= "normal_atk";
		collider.transform.position	= m_param.offsetPos + m_player.transform.position;
		collider.tag	= in_player.tag;
		
		return	true;
	}

	/*
	 * 	@brief
	 */
	public	override	void	finalize()
	{
		base.finalize();
		
		if( m_hitObject != null )
		{
			Object.Destroy(m_hitObject);
		}
		
		m_hitObject	= null;
	}

	/*
	 * 	@brief	アクション実行可能かどうか
	 */
	public override	bool	isAction( ref Player in_player )
	{
		return	base.isAction( ref in_player );
	}
	
	/*
	 * 	@brief	更新
	 */
	public	override void	updateFunc()
	{
		m_timer	+= Time.deltaTime;
		if( m_param.time <= m_timer )
		{
			m_player.action.run(ActionId.eIDLE);
		}
	}
}
