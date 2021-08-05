using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene7FMP
{
    public class Slime : Monster
    {
        public Slime()
        {
            type = MonsterType.Slime;
            name = "Slime";
            hp = 100;
            damage = 10;

            Debug.Log(this.name + "생성");
        }

        public override void Attack()
        {
            Debug.Log(this.name + " - " + this.damage + "데미지 공격");
        }
    }
}
