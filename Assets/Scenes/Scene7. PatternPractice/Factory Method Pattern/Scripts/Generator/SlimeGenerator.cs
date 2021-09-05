using UnityEngine;
using System.Collections.Generic;

namespace Scene7FMP
{
    public class SlimeGenerator : MonsterGenerator
    {
        public GameObject SlimePrefab;

        public override void CreateMonsters()
        {
            if (monsters == null)
            {
                Debug.Log("Slime Monster 리스트가 비어있습니다.");
                monsters = new List<Monster>();
            }

            Vector3 randomPosition = new Vector3(Random.Range(0f, 10f), 2f, Random.Range(0f, 10f));
            GameObject hi = Instantiate(SlimePrefab, randomPosition, Quaternion.identity);

            monsters.Add(new Goblin());
        }
    }
}

