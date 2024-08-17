using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene6
{
    public class UseGenerics : MonoBehaviour
    {
        void Start()
        {
            int[] intArray = CreateArray<int>(5, 6);
            string[] strArray = CreateArray<string>("UseGeneric", "Test");
            int[] int2Array = CreateArray(10, 15); // 타입 정의를 생략해도 된다.
            int[] int3Array = CreateArrayCustomType(100, 100);

            Debug.Log("ArrayLength : " + intArray.Length + " ArrayElement : " + intArray[0] + ", " + intArray[1]);
            Debug.Log("ArrayLength : " + strArray.Length + " ArrayElement : " + strArray[0] + ", " + strArray[1]);
            Debug.Log("ArrayLength : " + int2Array.Length + " OmitTypeArrayElement : " + int2Array[0] + ", " + int2Array[1]);
            Debug.Log("ArrayLength : " + int3Array.Length + " CreateArrayCustomTypeArrayElement : " + int3Array[0] + ", " + int3Array[1]);

            Debug.Log("Multiple Generics Test Line");
            MultipleGenerics<int, string>(56, "string입니다.");
        }

        // Generic을 사용하여 함수 하나의 선언으로 두 가지 유형으로 작동하도록 만들었다.
        // Generic Type에 T라는 이름을 사용하는 것이 일반적이다.
        private T[] CreateArray<T>(T element1, T element2)
        {
            return new T[] { element1, element2 };
        }

        //하지만 T말고 Custom Name을 사용할 수 있기도 하다. 그러나 일반적으로 T를 사용하는게 더 좋을 것임.
        private MyCustomType[] CreateArrayCustomType<MyCustomType>(MyCustomType element1, MyCustomType element2)
        {
            return new MyCustomType[] { element1, element2 };
        }

        private void MultipleGenerics<T1, T2>(T1 val, T2 val2)
        {
            Debug.Log(val.GetType());
            Debug.Log(val2.GetType());
        }
    }
}



