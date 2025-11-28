# DesafioTarget
## Este documento apresenta a descrição dos três desafios desenvolvidos em C#, incluindo seus objetivos, regras e comportamentos esperados.

1. Cálculo de Comissões de Vendas

O programa lê um arquivo JSON contendo registros de vendas de um time comercial. Cada venda possui informações como vendedor, valor da venda e data. Com base nesses dados, o sistema calcula a comissão individual de cada vendedor seguindo a regra abaixo:

Regras de Comissão

Vendas abaixo de R$100,00 → não geram comissão.

Vendas entre R$100,00 e R$499,99 → comissão de 1%.

Vendas a partir de R$500,00 → comissão de 5%.

Resultado esperado

O programa soma as comissões por vendedor.

Retorna um resultado final com o nome do vendedor e o valor total da sua comissão.


2. Controle de Movimentações de Estoque

Este programa realiza o controle de entradas e saídas de mercadorias no depósito. Os produtos são carregados a partir de um JSON contendo código, descrição e quantidade em estoque.

Regras da Movimentação

Cada movimentação deve possuir:

Identificador único (ID).

Descrição que indique o tipo da movimentação (por exemplo: "Entrada de mercadoria", "Saída para cliente", etc.).

Quantidade movimentada.

Tipo da movimentação: Entrada ou Saída.

Comportamento esperado

O estoque do produto deve ser atualizado conforme o tipo da movimentação.

Ao final de cada operação, o sistema retorna a quantidade final do produto movimentado.

Caso não haja estoque suficiente em uma saída, o programa deve sinalizar o erro.


3. Cálculo de Juros por Atraso

O programa recebe dois dados:

Valor da cobrança.

Data de vencimento.

Com base nisso, ele calcula o valor dos juros até a data atual.

Regra de Juros

Multa de 2,5% ao dia de atraso.

Funcionamento

O sistema verifica quantos dias a conta está em atraso.

Aplica a taxa de 2,5% por dia sobre o valor original.

Retorna o valor total a pagar considerando os juros acumulados.

Tecnologias utilizadas

Linguagem: C#

Manipulação de JSON com System.Text.Json

Estruturas básicas de classes, listas e cálculos

Como executar os programas

A estrutura do projeto será organizada em uma pasta principal contendo três subpastas:


DesafioTarget/
 ├── Desafio1/
 │    └── src/
 │         └── (código do cálculo de comissão)
 ├── Desafio2/
 │    └── src/
 │         └── (código da movimentação de estoque)
 └── Desafio3/
      └── src/
           └── (código do cálculo de juros)
           
# Passo a passo para execução

1. Acesse a pasta do desafio desejado

Abra o terminal na pasta do projeto e navegue até uma das pastas:

Desafio1

Desafio2

Desafio3

Exemplo:

cd Desafio1/src

2. Execute o programa com o .NET CLI

Cada projeto deve conter um arquivo .csproj. Estando dentro da pasta src, execute:

dotnet run

O comando irá compilar e executar o programa.


3. Entrada de dados

No Desafio1, o programa lê o arquivo JSON com vendas automaticamente.

No Desafio2, é solicitado lançar movimentações de estoque.

No Desafio3, você deve informar manualmente o valor e a data de vencimento.

4. Saída

Cada programa exibirá no console:

Desafio1: relatório com as comissões por vendedor.

Desafio2: estoque final após cada movimentação.

Desafio3: cálculo dos juros e valor final atualizado.

Observação**

Os exercícios foram estruturados separadamente para facilitar testes e entendimento.
