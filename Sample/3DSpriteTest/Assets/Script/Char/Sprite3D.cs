using UnityEngine;
using System.Collections;

public class Sprite3D : MonoBehaviour
{
    /*
	 * 	memo
	 * 	カメラの回転軸を参照してスプライト回転している
		スプライト回転はメッシュの頂点座標を変更している。
		（回転情報をいじるとリジットボディなどで不具合がでるので）
	 */
    public Camera MainCamera = null;

	private	const int	ms_vertecesNum	= 4;
	private	Vector3[]	ma_tmpVerteces;

	// Use this for initialization
	void Start ()
	{
		Mesh	mesh	= GetComponent<MeshFilter>().mesh;
		DebugUtils.Asseert(mesh != null);
		DebugUtils.Asseert(mesh.vertices.Length == ms_vertecesNum);

		ma_tmpVerteces	= mesh.vertices;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Camera	mainCamera	= MainCamera;
		Vector3	v	= -mainCamera.transform.rotation.eulerAngles;
		v.y	= -v.y;

		v.x	+= 90;
		v.y	+= 180;
		
		//	calc mesh vertects point
		Matrix4x4	mat	= new Matrix4x4();
		mat.SetTRS( Vector3.zero, Quaternion.Euler(v), Vector3.one);

		Mesh	mesh	= GetComponent<MeshFilter>().mesh;
		Vector3[]	aSetVerteces	= new Vector3[ms_vertecesNum];
		for( int i = 0; i < ma_tmpVerteces.Length; ++i )
		{
			aSetVerteces[i]	= mat.MultiplyPoint(ma_tmpVerteces[i]);
		}

		mesh.vertices	= aSetVerteces;
	}
}