using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegatePracticeScene
{
    public class DelegatePracB : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            // DelegatePracA a = GameObject.Find("a").GetComponent<DelegatePracA>();
            var a = FindObjectOfType<DelegatePracA>();
            a.outFunctionDelegate += F1;
        }

        // Update is called once per frame
        public void F1()
        {
            Debug.Log("DelegatePracB에서 F1함수가 호출되었습니다.");
        }
    }
}
