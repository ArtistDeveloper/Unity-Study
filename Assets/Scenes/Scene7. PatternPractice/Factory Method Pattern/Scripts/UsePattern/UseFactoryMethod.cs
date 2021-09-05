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

            //List<Monster> monsters = monsterGenerators[(int)MonsterType.Goblin].GetMonsters();

        }

        public void MakeSlime()
        {
            monsterGenerators[(int)MonsterType.Slime].CreateMonsters();

            List<Monster> monsters = monsterGenerators[(int)MonsterType.Slime].GetMonsters();
        }

        public void IndexCheck()
        {
            Debug.Log(monsterGenerators[(int)MonsterType.Goblin].monsters.Count);
        }
    }
}

