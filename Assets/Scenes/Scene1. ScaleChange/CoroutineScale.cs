using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene1
{
    public class CoroutineScale : MonoBehaviour
    {
        private Transform cubeTransform;
        private Vector3 scaleChange;

        //1초동안 큐브가 사라지도록 만들기.

        void Start()
        {
            cubeTransform = GetComponent<Transform>();
            scaleChange = new Vector3(-0.1f, -0.1f, -0.1f);
            StartCoroutine(RunFadeScale());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator RunFadeScale()
        {
            while (cubeTransform.localScale.x > 0.0f)
            {
                cubeTransform.localScale += scaleChange;
                Debug.Log(cubeTransform.localScale);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
