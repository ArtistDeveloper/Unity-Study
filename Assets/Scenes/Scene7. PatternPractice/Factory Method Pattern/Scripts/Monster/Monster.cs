// FMP : Factory Method Pattern
namespace Scene7FMP
{
    public abstract class Monster
    {
        protected MonsterType type;
        protected string name;
        protected int hp;
        protected int damage;
        public abstract void Attack();
    }
}
