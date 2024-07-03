using C__TurnBasedBattleSystem;

Unit player = new Unit(100,20,12,"Player");
Unit enemy = new Unit(75, 10, 7, "Enemy Mage");
Random random = new Random();

while (!player.IsDead && !enemy.IsDead)
{
    Console.WriteLine($"{player.UnitName} HP: {player.Hp} | {enemy.UnitName} HP: {enemy.Hp}\n");


    Console.Write("Player turn! What will you do? ");
    string choice = Console.ReadLine();
    Console.Clear();

    if (choice == "a")
    {
        player.Attack(enemy);
    }
    else
    {
        player.Heal();
    }

    Console.WriteLine($"{player.UnitName} HP: {player.Hp} | {enemy.UnitName} HP: {enemy.Hp}\n");

    Console.WriteLine("Enemy turn!");

    //This generates a random number between 0-1 (The second number is exclusive, meaning not included in the range)
    int rand = random.Next(0,2);

    if  (rand == 0)
    {
        enemy.Attack(player);
    }
    else
    {
        enemy.Heal();
    }

    if (player.IsDead || enemy.IsDead) 
    {
        break;
    }
}