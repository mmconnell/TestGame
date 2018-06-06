using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
    public int segments;
    public float radius;
    LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = segments;
        CreatePoints();
    }


    void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 0f;

        Vector3[] positions = new Vector3[segments + 1];
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle);
            y = Mathf.Cos(Mathf.Deg2Rad * angle);
            positions[i] = (new Vector3(x, y, z) * radius);
            angle += (360f / segments);
        }
        line.SetPositions(positions);
    }
}
