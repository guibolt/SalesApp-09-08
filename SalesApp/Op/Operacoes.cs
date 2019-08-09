using Pedidos.Entitites;
using SalesApp.Entities.Model;
using SalesApp.Entities.Order;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace SalesApp.Op
{
    static public class Operacoes
    {
        public static void Centralizar(string a) { Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (a.Length / 2)) + "}", a)); }

        #region "Cadastros"
        public static Cliente CadastrarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Qual o nome do cliente ? \n");
            string nome = Console.ReadLine();
        
            Console.WriteLine($"O Id gerado para este cliente foi: {clientes.Count + 1} \n");
            int id = clientes.Count + 1;
            if (clientes.Exists(d => d.Nome == nome))
            {
                Console.WriteLine("Esse produto ja está cadastrado\n");
                Console.WriteLine("Precione enter para cadastrar novamente\n");
                Console.ReadLine();
                CadastrarCliente(clientes);
            }
           
            Console.WriteLine("CLIENTE CADASTRADO!!");
            
            return new Cliente(nome, id);

        }

        public static Produto CadastrarProduto(List<Produto> produtos)
        {
            Console.WriteLine("Qual o nome do produto\n");
            string nome = Console.ReadLine();
            Console.WriteLine("Quanto custa o produto ?\n");
            double.TryParse(Console.ReadLine(), out double custo);
            if (custo == 0)
            {
                Console.WriteLine("Insira um valor valido!\n");
                Console.WriteLine("Pressione enter para repetir o cadastro\n");
                Console.ReadLine();
                CadastrarProduto(produtos);
            }
    
            Console.WriteLine($"O Id de seu produto é {produtos.Count + 1}!\n");
            int id = produtos.Count + 1;
            if (produtos.Exists(d => d.Nome == nome))
            {
                Console.WriteLine("Esse produto ja está cadastrado, cadastre novamente.\n");
                CadastrarProduto(produtos);
            }
            else
                Console.WriteLine("PRODUTO CADASTRADO!");

            return new Produto(nome, custo, id);
        }
        #endregion

        #region "Exibição"
        public static void ExibirProdutos(List<Produto> produtos)
        {
            Centralizar("LISTA DE PRODUTOS\n");
            produtos.ForEach(c => Console.WriteLine($" Nome: {c.Nome} Preço: {c.Preco.ToString("F2", CultureInfo.InvariantCulture)} Id: {c.Id}\n"));
        }
        public static void ExibirClientes(List<Cliente> clientes)
        {
            Centralizar("LISTA DE CLIENTES\n");
            clientes.ForEach(c => Console.WriteLine($" Nome: {c.Nome} Id: {c.Id}\n"));
        }
        public static void ExibirPedidos(List<Pedido> pedidos)
        {
            Centralizar("LISTA DE PEDIDOS\n");
            pedidos.ForEach(c => Console.WriteLine($" Cliente {c.Cliente} Valor Total: {c.ValorTotalDoPedido.ToString("F2", CultureInfo.InvariantCulture)} ID: {c.IdPedido} Data: {c.Data}\n"));
        }
        #endregion
        static public Pedido RealizarPedido(List<Cliente> clientes, List<Produto> produtos)
        {
            var listaItens = new List<Item>();
            Console.WriteLine("Quantos produtos deseja comprar?\n");
            int.TryParse(Console.ReadLine(), out int qtd);
            Segurar("Digite uma quantidade válida", qtd, 0);
            for (int i = 0; i < qtd; i++)
            {
                var novoItem = new Item();
                ExibirProdutos(produtos);
                Console.WriteLine("Qual produto deseja escolher? escolha pelo id\n");
                int.TryParse(Console.ReadLine(), out int ids);
                if (!produtos.Contains(novoItem.Produto = produtos.Find(p => p.Id == ids)))
                {
                    Console.WriteLine("Esse produto não existe cadastre novamente!");
                    RealizarPedido(clientes, produtos);
                }
                Console.WriteLine("Qual é a quantidade?\n");
                int.TryParse(Console.ReadLine(), out int qtde);
                Segurar("Digite uma quantidade válida", qtde, 0);
                novoItem.Quantidade = qtde;
                
                novoItem.Preco = novoItem.SubTotal();
                listaItens.Add(novoItem);
            }
            Console.WriteLine("Digite a data do pedido\n");
            var novoPedido = new Pedido();
            novoPedido.Produtos = listaItens;
            ExibirClientes(clientes);
            Console.WriteLine("Escolha um cliente se baseando no id\n");
            int.TryParse(Console.ReadLine(), out int id);
            if (!clientes.Contains(novoPedido.Cliente = clientes.Find(c => c.Id == id)))
            {
                Console.WriteLine("Esse cliente não existe!!");
                RealizarPedido(clientes, produtos);
            }
            novoPedido.ValorTotalDoPedido = novoPedido.Total();
            Console.WriteLine("VENDA REALIZADA!\n");
            return novoPedido;
        }
       static public void Segurar(string msg, int num, int outro  )
        {
            while (num <= outro)
            {
                Console.WriteLine(msg);
            }
        }

    }
}
