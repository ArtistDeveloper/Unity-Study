using System.Collections.Generic;

namespace Scene7FMP
{
    public abstract class MonsterGenerator
    {
        public List<Monster> monsters = new List<Monster>();

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

        public abstract void CreateMonsters();
    }
}
