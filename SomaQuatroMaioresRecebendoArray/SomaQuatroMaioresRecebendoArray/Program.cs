class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Por favor digite quantos números quiser, divididos por vírgula. Exemplo: 2,5,8,9,12. Para que eu possa retornar a soma dos 4 maiores."); 
        string input = Console.ReadLine();
        string[] numerosString = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] arrayInt;
        try
        {
            arrayInt = Array.ConvertAll(numerosString, int.Parse);
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Certifique-se de inserir apenas números inteiros separados por vírgula.");
            return;
        }
        Console.WriteLine($"A soma dos 4 maiores números é: " + RunString(arrayInt));
    }
    private static int RunString(int[] arrayInt)
    {
        if(arrayInt.Count() < 5)
        {
            return arrayInt.Sum();
        }

        arrayInt = arrayInt.OrderByDescending(x => x).ToArray();

        int[] arrayIntRetorno = arrayInt.Take(4).ToArray();

        return arrayIntRetorno.Sum();

    }
}
