using System.Globalization;

namespace Exercicio03_Operacoes;

class Program()
{
    static void Main()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Exercicio para poder somar 2 numeros");
        Console.WriteLine("Digite um numero: ");

        bool sucessoNum1 = double.TryParse(Console.ReadLine().Replace(',', '.'), out double numero1);

        Console.WriteLine("Digite um numero: ");

        bool sucessoNum2 = double.TryParse(Console.ReadLine().Replace(',', '.'), out double numero2);

        if (!sucessoNum1 || !sucessoNum2)
        {
            Console.WriteLine("Erro: Ambos os valores precisam ser números válidos.");
            return;
        }

        double soma = numero1 + numero2;
        double subtracao = numero1 - numero2;
        double multiplicacao = numero1 * numero2;
        string divisao = numero2 == 0 ? "inválida (o segundo número é igual a zero!)" : (numero1 / numero2).ToString();
        double media = (numero1 + numero2) / 2;


        /*
            - A soma entre esses dois números;
            - A subtração entre os dois números;
            - A multiplicação entre os dois números;
            - A divisão entre os dois números (vale uma verificação se o segundo número é 0!);
            - A média entre os dois números.
         
         */
        Console.WriteLine(
            $"A soma entre esses dois números: {soma} \n" +
            $"A subtração entre os dois números: {subtracao} \n" +
            $"A multiplicação entre os dois números: {multiplicacao} \n" +
            $"A divisão entre os dois números: {divisao} \n" +
            $"A média entre os dois números: {media} \n"
        );


    }
}