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

        if (escolha == 1){
            Console.WriteLine("Selecionado Jogar");
        }
        else if (escolha == 2){
            Console.WriteLine("Selecionado Configuração");
        }
        else if (escolha == 3){
            Console.WriteLine("Selecionado Perfil");
        }
        else if (escolha == 4){
            Console.WriteLine("Selecionado Sair");
        }
        else{
            Console.WriteLine("Sem selecionado");
        }




    }
}