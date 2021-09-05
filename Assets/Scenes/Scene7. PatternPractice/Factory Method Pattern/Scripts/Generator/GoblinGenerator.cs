using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    public class GoblinGenerator : MonsterGenerator
    {
        public GameObject GoblinPrefab;

        //monsters = new List<Monster>();

        public override void CreateMonsters()
        {
            if (monsters == null)
            {
                Debug.Log("Goblin Monster 리스트가 비어있습니다.");
                monsters = new List<Monster>();
            }

            Vector3 randomPosition = new Vector3(Random.Range(0f, 10f), 2f, Random.Range(0f, 10f));
            GameObject hi = Instantiate(GoblinPrefab, randomPosition, Quaternion.identity);

            monsters.Add(new Goblin());
        }
    }
}