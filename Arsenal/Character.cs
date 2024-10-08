using System.Runtime.InteropServices;

public class Character
{
    public string Name;
    private int _maxHP;
    public int HP = 10;
    public Weapon Weapon;
    public int Strength;
    public float CritChance;
    public float CritDamage;

    public Character(int str = 1, float crate = 0.10f, float camage = 2.0f)
    {
        _maxHP = HP;
        Strength = str;
        CritChance = crate;
        CritDamage = camage;
    }

    public void Tick()
    {
        if (Weapon == null)
        {
            ChooseWeapon();
        }
        NPC newguy = new();
        Attack(newguy);
        Console.ReadLine();
    }

    public void Attack(Character defender)
    {
        while (defender.HP > 0 && Weapon != null)
        {
            int damage = CalcDamage();
            defender.HP -= damage;
            Console.WriteLine($"{defender.Name} has taken {damage} damage and now has {defender.HP}/{defender._maxHP} HP");
            Thread.Sleep(Random.Shared.Next(125, 250));
        }

        if (Weapon == null)
        {
            Console.WriteLine("Lmaoo your weapon broke");
        }
        else
        {
            Console.WriteLine("They dead lmao");
        }

        int CalcDamage()
        {
            bool crit = false;
            int minDamage = Weapon.Damage - 2;
            if (minDamage <= 0) { minDamage = 1; }
            int maxDamage = Weapon.Damage + Strength;
            int damage = Random.Shared.Next(minDamage, maxDamage + 1);
            if (CritChance >= Random.Shared.NextDouble())
            {
                float floatDamage = maxDamage;
                floatDamage *= CritDamage;
                damage = Convert.ToInt32(floatDamage);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CRITICAL HIT!");
                Console.ForegroundColor = ConsoleColor.Gray;
                crit = true;
            }
            if (defender.HP - damage < 0)
            {
                damage = defender.HP;
            }
            ReduceWeaponDurability(crit);
            return damage;
        }
    }

    public void ChooseWeapon()
    {
        Weapon = new();
    }

    public void ReduceWeaponDurability(bool crit)
    {
        if (crit)
        {
            Weapon.Durability -= Convert.ToInt32(CritDamage);
        }
        else
        {
            Weapon.Durability--;
        }
        if (Weapon.Durability <= 0)
        {
            Weapon = null;
        }
    }
}
