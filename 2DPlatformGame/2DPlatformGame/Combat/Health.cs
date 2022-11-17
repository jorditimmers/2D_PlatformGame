using System;
namespace DPlatformGame.Combat
{
    public class Health
    {
        public int healthPoints { get; private set; }

        public Health()
        {
            healthPoints = 100;
        }

        public int getHealtPoints()
        {
            return healthPoints;
        }

        public void dealDamage(int amountOfDamage)
        {
            healthPoints -= amountOfDamage;
        }

        public void heal(int amountOfHeal)
        {
            healthPoints += amountOfHeal;
        }
    }
}

