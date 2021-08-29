using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene9
{
    public class Move : MonoBehaviour
    {
        public Transform childTransform;

        private void Start()
        {
            transform.position = new Vector3(0, -1, 0);
            // childTransform.localPosition = new Vector3(0, 2, 0);
            childTransform.localPosition = new Vector3(0, 2, 0);


            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));
            childTransform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0));
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
                // transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            }


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
                childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
                // childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime, Space.World);
            }


            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
                childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
            }
        }
    }
}
