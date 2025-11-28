using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

const decimal percentComissaoMinimo = 0.01m;
const decimal percentComissaoMaximo = 0.05m;
const decimal valorVendaGanhaComissao = 500;

string jsonVendas = File.ReadAllText("vendas.json");

var dadosVendas = JsonSerializer.Deserialize<Root>(jsonVendas);

var resultadoComissao = dadosVendas.vendas
    .GroupBy(v => v.vendedor)
    .Select(g => new
    {
        Vendedor = g.Key,
        Comissao = g.Sum(x => CalcularComissao(x.valor))
    }
    );

decimal CalcularComissao(decimal valorVenda)
{
    if (valorVenda < valorVendaGanhaComissao)
        return valorVenda * percentComissaoMinimo;
    return valorVenda * percentComissaoMaximo;
}

foreach (var v in resultadoComissao)
{
    Console.WriteLine($"O vendedor {v.Vendedor:f2} fez um total de R${v.Comissao:f2} de comissão!");
}
public class Root
{
    public List<Vendas> vendas { get; set; }
}
public class Vendas
{
    public string vendedor { get; set; }
    public decimal valor { get; set; }
}
