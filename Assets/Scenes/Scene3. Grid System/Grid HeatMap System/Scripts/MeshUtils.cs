using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHeatMap
{
    public class MeshUtils
    {
        private static Quaternion[] cachedQuaternionEulerArr;

        public static void CreateEmptyMeshArrays(int quadCount, out Vector3[] vertices, out Vector2[] uvs, out int[] triangles)
        {
            vertices = new Vector3[4 * quadCount];
            uvs = new Vector2[4 * quadCount];
            triangles = new int[6 * quadCount];
        }

        private static void CacheQuaternionEuler()
        {
            if (cachedQuaternionEulerArr != null) return;
            cachedQuaternionEulerArr = new Quaternion[360];
            for (int i = 0; i < 360; i++)
            {
                cachedQuaternionEulerArr[i] = Quaternion.Euler(0, 0, i);
            }
        }

        private static Quaternion GetQuaternionEuler(float rotFloat)
        {
            int rot = Mathf.RoundToInt(rotFloat);
            rot = rot % 360;
            if (rot < 0) rot += 360;
            //if (rot >= 360) rot -= 360;
            if (cachedQuaternionEulerArr == null) CacheQuaternionEuler();
            return cachedQuaternionEulerArr[rot];
        }

        public static void AddToMeshArrays(Vector3[] vertices, Vector2[] uvs, int[] triangles, int index, Vector3 pos, float rot, Vector3 baseSize, Vector2 uv00, Vector2 uv11)
        {
            //Relocate vertices
            int vIndex = index * 4;
            int vIndex0 = vIndex;
            int vIndex1 = vIndex + 1;
            int vIndex2 = vIndex + 2;
            int vIndex3 = vIndex + 3;

            baseSize *= .5f;

            bool skewed = baseSize.x != baseSize.y;
            if (skewed)
            {
                vertices[vIndex0] = pos + GetQuaternionEuler(rot) * new Vector3(-baseSize.x, baseSize.y);
                vertices[vIndex1] = pos + GetQuaternionEuler(rot) * new Vector3(-baseSize.x, -baseSize.y);
                vertices[vIndex2] = pos + GetQuaternionEuler(rot) * new Vector3(baseSize.x, -baseSize.y);
                vertices[vIndex3] = pos + GetQuaternionEuler(rot) * baseSize;
            }
            else
            {
                vertices[vIndex0] = pos + GetQuaternionEuler(rot - 270) * baseSize;
                vertices[vIndex1] = pos + GetQuaternionEuler(rot - 180) * baseSize;
                vertices[vIndex2] = pos + GetQuaternionEuler(rot - 90) * baseSize;
                vertices[vIndex3] = pos + GetQuaternionEuler(rot - 0) * baseSize;
            }

            //Relocate UVs
            uvs[vIndex0] = new Vector2(uv00.x, uv11.y);
            uvs[vIndex1] = new Vector2(uv00.x, uv00.y);
            uvs[vIndex2] = new Vector2(uv11.x, uv00.y);
            uvs[vIndex3] = new Vector2(uv11.x, uv11.y);

            //Create triangles
            int tIndex = index * 6;

            triangles[tIndex + 0] = vIndex0;
            triangles[tIndex + 1] = vIndex3;
            triangles[tIndex + 2] = vIndex1;

            triangles[tIndex + 3] = vIndex1;
            triangles[tIndex + 4] = vIndex3;
            triangles[tIndex + 5] = vIndex2;
        }
    }
}

