using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatePracLocalScript : MonoBehaviour
{
    public delegate void CallBackDeleagate(int a, int b);

    void Start()
    {
        CallBackDeleagate deleagate1 = Plus;
        CallBackDeleagate deleagate2 = Minus;
    
        Debug.Log("DelegatePracLocalScript의 테스트입니다. ");
        //Invoke를 사용하여도 같은 결과가 나옵니다.
        deleagate1(5, 10); //deleagate1.Invoke(5, 10);
        deleagate2(5, 10); //deleagate2.Invoke(5, 10);

    }

    // Update is called once per frame
    void Plus(int a, int b)
    {
        Debug.Log("a + b = " + (a + b));
    }

    void Minus(int a, int b)
    {
        Debug.Log("a - b = " + (a - b));
    }
}
