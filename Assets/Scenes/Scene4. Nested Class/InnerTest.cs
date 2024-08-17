using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NestedClassPractice
{
    public class OuterClass
    {
        private int outerMember;

        public class NestedClass
        {
            public int nestNumber;

            public NestedClass()
            {
                this.nestNumber = 20;
            }
        }
    }

    public class InnerTest : MonoBehaviour
    {
        void Start()
        {
            OuterClass.NestedClass nest = new OuterClass.NestedClass();
            Debug.Log("nestNumber : " + nest.nestNumber);
        }
    }
}