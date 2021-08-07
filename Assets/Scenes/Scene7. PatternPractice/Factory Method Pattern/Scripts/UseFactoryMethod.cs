using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    public class UseFactoryMethod : MonoBehaviour
    {
        MonsterGenerator[] monsterGenerators = null;
        // MonsterGenerator slimeGenerator = null;
        // 아니면 enum으로 배열 0, 1에 대신 넣을 수도 있지 않을까?

        void Start()
        {
            monsterGenerators = new MonsterGenerator[2];
            monsterGenerators[0] = new GoblinGenerator();
            monsterGenerators[1] = new SlimeGenerator();
        }

        public void MakeGoblin()
        {
            monsterGenerators[0].CreateMonsters();

            List<Monster> monsters = monsterGenerators[0].GetMonsters();

            foreach (Monster monster in monsters)
            {
                monster.Attack();
            }
        }

        public void MakeSlime()
        {
            monsterGenerators[1].CreateMonsters();

            List<Monster> monsters = monsterGenerators[1].GetMonsters();

            foreach (Monster monster in monsters)
            {
                monster.Attack();
            }
        }
    }
}

