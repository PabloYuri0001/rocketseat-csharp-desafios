namespace Exercicio05_PlacaVeiculo;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite a placa do seu veiculo");
        string? placa = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(placa)) 
        {
            Console.WriteLine($"A Placa {placa} é invalida \npadrão aceito 'AAA-0000' 3 letras e 4 numeros ");
            return;
        }

        string placaFormatada = placa.Replace("-", "").Replace(" ","");


        if(placaFormatada.Length != 7)
        {
            Console.WriteLine($"A Placa {placa} é invalida \npadrão aceito 'AAA-0000' 3 letras e 4 numeros ");
            return;
        }

        string placaLetras = placaFormatada.Substring(0, 3);
        string placasNumeros = placaFormatada.Substring(3, 4);

        if (!placaLetras.All(char.IsLetter) || !placasNumeros.All(char.IsDigit))
        {
            Console.WriteLine($"A Placa {placa} é invalida \npadrão aceito 'AAA-0000' 3 letras e 4 numeros ");
            return;
        }

        Console.WriteLine($"A Placa {placa} é Valida");
    }
}