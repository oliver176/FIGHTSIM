namespace FightSimV2
{
    internal class Goblin : Creature
    {
        private int goblinArmor = 2;

        public Goblin()
        {
            maxHP = 800 * statModifier;
            SetName("Goblin");
            hp = maxHP * statModifier;
            armor = goblinArmor;
        }

        public override void ModifyStats(int playerLevel)
        {
            statModifier = playerLevel; //Improve stats beroende på lvl
            hp = maxHP * statModifier;
            armor *= statModifier;
            minDmg *= statModifier;
            maxDmg *= statModifier;
        }

        public override int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(minHitChance, maxHitChance);
            if (hitChance > 20)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }

        public override int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(minHitChance, maxHitChance);
            if (hitChance > 66)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
        }
    }
}