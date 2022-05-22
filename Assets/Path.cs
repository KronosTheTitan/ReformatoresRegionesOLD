using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    [SerializeField,HideInInspector]
    List<Vector2> _points;

    public Path(Vector2 center)
    {
        _points = new List<Vector2>
        {
            center+Vector2.left,
            center+(Vector2.left+Vector2.up)*.5f,
            center + (Vector2.right+Vector2.down)*.5f,
            center+Vector2.right
        };
    }

    public Vector2 this[int i]
    {
        get
        {
            return _points[i];
        }
    }

    public int NumPoints
    {
        get
        {
            return _points.Count;
        }
    }

    public int NumSegments
    {
        get
        {
            return (_points.Count - 4) / 3 + 1;
        }
    }

    public void AddSegment(Vector2 anchorPos)
    {
        _points.Add(_points[_points.Count - 1] * 2 - _points[_points.Count - 2]);
        _points.Add((_points[_points.Count - 1] + anchorPos) * .5f);
        _points.Add(anchorPos);
    }

    public Vector2[] GetPointsInSegment(int i)
    {
        return new Vector2[] { _points[i * 3], _points[i * 3 + 1], _points[i * 3 + 2], _points[i * 3 + 3] };
    }

    public void MovePoint(int i, Vector2 pos)
    {
        _points[i] = pos;
    }
}
