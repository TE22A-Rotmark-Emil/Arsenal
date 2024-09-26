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
        Console.WriteLine(defender.HP);
        Console.WriteLine(Weapon.Damage);
        while(defender.HP > 0 && Weapon.Durability > 0){
            int minDamage = Weapon.Damage-1;
            if (minDamage <= 0){minDamage = 1;}
            int maxDamage = Weapon.Damage+1;
            int damage = Random.Shared.Next(minDamage, maxDamage);
            if (defender.HP - damage < 0){
                damage = defender.HP;
            }
            defender.HP -= damage;
            if (defender.HP < 0){
                defender.HP = 0;
            }
            Weapon.Durability--;
            Console.WriteLine($"{defender.Name} has taken {damage} damage and now has {defender.HP}/{defender._maxHP} HP");
            Thread.Sleep(Random.Shared.Next(125, 250));
        }
    }

    public void ChooseWeapon(){
        Weapon = new("Shiv");
    }
}
