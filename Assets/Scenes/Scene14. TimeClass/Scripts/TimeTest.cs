using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTest : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        Debug.Log(Time.deltaTime);
    }
}
