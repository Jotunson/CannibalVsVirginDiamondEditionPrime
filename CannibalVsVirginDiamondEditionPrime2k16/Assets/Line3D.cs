using UnityEngine;
using System.Collections;

public class Line3D
{
	private Vector3 _start, _end;

	public Line3D(){}
	public Line3D(Vector3 start, Vector3 end)
	{
		_start = start;
		_end = end;
	}

	public Vector3 Start
	{
		get{return _start;}
		set{_start = value;}
	}

	public Vector3 End
	{
		get{return _end;}
		set{_end = value;}
	}
}
