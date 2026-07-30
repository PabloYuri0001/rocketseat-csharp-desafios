namespace Exercicio02_NomeCompleto;

class Program()
{
    static void Main()
    {
        Console.WriteLine("Digite seu Nome: ");
        string? primeiroNome = Console.ReadLine();

        Console.WriteLine("Digite seu Sobrenome: ");
        string? sobrenome = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(primeiroNome) && !string.IsNullOrWhiteSpace(sobrenome))
        {
            var nomeCompleto = $"{primeiroNome.Trim()} {sobrenome.Trim()}";
            Console.WriteLine($"Olá {nomeCompleto}! estamos contente por escolher o nosso Sistema! ");
        }
        else
        {
            Console.WriteLine($"*ERRO* O campo Nome e Sobrenome não pode estar vazio e tambem não pode ter apenas espaços !");
        }


    }
}