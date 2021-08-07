using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    // enum사용하기
    // 1. 명시적 캐스팅을 사용하여 배열 인덱스안에 enum을 사용하기
    public class UseFactoryMethod : MonoBehaviour
    {
        MonsterGenerator[] monsterGenerators = null;

        void Start()
        {
            monsterGenerators = new MonsterGenerator[2];
            monsterGenerators[(int)MonsterType.Goblin] = new GoblinGenerator();
            monsterGenerators[(int)MonsterType.Slime] = new SlimeGenerator();
        }

        public void MakeGoblin()
        {
            monsterGenerators[(int)MonsterType.Goblin].CreateMonsters();

            List<Monster> monsters = monsterGenerators[(int)MonsterType.Goblin].GetMonsters();

            foreach (Monster monster in monsters)
            {
                monster.Attack();
            }
        }

        public void MakeSlime()
        {
            monsterGenerators[(int)MonsterType.Slime].CreateMonsters();

            List<Monster> monsters = monsterGenerators[(int)MonsterType.Slime].GetMonsters();

            foreach (Monster monster in monsters)
            {
                monster.Attack();
            }
        }
    }
}

