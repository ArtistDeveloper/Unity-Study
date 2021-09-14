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
            // if (Input.GetKey("q"))
            // {
            //     IndexCheck();
            // }
        }


        public void MakeGoblin()
        {
            monsterGenerators[(int)MonsterType.Goblin].CreateMonsters();
        }

        public void MakeSlime()
        {
            monsterGenerators[(int)MonsterType.Slime].CreateMonsters();
        }

        public void IndexCheck()
        {
            Debug.Log("소환된 고블린의 수 : " + monsterGenerators[(int)MonsterType.Goblin].monsters.Count);
            Debug.Log("소환된 슬라임의 수 : " + monsterGenerators[(int)MonsterType.Slime].monsters.Count);
        }
    }
}

