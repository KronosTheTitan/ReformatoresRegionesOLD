using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    [SerializeField,HideInInspector]
    List<Vector2> points;

    public Path(Vector2 center)
    {
        points = new List<Vector2>
        {
            center+Vector2.left,
            center+(Vector2.left+Vector2.up)*.5f,
            center + (Vector2.right+Vector2.down)*.5f,
            center+Vector2.right
        };
    }
}