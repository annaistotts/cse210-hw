using System;

class Program
{
    static void Main(string[] args)
    {
        //Change Scripture Here
        Reference reference = new Reference("2 Nephi", 33, 6); 
        string scriptureText = "I glory in plainness; I glory in truth; I glory in my Jesus, for He hath redeemed my soul from hell.";

        Scripture scripture = new Scripture(reference, scriptureText);
        Console.WriteLine("Let's memorize this scripture! Press Enter to begin.");
        Console.WriteLine(scripture.GetFullScripture());
        Console.ReadLine();
        

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press Enter to hide a word, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("You chose to quit the program.");
                break;
            }
            else
            {
                scripture.HideRandomWord();
                Console.Clear();
                Console.WriteLine(scripture.GetScriptureWithHiddenWords());
            }
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nAll words are hidden! You have successfully memorized the scripture!");
        }
    }
}
