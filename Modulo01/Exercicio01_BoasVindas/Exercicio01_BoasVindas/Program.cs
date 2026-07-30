namespace Exercicio01_BoasVindas;

class Program()
{
    static void Main()
    {

        Console.WriteLine("Digite seu primeiro Nome");
        string? primeiroNome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(primeiroNome))
        {
            Console.WriteLine($"Olá, {primeiroNome.Trim()}! Seja muito bem-vindo!");
        }
        else
        {
            Console.WriteLine($"*ERRO* O campo não pode estar vazio e tambem não pode ter apenas espaços, por gentileza Digite seu primeiro nome!");
        }

    }
}