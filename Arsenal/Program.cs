global using System.Text.Json;

Character Player = new();

Player.SelectCharacterName();

Console.WriteLine($"Your name is {Player.Name}");

while(true){
    Player.Tick();
}