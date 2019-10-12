using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightSimV2
{
    class Vapen
    {
        protected int minDmg = 50;
        protected int maxDmg = 100;
        protected int hitChance;
        protected int minHitChance;
        protected int maxHitChance;
        protected int statModifier = 1;
        protected string weaponName = "";

        public void Mace()  // olika vapen att välja mellan
        {
            minDmg -= 30 * statModifier;
            maxDmg += 20 * statModifier;
            minHitChance = 0;
            maxHitChance = 85;
            weaponName = "Mace";
        }
        public void Sword()
        {
            minDmg += 20 * statModifier;
            maxDmg -= 20 * statModifier;
            minHitChance = 15;
            maxHitChance = 100;
            weaponName = "Sword";
        }
        public void Pike()
        {
            minDmg -= 10 * statModifier;
            maxDmg -= 10 * statModifier;
            minHitChance = 33;
            maxHitChance = 100;
            weaponName = "Pike";
        }
        public void Dagger()
        {
            minDmg -= 10 * statModifier;
            maxDmg += 20 * statModifier;
            minHitChance = 99;
            maxHitChance = 100;
            weaponName = "Pike";
        }
        protected string GetWeapon()
        {
            if (weaponName == "")
            {
                return "None";
            }
            else return weaponName + " " + minDmg + "-" + maxDmg;
        }
    }
}
