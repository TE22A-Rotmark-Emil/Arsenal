using System.Runtime.InteropServices;

public class Character
{
    public string Name;
    public bool IsPlayer;
    private List<string> _names = new List<string>{"Henry", "Arnold", "Jessica", "Pacifica", "Coroner", "Charlie", "James", "Everest"};
    private int _maxHP;
    public int HP = 10;
    public Weapon Weapon;
    public int Strength;
    public float CritChance;
    public float CritDamage;

    public Character(int strength = 1, float critchance = 0.10f, float critdamage = 2.0f)
    {
        if (!IsPlayer){
            Name = _names[Random.Shared.Next(0, _names.Count())];
        }
        _maxHP = HP;
        Strength = strength;
        CritChance = critchance;
        CritDamage = critdamage;
    }

    public void Tick()
    {
        if (Weapon == null)
        {
            ChooseWeapon();
        }
        Character newguy = new();
        Attack(newguy);
        Console.ReadLine();
    }

    public void Attack(Character defender)
    {
        while (defender.HP > 0 && Weapon != null)
        {
            int damage = CalcDamage();
            defender.HP -= damage;
            Console.WriteLine($"{defender.Name} has taken {damage} damage and now has {defender.HP}/{defender._maxHP} HP");
            Thread.Sleep(Random.Shared.Next(125, 250));
        }

        if (Weapon == null)
        {
            Console.WriteLine("Lmaoo your weapon broke");
        }
        else
        {
            Console.WriteLine("They dead lmao");
        }

        int CalcDamage()
        {
            bool crit = false;
            int minDamage = Weapon.Damage - 2;
            if (minDamage <= 0) { minDamage = 1; }
            int maxDamage = Weapon.Damage + Strength;
            int damage = Random.Shared.Next(minDamage, maxDamage + 1);
            if (Random.Shared.NextDouble() <= CritChance)
            {
                float floatDamage = maxDamage;
                floatDamage *= CritDamage;
                damage = Convert.ToInt32(floatDamage);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CRITICAL HIT!");
                Console.ForegroundColor = ConsoleColor.Gray;
                crit = true;
            }
            if (defender.HP - damage < 0)
            {
                damage = defender.HP;
            }
            ReduceWeaponDurability(crit);
            return damage;
        }
    }

    public void ChooseWeapon()
    {
        Weapon = new("Shiv");
    }

    public void ReduceWeaponDurability(bool crit)
    {
        if (crit)
        {
            Weapon.Durability -= Convert.ToInt32(CritDamage);
        }
        else
        {
            Weapon.Durability--;
        }
        if (Weapon.Durability <= 0)
        {
            Weapon = null;
        }
    }

    public void SelectCharacterName()
    {
        IsPlayer = true;
        bool validName = false;
        string legalCharacters = "abcdefghijklmnopqrstuvwxyz";
        char[] legalCharacterList = legalCharacters.ToCharArray();
        string CharacterName;
        Console.WriteLine("Type a character name");
        do
        {
            int infractions = 0;
            CharacterName = Console.ReadLine();
            char[] nameList = CharacterName.ToLower().ToCharArray();
            CharacterName.Trim();
            if (CharacterName.Length < 3 || CharacterName.Length > 16)
            {
                Console.WriteLine("Character name cannot be shorter than 3 and may not exceed 16 characters");
                infractions++;
            }
            else
            {
                foreach (char nameCharacter in nameList)
                {
                    if (!legalCharacterList.Contains(nameCharacter))
                    {
                        if (DeleteIllegals(CharacterName).Length >= 3 && DeleteIllegals(CharacterName).Length <= 16)
                        {
                            Console.WriteLine($"Your name is permittable if we remove some characters. Are you okay with the name '{DeleteIllegals(CharacterName)}'?");
                            bool confirm = Confirmation();
                            if (confirm == false)
                            {
                                Console.WriteLine("Character name cannot include non-english characters.");
                                infractions++;
                            }
                            else{
                                CharacterName = DeleteIllegals(CharacterName);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Character name cannot include non-english characters.");
                            infractions++;
                            break;
                        }
                    }
                    else{
                    }
                }
            }
            if (infractions == 0)
            {
                validName = true;
            }
        } while (!validName);

        string DeleteIllegals(string word)
        {
            foreach (char letter in word)
            {
                if (!legalCharacterList.Contains(letter))
                {
                    string stringLetterBecauseCSharpIsJustNotIt = letter.ToString();
                    word = word.Replace(stringLetterBecauseCSharpIsJustNotIt, "");
                }
                else{
                }
            }
            return word;
        }
        Name = CharacterName;
    }

    bool Confirmation()
    {
        bool wronglyTyped;
        bool confirm = false;
        do
        {
            string answer = Console.ReadLine().ToLower();
            answer = answer.Trim();
            if (answer != "yes" && answer != "no")
            {
                Console.WriteLine("Type yes or no");
                wronglyTyped = true;
            }
            else{
                wronglyTyped = false;
                if (answer == "yes"){
                    confirm = true;
                }
            }
        } while (wronglyTyped == true);
        return confirm;
    }
}
