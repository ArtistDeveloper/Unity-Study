using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTouch3D
{
    public static Vector3 GetWolrdMousePosition3D()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.point;    
        }
        else
        {
            return Vector3.zero;
        }
    }
}

