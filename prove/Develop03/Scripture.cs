using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;  
    private List<Word> _words;  

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        
        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string GetFullScripture()
    {
        return $"{_reference.GetReferenceString()}: {GetScriptureWithHiddenWords()}";
    }

    public string GetScriptureWithHiddenWords()
    {
        List<string> displayedWords = new List<string>();

        foreach (var word in _words)
        {
            displayedWords.Add(word.GetText());
        }

        return string.Join(" ", displayedWords);
    }

    public void HideRandomWord()
    {
        var unhiddenWords = new List<Word>();
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                unhiddenWords.Add(word);
            }
        }

        if (unhiddenWords.Count > 0)
        {
            Random random = new Random();
            var randomWord = unhiddenWords[random.Next(unhiddenWords.Count)];
            randomWord.Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
