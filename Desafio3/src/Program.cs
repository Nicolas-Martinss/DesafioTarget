using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite o valor: ");
        decimal valor;
        while (!decimal.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Valor inválido. Digite novamente: ");
        }

        Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
        DateTime dataVencimento;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataVencimento))
        {
            Console.Write("Data inválida. Digite novamente (dd/MM/yyyy): ");
        }

        DateTime dataHoje = DateTime.Now.Date;

        int diasAtraso = 0;
        if (dataHoje > dataVencimento)
        {
            diasAtraso = (dataHoje - dataVencimento).Days;
        }

        decimal juros = valor * 0.025m * diasAtraso;
        decimal valorTotal = valor + juros;

        Console.WriteLine($"Dias de atraso: {diasAtraso}");
        Console.WriteLine($"Valor dos juros: R$ {juros:F2}");
        Console.WriteLine($"Valor total: R$ {valorTotal}");
    }
}
