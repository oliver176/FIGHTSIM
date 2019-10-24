namespace FightSimV2
{
    internal class Vapen : BaseClass
    {
        protected int minDmg = 50;
        protected int maxDmg = 100;
        protected int dmg;
        protected int hitChance;
        protected int minHitChance;
        protected int maxHitChance;
        protected int statModifier = 1;
        public string weaponName = "";

        public Vapen()
        {
        }

        public int GetMinDmg()
        {
            return minDmg;
        }

        public int GetMaxDmg()
        {
            return maxDmg;
        }

        public int GetAllWeaponsCount()
        {
            return 4;
        }

        public virtual int LightAttack(int enemyArmor)
        {
            hitChance = GenRandom(minHitChance, maxHitChance);
            if (hitChance > 33)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return dmg / enemyArmor;
            }
            else return 0;
        }

        public virtual int HeavyAttack(int enemyArmor)
        {
            hitChance = GenRandom(minHitChance, maxHitChance);
            if (hitChance > 66)
            {
                dmg = GenRandom(minDmg, maxDmg);
                return (dmg / enemyArmor) + minDmg;
            }
            else return 0;
        }

        public string GetWeaponName()
        {
            if (weaponName == "")
            {
                return "None";
            }
            else return weaponName + " " + minDmg + "-" + maxDmg;
        }
    }
}