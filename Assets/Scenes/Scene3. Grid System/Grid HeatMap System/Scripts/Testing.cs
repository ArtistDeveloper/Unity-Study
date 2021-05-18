using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridHeatMap
{
    public class Testing : MonoBehaviour
    {
        //HeatMapVisual 이 필드에 스크립트 컴포넌트가 추가된 게임오브젝트를 인스펙터에서 할당할 수 있다.
        [SerializeField] private HeatMapVisual heatMapVisual; 
        private Grid grid;

        private void Start()
        {
            grid = new Grid(20, 10, 10f, Vector3.zero);
            heatMapVisual.SetGrid(grid);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = MouseTouch3D.GetWolrdMousePosition3D();
                int value = grid.GetValue(position);
                grid.SetValue(position, value + 5);
            }
        }
    }
}
