using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    public class UseFactoryMethod : MonoBehaviour
    {
        // MonsterGenerator[] monsterGenerators = new MonsterGenerator[2];
        MonsterGenerator[] monsterGenerators = new MonsterGenerator[2];

        private void Start()
        {
            GameObject findGameObject = GameObject.Find("EntireGeneratorManager");
            monsterGenerators[(int)MonsterType.Goblin] = findGameObject.GetComponent<GoblinGenerator>();
            monsterGenerators[(int)MonsterType.Slime] = findGameObject.GetComponent<SlimeGenerator>();
        }

        private void Update()
        {
            IndexCheck();
        }


        public void MakeGoblin()
        {
            monsterGenerators[(int)MonsterType.Goblin].CreateMonsters();

            List<Monster> monsters = monsterGenerators[(int)MonsterType.Goblin].GetMonsters();

            // foreach (Monster monster in monsters)
            // {
            //     // monster.Attack();
            // }
        }

        public void MakeSlime()
        {
            monsterGenerators[(int)MonsterType.Slime].CreateMonsters();

            List<Monster> monsters = monsterGenerators[(int)MonsterType.Slime].GetMonsters();

            // foreach (Monster monster in monsters)
            // {
            //     monster.Attack();
            // }
        }

        public void IndexCheck()
        {
            if (Input.GetKeyDown("q"))
            {
                //for (int i = 0; i < monsterGenerators[0].monsters.Count; i++)
                //{
                //    Debug.Log(monsterGenerators[0].monsters[i]);
                //}
                Debug.Log(monsterGenerators[0].monsters.Count);
                //Debug.Log(monsterGenerators[0].GetMonsters());
            }
        }
    }
}

