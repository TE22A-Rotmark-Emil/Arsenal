global using System.Text.Json;

Player Player = new();

Player.SelectCharacterName();

Console.WriteLine($"Your name is {Player.Name}");

while(true){
    Player.Tick();
}