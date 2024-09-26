Character Placeholder = new("Gameloop");

string PlayerName = Placeholder.SelectCharacterName();

Character Player = new(PlayerName);

Console.WriteLine($"Your name is {Player.Name}");

while(true){
    Player.Tick();
}