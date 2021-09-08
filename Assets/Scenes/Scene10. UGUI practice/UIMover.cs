using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMover : MonoBehaviour
{
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // anchoredPosition : 앵커를 기준으로 한 RectTransform의 피벗   위치입니다.
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rectTransform.anchoredPosition = Input.mousePosition;
            Debug.Log("mouse position : " + Input.mousePosition);
            Debug.Log("anchoredPosition = " + rectTransform.anchoredPosition);
        }

        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta * 1.1f;
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            rectTransform.sizeDelta = rectTransform.sizeDelta * 0.9f;
        }
    }
}
