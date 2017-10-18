using System;
using System.Diagnostics;

public	class DebugUtils
{
	static public void	Asseert(bool in_bCondition)
	{
#if	DEBUG
		if( in_bCondition == false )
		{
			throw	new Exception();
		}
#endif
	}
}

