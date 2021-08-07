namespace Scene7FMP
{
    public class GoblinGenerator : MonsterGenerator
    {
        public override void CreateMonsters()
        {
            for (int i = 0; i < 3; i++)
            {
                monsters.Add(new Goblin());
            }
        }
    }
}