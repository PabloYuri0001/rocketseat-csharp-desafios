namespace Exercicio04_ContadorCaracteres;

class Program
{
    static void Main()
    {
        Console.WriteLine("Escreva uma palavra ou uma frase");
        string? palavra =  Console.ReadLine();

        int cont = 0;

        if (string.IsNullOrWhiteSpace(palavra)) {
            Console.WriteLine("A palavra não pode estar vazia ou ter apenas espaços, por gentileza digitar uma palavra valida");
            return;
        }

        string novaPalavra = palavra.Replace(" ", "");

        //for (int i = 0; i < palavra.Length; i++)
        //{
        //    if (palavra[i] == ' ')
        //    {
        //        continue;
        //    }

        //    cont++;
        //}



        Console.WriteLine($"A palavra {novaPalavra} : contem {novaPalavra.Length} caracteres");
    }
}