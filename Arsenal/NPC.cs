public class NPC: Character
{
    private List<string> _names = new List<string>{"Henry", "Arnold", "Jessica", "Pacifica", "Coroner", "Charlie", "James", "Everest"};

    public NPC(){
        Name = _names[Random.Shared.Next(0, _names.Count())];
        Weapon = new();
        CritChance = -0.01f; // sometimes my genius, it's almost frightening (done to prevent NPCs from critting. might change later)
    }
}
