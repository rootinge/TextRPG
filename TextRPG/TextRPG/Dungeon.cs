namespace TextRPG
{
    internal class Dungeon
    {
        public string name;
        public int defensive;
        public int clearGold;

        public int minDamage;
        public int maxDamage;

        private Random random;

        public Dungeon(string name,int defensive, int clearGold)
        {
            this.name = name;
            this.defensive = defensive;
            this.clearGold = clearGold;

            minDamage = 20;
            maxDamage = 35;

            random = new Random();
        }

        public int DungeonDamage()
        {
            int defenseDifference = defensive - Player.Instance.defense;
            int damage = random.Next(minDamage + defenseDifference,maxDamage + defenseDifference + 1);

            return damage;
        }

        public int DungeonClaer()
        {
            return clearGold + random.Next(clearGold / Player.Instance.power, clearGold / (Player.Instance.power * 2) - 1);
        }

    }
}
