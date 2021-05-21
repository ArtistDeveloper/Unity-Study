using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHeatMap
{
    public class HeatMapVisual : MonoBehaviour
    {
        private Grid grid;
        private Mesh mesh;

        private void Awake()
        {
            // 메쉬 생성
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
        }

        public void SetGrid(Grid grid)
        {
            this.grid = grid;   
            UpdateHeatMapVisual();
        }

        // 실제로 그리는 코드
        // 이 함수에서 주어진 너비와 높으로 메쉬배열을 만든다.
        private void UpdateHeatMapVisual()
        {
            // 올바른 크기의 로컬 배열을 생성
            // 그런 다음 모든 단일 그리드 위치를 순환하고 메쉬 배열에 쿼드를 추가합니다.
            MeshUtils.CreateEmptyMeshArrays(grid.Width * grid.Height, out Vector3[] vertices, out Vector2[] uv, out int[] triangles);
            
            //너비와 높이를 순환
            for (int x = 0; x < grid.Width; x++) // 10
            {
                for (int z = 0; z < grid.Height; z++) // 5
                {
                    // 이를 통해 모든 쿼드를 순환하는 인덱스를 갖게된다.
                    int index = x * grid.Height + z;
                    Debug.Log(index);
                    Vector3 quadSize = new Vector3(1, 1) * grid.CellSize;

                    MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, z), 0f, quadSize, Vector2.zero, Vector2.zero);
                }
            }

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
        }
    }
}

