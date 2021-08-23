using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    public class GoblinGenerator : MonsterGenerator
    {
        public GameObject GoblinPrefab;

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