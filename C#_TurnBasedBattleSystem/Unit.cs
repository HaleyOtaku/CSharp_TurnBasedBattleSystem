using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__TurnBasedBattleSystem
{
    internal class Unit
    {
        //FIELDS
        //In C#, a field stores a piece of data within an object
        //If no access modifier is provided, a field is private by default.
        //declaring objects(fields) to use later
        int currentHp;
        int maxHp;
        int attackPower;
        int healPower;
        string unitName;

        //For attack and crit chance
        private Random random;


        //PROPERTIES

        //To display health before and after attacking
        public int Hp { get { return currentHp; }}
        public string UnitName { get { return unitName; } }

        //For Death functionality
        public bool IsDead { get { return currentHp <= 0; } }

        //COLLECT/CATCH/CONSTRUCTORS
        public Unit(int maxHp, int attackPower, int healPower, string unitName)
        {
            //instantiate the fields (make new instances of each field)
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.attackPower = attackPower;
            this.healPower = healPower; 
            this.unitName = unitName;
            this.random = new Random();
        }


        //METHODS (Doing something with the now-existing fields)
        public void Attack(Unit unitToAttack)
        {
            //Will return us a double value between 0-1
            //When attacking our unit should be able to deal damage between 75% of our original attack power and up to 125%.
            //Any higher than 100% will be considered a critical hit.
            //rng = Random Number Generator
            double rng = random.NextDouble();
            rng = rng / 2 + 0.75f;
            //               casting attackPower * rng to an int
            int randDamage = (int)(attackPower * rng);
            unitToAttack.TakeDamage(randDamage);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{unitName} attacks {unitToAttack.unitName} for {randDamage} damage!\n");
            Console.ResetColor();
        }

        public void TakeDamage(int damage) 
        { 
            currentHp -= damage;
            if (IsDead)
            {
                Console.WriteLine($"{UnitName} has been defeated!");
            }
        }

        public void Heal()
        {
            //generates new random number
            double rng = random.NextDouble();


            rng = rng / 2 + 0.75;
            int heal = (int)(rng * attackPower);

            //Is the heal added to the currentHp higher than the maxHp? If so, set currentHp to maxHp. If not, add heal to currentHp.
            currentHp = heal + currentHp > maxHp ? maxHp : currentHp + heal;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{UnitName} heals for {heal}!");
            Console.ResetColor();
        }

    }
    
    
}
