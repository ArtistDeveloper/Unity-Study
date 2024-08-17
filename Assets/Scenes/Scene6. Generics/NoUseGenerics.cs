using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene6
{
    public class NoUseGenerics : MonoBehaviour
    {
        void Start()
        {
            int[] intArray = CreateArray(5, 6);
            string[] strArray = CreateArray("NoGeneric", "Test");
            Debug.Log("ArrayLength : " + intArray.Length + " ArrayElement : " + intArray[0] + ", " + intArray[1]);
            Debug.Log("ArrayLength : " + strArray.Length + " ArrayElement : " + strArray[0] + ", " + strArray[1]);
        }

        private int[] CreateArray(int element1, int element2)
        {
            return new int[] { element1, element2 };
        }

        private string[] CreateArray(string element1, string element2)
        {
            return new string[] { element1, element2 };
        }
    }
}

