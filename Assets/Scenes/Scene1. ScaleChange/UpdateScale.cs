using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScale : MonoBehaviour
{
    private Transform cubeTransform;
    private Vector3 scaleChange;
    private Vector3 threshold;
    private float time;
    private const float scala = 3f / 5f;


    // Scale증가시키기
    // void Start()
    // {
    //      cubeTransform = GetComponent<Transform>();
    //      scaleChange = new Vector3(+0.01f, +0.01f, +0.01f);
    //      threshold  = new Vector3(3f, 3f, 3f);
    // }


    // void Update()
    // {
    //     if (cubeTransform.localScale.x < threshold.x)
    //     {
    //         cubeTransform.localScale += scaleChange;
    //         Debug.Log(cubeTransform.localScale);
    //     }
    // }


    // deltaTime을 사용하여 5초가 되었을 때 scale이 3이되게 만들기.
    void Start()
    {
        cubeTransform = GetComponent<Transform>();
        scaleChange = new Vector3(+0.01f, +0.01f, +0.01f);
        threshold = new Vector3(3f, 3f, 3f);
    }


    void Update()
    {
        time += Time.deltaTime;
        if (time < 5)
        {
            cubeTransform.localScale = new Vector3(time * scala, time * scala, time * scala);
            Debug.Log(cubeTransform.localScale);
            Debug.Log(time);
        }
        else
        {
            time = 5;
            cubeTransform.localScale = new Vector3(3, 3, 3);
            Debug.Log(time);
            Debug.Log(cubeTransform.localScale);
        }
    }
}
