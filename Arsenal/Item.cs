public class Item{
    public string Type;
    private string[] _buffTypes = ["Healing", "Buffing", "Debuffing", "Protecting"];
    public string Buff;
    public int Duration;
    private int _maxDuration;
    public int Cost;
    public int Potency;

    public Item(string typeOfItem = "Healing", string typeOfBuff = "HP", int durationOfItem = 0, int costOfItem = 0, int potencyOfItem = 5){
        Type = typeOfItem;
        Buff = typeOfBuff;
        Duration = durationOfItem;
        _maxDuration = Duration;
        Cost = costOfItem;
        Potency = potencyOfItem;
    }
}