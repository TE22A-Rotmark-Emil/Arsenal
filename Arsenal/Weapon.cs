public class Weapon: Item
{
    public int Damage;
    public int Durability;

    public Weapon(string name = "stick", int damage = 1, int durability = 20, int cost = 0){
        Name = name;
        Damage = damage;
        Durability = durability;
        Cost = cost;
    }
}
