using UnityEngine;
using System.Collections.Generic;

namespace Scene7FMP
{

    public abstract class MonsterGenerator : MonoBehaviour
    {
        public List<Monster> monsters;

        private void Start()
        {
            monsters = new List<Monster>();
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

        public abstract void CreateMonsters();
    }
}
