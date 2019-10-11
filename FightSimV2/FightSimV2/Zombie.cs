namespace FightSimV2
{
    internal class Zombie : Creature
    {
        private int zombieArmor = 1;

        public Zombie()
        {
            maxHP = 2000 * statModifier;
            SetName("Zombie");
            hp = maxHP;
            armor = zombieArmor;
            Mace();
        }

        public override void ModifyStats()
        {
            statModifier = level; //Improve stats beroende på lvl
            hp = maxHP * statModifier;
            armor *= statModifier;
            minDmg *= statModifier;
            maxDmg *= statModifier;
        }

        public override int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(20, 80);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }

        public override int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(20, 80);
            if (hitChance > 66)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
        }
    }
}