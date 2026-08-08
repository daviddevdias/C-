using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Seu nome é {0}", nome);


        Console.WriteLine("Digite sua idade:");
        int idade = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Sua idade é {0}", idade);

        Console.WriteLine("Você trabalha? ");
        string trabalha = Console.ReadLine();




        if (idade >= 18){
            Console.WriteLine("Maior de idade");

        }

        else{
            Console.WriteLine("Menor de idade");
        }

        if (trabalha == "sim"){
            Console.WriteLine("Trabalha");

        }

        else{
            Console.WriteLine("Não trabalha");
        }
    }
}