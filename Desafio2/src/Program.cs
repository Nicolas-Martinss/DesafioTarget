using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Produto
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; }
    public int Estoque { get; set; }
}

public class Movimentacao
{
    public string Id { get; set; }
    public int CodigoProduto { get; set; }
    public string Tipo { get; set; }
    public int Quantidade { get; set; }
    public string Descricao { get; set; }
}

public class EstoqueData
{
    [JsonPropertyName("estoque")]
    public List<Produto> Estoque { get; set; }
}

class Program
{
    private static int contadorMovimentacao = 1;

    static void Main(string[] args)
    {
        string estoqueJson = File.ReadAllText("produtos.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        EstoqueData dados = JsonSerializer.Deserialize<EstoqueData>(estoqueJson, options);

        if (dados?.Estoque == null)
        {
            Console.WriteLine("Erro ao carregar os dados do estoque.");
            return;
        }

        List<Produto> estoque = dados.Estoque;

        while (true)
        {
            Console.WriteLine("\n======= ESTOQUE =======");
            Console.WriteLine("\nProdutos e Saldos:");
            foreach (var produto in estoque)
            {
                Console.WriteLine($"\nCódigo: {produto.CodigoProduto} - Descrição: {produto.DescricaoProduto} - Estoque Atual: {produto.Estoque}");
            }

            Console.Write("\nDigite o código do produto para movimentação (ou 0 para sair): ");
            if (!int.TryParse(Console.ReadLine(), out int codigo))
            {
                Console.WriteLine("\nEntrada inválida. Digite um número.");
                continue;
            }
            if (codigo == 0)
            {
                Console.WriteLine("\nSaindo do programa.");
                break;
            }

            Produto produtoSelecionado = estoque.Find(p => p.CodigoProduto == codigo);
            if (produtoSelecionado == null)
            {
                Console.WriteLine("Produto não encontrado. Tente novamente.");
                continue;
            }

            Console.Write("\nTipo de movimentação (E para Entrada, S para Saída): ");
            string tipo = Console.ReadLine().Trim().ToUpper();
            if (tipo != "E" && tipo != "S")
            {
                Console.WriteLine("\nTipo inválido. Use 'E' para Entrada ou 'S' para Saída.");
                continue;
            }

            Console.Write("\nDigite a quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                Console.WriteLine("Quantidade deve ser um número positivo.");
                continue;
            }

            if (tipo == "S" && quantidade > produtoSelecionado.Estoque)
            {
                Console.WriteLine("Quantidade insuficiente em estoque.");
                continue;
            }

            Console.Write("\nDescreva a movimentação: ");
            string descricao = Console.ReadLine().Trim();

            string idMovimentacao = contadorMovimentacao.ToString("D2");
            contadorMovimentacao++;

            if (tipo == "E")
            {
                produtoSelecionado.Estoque += quantidade;
            }
            else
            {
                produtoSelecionado.Estoque -= quantidade;
            }

            Console.WriteLine($"\nMovimentação realizada com sucesso!");
            Console.WriteLine($"\nID da Movimentação: {idMovimentacao}");
            Console.WriteLine($"\nDescrição: {descricao}");
            Console.WriteLine($"\nEstoque final do produto '{produtoSelecionado.DescricaoProduto}': {produtoSelecionado.Estoque}");

            while (true)
            {
                Console.Write("\nDeseja fazer outra movimentação? (S/N): ");
                string resposta = Console.ReadLine().Trim().ToUpper();

                if (resposta == "S" || resposta == "SIM")
                {
                    break; 
                }
                else if (resposta == "N" || resposta == "NAO" || resposta == "NÃO")
                {
                    Console.WriteLine("Saindo do programa.");
                    return; 
                }
                else
                {
                    Console.WriteLine("Resposta inválida. Digite 'S' para Sim ou 'N' para Não.");
                }
            }
        }
    }
}