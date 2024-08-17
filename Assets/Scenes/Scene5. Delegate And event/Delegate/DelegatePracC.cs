using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegatePracticeScene
{
    public class DelegatePracC : MonoBehaviour
    {
        // Start is called before the first frame update
        void Awake()
        {
            // DelegatePracA a = GameObject.Find("a").GetComponent<DelegatePracA>();
            var a = FindObjectOfType<DelegatePracA>();
            a.outFunctionDelegate += F2;
        }

        // Update is called once per frame
        public void F2()
        {
            Debug.Log("DelegatePracC에서 F2함수가 호출되었습니다.");
        }
    }
}
