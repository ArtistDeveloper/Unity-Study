using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene13
{
    public class VarOrderTest : MonoBehaviour
    {
        [SerializeField] private List<int> intList;

        private void Start()
        {
            intList.Add(3);
            intList.Add(5);
            intList.Add(8);

            foreach (var item in intList)
            {
                Debug.Log($"ListItem : {item}");
            }
        }

        // public int initializationVar = 3;

        // private void Awake()
        // {
        //     initializationVar = 10;
        // }

        // private void Start()
        // {
        //     initializationVar = 20;
        //     Debug.Log($"initializationVar : {initializationVar}");
        // }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Tab))
        //     {
        //         initializationVar = 30;
        //         Debug.Log($"initializationVar : {initializationVar}");
        //     }
        // }
    }
}

