public class Potion: Item
{
    public string Type;
    public int Duration;
    private int _maxDuration;
    public int Potency;

    public Potion(string typeOfItem = "Healing", int durationOfItem = 0, int costOfItem = 0, int potencyOfItem = 5){
        Name = "Lesser Healing Potion";
        Type = typeOfItem;
        Duration = durationOfItem;
        _maxDuration = Duration;
        Cost = costOfItem;
        Potency = potencyOfItem;
    }
}
