using System;

namespace FightSimV2
{
    internal class BaseClass
    {
        public int GenRandom(int min, int max)
        {
            Random gen = new Random();
            return gen.Next(min, max);
        }
    }
}