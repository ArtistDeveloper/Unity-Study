using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHeatMap
{
    public class MeshUtils
    {
        public static void CreateEmptyMeshArrays(int quadCount, out Vector3[] vertices, out Vector2[] uvs, out int[] triangles)
        {
            vertices = new Vector3[4 * quadCount];
            uvs = new Vector2[4 * quadCount];
            triangles = new int[6 * quadCount];
        }
    }
}

