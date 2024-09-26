public class Weapon
{
    public string Name;
    public int Damage;
    public int Durability;
    public int Cost;

    public Weapon(string name, int damage = 2, int durability = 20, int cost = 10){
        Name = name;
        Damage = damage;
        Durability = durability;
        Cost = cost;
    }
}
