using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene14
{
    public class TimeTest : MonoBehaviour
    {
        private float distancePerSecond;

        private void Start()
        {
            distancePerSecond = 1f;
            Application.targetFrameRate = 30;
            // Application.targetFrameRate = 60;

            Debug.Log($"스칼라 곱 구하기 : {Vector3.forward * 2.5f}"); // 0.03을 곱했을 떄, 0,0,0으로 나와서 이상했는데 그냥 0이하 소수점 자리 출력이 안됐었던 것 같다.
        }

        private void Update()
        {
            // 프레임에 따라 캐릭터가 움직이는 속도가 달라진다.
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = transform.position + Vector3.forward * Time.deltaTime;
                // transform.Translate(0, 0, distancePerSecond * Time.deltaTime);
            }
        }
    }
}
