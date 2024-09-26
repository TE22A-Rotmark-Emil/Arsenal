public class Player: Character
{
    public void Attack(){}

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
