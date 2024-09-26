using System.Runtime.InteropServices;

public class Character
{
    private int _maxHP;
    public int HP = 10;
    public string Name;
    public Weapon Weapon;
    public int Strength;
    public float CritChance;
    public float CritDamage;

    public Character(string name, int strength = 1, float critchance = 0.10f, float critdamage = 2.0f){
        Name = name;
        _maxHP = HP;
        Strength = strength;
        CritChance = critchance;
        CritDamage = critdamage;
    }

    public void Tick(){
        if (Weapon == null){
            ChooseWeapon();
        }
        Character newguy = new("newguy");
        Attack(newguy);
        Console.ReadLine();
    }

    public void Attack(Character defender){
        while(defender.HP > 0 && Weapon != null){
            int damage = CalcDamage();
            defender.HP -= damage;
            Weapon.Durability--;
            Console.WriteLine($"{defender.Name} has taken {damage} damage and now has {defender.HP}/{defender._maxHP} HP");
            Thread.Sleep(Random.Shared.Next(125, 250));
            ReduceWeaponDurability();
            if (defender.HP == 0){
                defender.HP = defender._maxHP;
            }
        }

        if (Weapon == null){
            Console.WriteLine("Lmaoo");
        }
        else{
            Console.WriteLine("They dead lmao");
        }

        int CalcDamage(){
            int minDamage = Weapon.Damage-2;
            if (minDamage <= 0){minDamage = 1;}
            int maxDamage = Weapon.Damage+2;
            int damage = Random.Shared.Next(minDamage, maxDamage);
            if (Random.Shared.NextDouble() <= CritChance){
                float floatDamage = maxDamage;
                floatDamage *= CritDamage;
                damage = Convert.ToInt32(floatDamage);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CRITICAL HIT!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            if (defender.HP - damage < 0){
                damage = defender.HP;
            }
            return damage;
        }
    }

    public void ChooseWeapon(){
        Weapon = new("Shiv");
    }

    public void ReduceWeaponDurability(){
        Weapon.Durability--;
        if (Weapon.Durability <= 0){
            Weapon = null;
        }
    }
}
