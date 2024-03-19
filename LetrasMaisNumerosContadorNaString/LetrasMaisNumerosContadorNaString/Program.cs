using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Por favor digite uma palavra sem espaços e em letras maiúsculas por favor. Ex:AAAHHHHRRGGG");

        string input = Console.ReadLine();
        if (ValidaInput(input))
        {
            Console.WriteLine("Formato de entrada inválido, por favor siga as intruções na próxima vez.");
            return;
        }
        Console.WriteLine(DevolveQuantidadeECaractere(input));

    }

    public static string DevolveQuantidadeECaractere(string input)
    {
        string retorno = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            int count = 1;
            while(i + 1 < input.Length && input[i] == input[1 + i]) 
            {
                count++;
                i++;
            }
            retorno += count.ToString() + input[i].ToString();
        }
        return retorno;
    }

    public static bool ValidaInput(string input)
    {
        Regex regex = new Regex(@"^[A-Z]+$");
        if (regex.IsMatch(input))
            return false;
        return true;
    }
}
