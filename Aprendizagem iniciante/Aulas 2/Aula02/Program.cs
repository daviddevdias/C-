using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Seu nome: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Sua idade: ");
        int idade = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("1 - Jogar , 2 - Configurações , 3 - Perfil , 4 - Sair");

        Console.WriteLine("Selecione oque você procura: ");

        int escolha = Convert.ToInt32(Console.ReadLine());


        switch (escolha)
        {
            case 1:
                Console.WriteLine("Selecionado jogar");
            break;



        }



    }
}