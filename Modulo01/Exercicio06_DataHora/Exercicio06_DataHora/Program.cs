using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercicio06_DataHora;

class Program
{

    static void Main()
    {
        var ptBr = new CultureInfo("pt-BR");

        /*
            1. Crie um programa que solicita ao usuário a exibição da data atual em diferentes formatos:
                - Formato completo (dia da semana, dia do mês, mês, ano, hora, minutos, segundos).
                - Apenas a data no formato "01/03/2024".
                - Apenas a hora no formato de 24 horas.
                - A data com o mês por extenso.
         
         */

        bool emExecucao = true;

        while (emExecucao) {
            Console.WriteLine("Escolha como a data dever ser exibida" +
                "\n1 - Formato completo" +
                "\n2 - Apenas a data no formato '01/03/2024'." +
                "\n3 - Apenas a hora no formato de 24 horas." +
                "\n4 - A data com o mês por extenso." +
                "\n0 - Sair");

            Console.WriteLine("Digite sua opção de 0 á 4: ");
            string? opcao = Console.ReadLine();

            bool opcaoValida = string.IsNullOrWhiteSpace(opcao);

            if (opcaoValida)
            {
                Console.WriteLine("Digite uma opção valida, campo não pode estar vazio \n");
                continue;
            }

            if(opcao.Length != 1 ||  !opcao.All(char.IsDigit))
            {
                Console.WriteLine($"Digite uma opção valida, valor inserido '{opcao}' não corresonde com as opções informadas \n");
                continue;
            }

            bool validarConversao = int.TryParse(opcao,out int valor);

            if (!validarConversao || valor > 4)
            {
                Console.WriteLine($"Digite uma opção valida, valor inserido '{opcao}' não corresonde com as opções informadas \n");
                continue;
            }

            var data = DateTime.Now;

            switch (valor)
            {
                case 1:
                    Console.WriteLine(data.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm:ss", ptBr) + "\n");
                    break;
                case 2:
                    Console.WriteLine(data.ToString("dd/MM/yyyy") + "\n");
                    break;
                case 3:
                    Console.WriteLine(data.ToString("HH:mm:ss") + "\n");
                    break;
                case 4:
                    Console.WriteLine(data.ToString("dd 'de' MMMM 'de' yyyy", ptBr) + "\n");
                    break;
                case 0:
                    Console.WriteLine("Saindo ..... \n");
                    emExecucao = false;
                    break;
            }



        }
    }


    
}


