using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    public class GoblinGenerator : MonsterGenerator
    {
        public GameObject GoblinPrefab;
        private void Start()
        {
            /// <summary>
            /// UseFactoryMethod.cs에서 AddComponent를 사용하여, 컴포넌트를 추가해주었기에 기존에 인스펙터 창에서 
            /// 프리팹을 이어주어봤자 새로운 컴포넌트에서 프리팹을 찾으려 하기에 못찾아왔던 것이다. 어쨌든,
            /// Resource.Load는 경로를 통해 프리팹을 무조건 적으로 가져오기에 코드 실행이 정상적인 것처럼 보였던 것이다.
            /// </summary>
            /// <returns></returns>
            GoblinPrefab = Resources.Load("GoblinePrefab") as GameObject;
        }

        public override void CreateMonsters()
        {
            for (int i = 0; i < 1; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(0f, 10f), 2f, Random.Range(0f, 10f));
                if (GoblinPrefab == null) Debug.Log("프리팹이 비어있음");
                GameObject hi = Instantiate(GoblinPrefab, randomPosition, Quaternion.identity);

                // monsters.Add(new Goblin());
            }
        }
    }
}