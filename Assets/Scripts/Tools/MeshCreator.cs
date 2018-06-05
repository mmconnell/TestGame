using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tools
{
    public class MeshCreator
    {
        public static Mesh MakeCircle(int numOfPoints, float radius, Vector3 center)
        {
            float angleStep = 360.0f / (float)numOfPoints;
            List<Vector3> vertexList = new List<Vector3>();
            List<int> triangleList = new List<int>();
            Quaternion quaternion = Quaternion.Euler(0f, 0f, angleStep);
            // Make first triangle.
            vertexList.Add(new Vector3(0f, 0f, 0f));    // 1. Circle center.
            vertexList.Add(new Vector3(0f, radius, 0f));  // 2. First vertex on circle outline \
            vertexList.Add(quaternion * vertexList[1]);       // 3. First vertex on circle outline rotated by angle)
                                                              // Add triangle indices.
            triangleList.Add(0);
            triangleList.Add(1);
            triangleList.Add(2);
            for (int i = 0; i < numOfPoints - 1; i++)
            {
                triangleList.Add(0);                      // Index of circle center.
                triangleList.Add(vertexList.Count - 1);
                triangleList.Add(vertexList.Count);
                vertexList.Add(quaternion * vertexList[vertexList.Count - 1]);
            }
            triangleList.Reverse();
            Mesh mesh = new Mesh
            {
                vertices = vertexList.ToArray(),
                triangles = triangleList.ToArray()
            };
            return mesh;
        }

        public static void DrawCircle(LineRenderer line, int segments, float radius, float width)
        {
            float x;
            float y;
            float z = 0f;
            line.startWidth = width;
            line.endWidth = width;
            line.positionCount = segments + 1;

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
}
