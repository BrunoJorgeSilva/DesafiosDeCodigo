using System;
using System.Linq;
using System.Collections.Generic;

class MainClass
{
    public static string PalindromicSubstring(string text)
    {
        List<string> palindromos = new List<string>();

        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 2; j <= text.Length - i; j++)
            {
                var subStr = text.Substring(i, j);
                if (ValidaPalindromo(subStr))
                    palindromos.Add(subStr);
            }
        }
        string maiorPalindromo = palindromos.OrderBy(x => x.Length).Last();
        return maiorPalindromo.Length <= 2 ? "none" : maiorPalindromo;

    }
    public static bool ValidaPalindromo(string text)
    {
        bool validacao = true;
        if (string.IsNullOrEmpty(text))
            return false;

        for (int i = 0; i < text.Length / 2; i++)
        {
            if (text[i] != text[text.Length - i - 1])
                return false;
        }
        return validacao;
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(PalindromicSubstring(Console.ReadLine()));
    }

}