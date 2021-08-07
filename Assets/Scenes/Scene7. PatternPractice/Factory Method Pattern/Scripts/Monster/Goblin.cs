using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    public class Goblin : Monster
    {
        public Goblin()
        {
            type = MonsterType.Goblin;
            name = "Goblin";
            hp = 200;
            damage = 20;

            Debug.Log(this.name + " 생성");
        }

        public override void Attack()
        {
            Debug.Log(this.name + " - " + this.damage + "데미지 공격");
        }
    }
}
