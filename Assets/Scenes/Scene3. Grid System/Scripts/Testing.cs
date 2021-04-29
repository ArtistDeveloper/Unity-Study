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
        grid = new Grid(4, 2, 10f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // grid.SetValue(UtilsClass.GetMouseWorldPositionWithZ(), 56);
            // testVecPosition = UtilsClass.GetMouseWorldPositionWithZ();
            // Debug.Log(testVecPosition);
            // worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(worldPosition);

            //3D프로젝트 마우스의 포지션을 가져오기.
            testTouchPosition = MouseTouch3D.GetWolrdMousePosition3D();
            Debug.Log(testTouchPosition);
        }
    }
}

