using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegatePracticeScene
{
    public class DelegatePracA : MonoBehaviour
    {
        public delegate void OutClassDelegateTest();
        public OutClassDelegateTest outFunctionDelegate;

        private void Start()
        {
            Call();
        }

        public void Call()
        {
            outFunctionDelegate.Invoke();
        }
    }
}
