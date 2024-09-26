public class Weapon: Item
{
    public int Damage;
    public int Durability;

    public Weapon(string name, int damage = 2, int durability = 20, int cost = 10){
        Name = name;
        Damage = damage;
        Durability = durability;
        Cost = cost;
    }
}
