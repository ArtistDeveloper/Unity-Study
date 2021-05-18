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
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
        }

        public void SetGrid(Grid grid)
        {
            this.grid = grid;
        }

        //실제로 그리는 코드
        private void UpdateHeatMapVisual()
        {
            MeshUtils.CreateEmptyMeshArrays(grid.Width * grid.Height, out Vector3[] vertices, out Vector2[] uv, out int[] triangles);
        }
    }
}

