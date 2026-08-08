using System;

class Program
{
    static void Main(string[] args)
    {
        // Variáveis
        string nome = "David";
        int idade = 30;
        double altura = 1.75;
        bool programador = true;
        int nota = 5;
        bool ingresso = false;
        bool vip = false;
        bool funcionario = true;
        string usuario = "David";
        string senha = "1234";

        // Informações
        Console.WriteLine("Olá, meu nome é {0}", nome);
        Console.WriteLine("Tenho {0} anos", idade);
        Console.WriteLine("Minha altura é {0}", altura);
        Console.WriteLine("Programador: {0}", programador);

        Console.WriteLine(); 

        // Verifica idade com entrada de ingresso 
        if (idade >= 18 && ingresso)
        {
            Console.WriteLine("Entrada permitida!");
        }
        else
        {
            Console.WriteLine("Entrada negada!");
        }

        Console.WriteLine(); // Linha em branco

        // Verifica nota
        if (nota == 10)
        {
            Console.WriteLine("Excelente");
        }
        else if (nota >= 8)
        {
            Console.WriteLine("Aprovado!");
        }
        else
        {
            Console.WriteLine("Reprovado!");
        }

        //Funcionario vip
        if (vip || funcionario)
        {
            Console.WriteLine("Pode entrar");
        }
        else
        {
            Console.WriteLine("Acesso negado");
        }

        if (usuario == "David" && senha == "1234")
        {
            Console.WriteLine("Acesso liberado senha correta");
        }
        else
        {
            Console.WriteLine("Acesso negado senha errada!");
        }


    }
}