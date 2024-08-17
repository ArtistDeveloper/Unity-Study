using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid grid;
    private Vector3 testVecPosition;
    private Vector3 worldPosition;
    private Vector3 testTouchPosition;

    private void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(20, 0 , 0));
        // new Grid(2, 5, 5f, new Vector3(0, 0, -20));
        // new Grid(10, 10, 20f, new Vector3(-100, 0, 20));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //3D프로젝트 마우스의 포지션을 가져오기.
            testTouchPosition = MouseTouch3D.GetWolrdMousePosition3D();
            grid.SetValue(testTouchPosition, 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            testTouchPosition = MouseTouch3D.GetWolrdMousePosition3D();
            Debug.Log(grid.GetValue(testTouchPosition));
        }
    }
}


