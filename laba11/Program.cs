using System;
using System.Collections.Generic;

public abstract class Unit
{
    public int Health { get; protected set; }
    public string Name { get; set; }

    protected Unit(int health, string name)
    {
        if (health <= 0)
        {
            throw new ArgumentException("Health must be greater than 0");
        }

        Health = health;
        Name = name;
    }

    public abstract void Attack(Unit target);
}

public class Infantry : Unit
{
    public int WalkingSpeed { get; set; }
    public Weapon PersonalWeapon { get; set; }

    public Infantry(int health, string name, int walkingSpeed, Weapon personalWeapon)
        : base(health, name)
    {
        if (walkingSpeed <= 0)
        {
            throw new ArgumentException("Walking speed must be greater than 0");
        }

        WalkingSpeed = walkingSpeed;
        PersonalWeapon = personalWeapon;
    }

    public override void Attack(Unit target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} with {PersonalWeapon.Type}");
    }
}

public class Tank : Unit
{
    public int FuelSupply { get; set; }
    public Weapon MainWeapon { get; set; }
    public Weapon AdditionalWeapon { get; set; }
    public int Speed { get; set; }

    public Tank(int health, string name, int fuelSupply, Weapon mainWeapon, Weapon additionalWeapon, int speed)
        : base(health, name)
    {
        if (fuelSupply <= 0)
        {
            throw new ArgumentException("Fuel supply must be greater than 0");
        }

        if (speed <= 0)
        {
            throw new ArgumentException("Speed must be greater than 0");
        }

        FuelSupply = fuelSupply;
        MainWeapon = mainWeapon;
        AdditionalWeapon = additionalWeapon;
        Speed = speed;
    }

    public override void Attack(Unit target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} with {MainWeapon.Type}");
    }
}

// Добавьте классы для других юнитов аналогично

public class Weapon
{
    public string Type { get; set; }
    public int Damage { get; set; }

    public Weapon(string type, int damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException("Damage must be greater than 0");
        }

        Type = type;
        Damage = damage;
    }
}

public class Transport
{
    public List<Unit> Units { get; set; }

    public Transport()
    {
        Units = new List<Unit>();
    }

    public void AddUnit(Unit unit)
    {
        Units.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        Units.Remove(unit);
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Infantry infantry = new Infantry(100, "Soldier", 10, new Weapon("Rifle", 20));
            Tank tank = new Tank(500, "Tank", 1000, new Weapon("Cannon", 100), new Weapon("Machine Gun", 50), 30);

            Transport transport = new Transport();
            transport.AddUnit(infantry);

            Console.WriteLine("Transport units:");
            foreach (var unit in transport.Units)
            {
                Console.WriteLine(unit.Name);
            }

            tank.Attack(infantry);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}