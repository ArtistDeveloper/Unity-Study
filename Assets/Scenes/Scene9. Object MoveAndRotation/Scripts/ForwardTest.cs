using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene9
{
    public class ForwardTest : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(transform.forward);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                // transform.Translate(Vector3.forward * Time.deltaTime);
                // transform.Translate(transform.forward * Time.deltaTime);
                transform.position = transform.position + (transform.forward * 1 * Time.deltaTime);
            }
        }
    }
}