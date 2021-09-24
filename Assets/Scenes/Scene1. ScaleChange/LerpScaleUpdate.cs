using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene1
{
    public class LerpScaleUpdate : MonoBehaviour
    {
        /// <summary>
        /// 코루틴 사용안한 버전.
        /// </summary> 

        // private Vector3 goalScaleSize;
        // private float lerpRatio;
        // private LerpScaleUpdate lerpScaleComponent;

        // private void Start()
        // {
        //     goalScaleSize = new Vector3(10f, 10f, 10f);
        //     lerpRatio = 0f;
        //     lerpScaleComponent = GetComponent<LerpScaleUpdate>();
        // }

        // private void Update()
        // {
        //     // lerp ration를 사용하여 크기를 맞추기 (비추천)
        //     // if (lerpRatio >= 0.99f) // ==으로하면 float는 값을 지나칠 수 있기에 >, <를 사용해야 한다.
        //     // {
        //     //     transform.localScale = goalScaleSize;
        //     //     Debug.Log("스케일이 목표에 도달했습니다.");
        //     //     lerpScaleComponent.enabled = false;
        //     // }
        //     // else
        //     // {
        //     //     transform.localScale = Vector3.Lerp(transform.localScale, goalScaleSize, lerpRatio);
        //     //     lerpRatio += 0.001f;
        //     //     Debug.Log("작동 중");
        //     //     Debug.Log("LerpRatio : " + lerpRatio);
        //     // }


        //     // 델타타임을 사용하여 크기 맞추기. (스케일로 if문 비교)
        //     if (transform.localScale.x >= 9.9f)
        //     {
        //         transform.localScale = goalScaleSize;
        //         Debug.Log("스케일이 목표에 도달했습니다.");
        //         lerpScaleComponent.enabled = false;
        //     }
        //     else
        //     {
        //         transform.localScale = Vector3.Lerp(transform.localScale, goalScaleSize, Time.deltaTime * 0.1f);

        //         //만약 이런식으로 코드를 짜면 무한루프를 돌게된다. transform.localScale이 a값에 들어가야 시작점이 점점 결과값에 가까워지는 그림이 그려진다.
        //         // transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), goalScaleSize, Time.deltaTime * 0.1f);
        //         Debug.Log("작동 중");
        //     }
        // }


        // /// <summary>
        // /// 코루틴 사용한 버전
        // /// </summary>
        private Vector3 goalScaleSize;
        private float lerpRatio;
        private LerpScaleUpdate lerpScaleComponent;
        private float elpasedTime;

        private void Start()
        {
            goalScaleSize = new Vector3(10f, 10f, 10f);
            lerpRatio = 0f;
            lerpScaleComponent = GetComponent<LerpScaleUpdate>();

            StartCoroutine(ChangeScale());
        }

        IEnumerator ChangeScale()
        {
            while (transform.localScale.x <= 9.9f)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, goalScaleSize, Time.deltaTime * 1f);
                elpasedTime += Time.deltaTime;
                Debug.Log("작동 중");
                yield return new WaitForSeconds(0.01f);
            }

            Debug.Log("총 경과시간 : " + elpasedTime);
        }
    }
}

