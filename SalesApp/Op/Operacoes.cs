using Newtonsoft.Json;
using Pedidos.Entitites;
using SalesApp.Entities.Model;
using SalesApp.Entities.Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
namespace SalesApp.Op
{
    static public class Operacoes
    {
        public static void Centralizar(string a) { Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (a.Length / 2)) + "}", a)); }
        #region "Arquivos"
        static string traj = AppDomain.CurrentDomain.BaseDirectory;
        public static void RecuperarPedidos(List<Pedido> pedidos)
        {
            string path = $"{traj}Pedidos.json";
            using (StreamReader s = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var paut = JsonConvert.DeserializeObject<Pedido>(line);
                    pedidos.Add(paut);
                }
            }
        }
        public static void RecuperarClientes(List<Cliente> pedidos)
        {
            string path = $"{traj}Clientes.json";
            using (StreamReader s = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var paut = JsonConvert.DeserializeObject<Cliente>(line);
                    pedidos.Add(paut);
                }
            }
        }
        public static void RecuperarProdutos(List<Produto> produtos)
        {
            string path = $"{traj}Produtos.json";
            using (StreamReader s = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var paut = JsonConvert.DeserializeObject<Produto>(line);
                    produtos.Add(paut);
                }
            }
        }
        public static void SalvarJson(List<Pedido> pedidos)
        {
            string path = $"{traj}Pedidos.json";
            File.Delete(path);
            using (StreamWriter s = File.AppendText(path))
            {
                foreach (Pedido Vez in pedidos)
                {
                    string G = JsonConvert.SerializeObject(Vez);
                    s.WriteLine(G);
                }
            }
        }
        public static void SalvarJ(List<Cliente> clientes)
        {
           string path = $"{traj}Clientes.json";
            File.Delete(path);
            using (StreamWriter s = File.AppendText(path))
            {
                foreach (var client in clientes)
                {
                    string G = JsonConvert.SerializeObject(client);
                    s.WriteLine(G);
                }
            }
        }
        public static void SalvarJhonson(List<Produto> produtos)
        {
            string path = $"{traj}Produtos.json";
            File.Delete(path);
            using (StreamWriter s = File.AppendText(path))
            {
                foreach (var produto in produtos)
                {
                    string G = JsonConvert.SerializeObject(produto);
                    s.WriteLine(G);
                }
            }
        }
        #endregion

        #region "Cadastros"
        public static Cliente CadastrarCliente()
        {
            Console.WriteLine("Qual o nome do cliente ? ");
            string nome = Console.ReadLine();
            Console.WriteLine("Qual o id do cliente?");
            int.TryParse(Console.ReadLine(), out int id);
            return new Cliente(nome, id);
        }

        public static Produto CadastrarProduto()
        {
            Console.WriteLine("Qual o nome do produto");
            string nome = Console.ReadLine();
            Console.WriteLine("Quanto custa o produto ?");
            double custo = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Qual é o id do produto?");
            int.TryParse(Console.ReadLine(), out int id);
            return new Produto(nome, custo, id);
        }
        #endregion

        #region "Exibição"
        public static void ExibirProdutos(List<Produto> produtos)
        {
            Centralizar("LISTA DE PRODUTOS\n");
            produtos.ForEach(c => Console.WriteLine($" Nome: {c.Nome} Preço: {c.Preco.ToString("F2",CultureInfo.InvariantCulture)} Id: {c.Id}\n"));
        }
        public static void ExibirClientes(List<Cliente> clientes)
        {
            Centralizar("LISTA DE CLIENTES\n");
            clientes.ForEach(c => Console.WriteLine($" Nome: {c.Nome} Id: {c.Id}\n"));
        }
        public static void ExibirPedidos(List<Pedido> pedidos)
        {
            Centralizar("LISTA DE PEDIDOS\n");
            pedidos.ForEach(c => Console.WriteLine($"ID: {c.IdPedido} Data: {c.Data} Nome do cliente: {c.Cliente} Valor Total: {c.ValorPedido.ToString("F2", CultureInfo.InvariantCulture)}\n"));
        }
        #endregion

        static public Pedido RealizarPedido(List<Cliente> clientes, List<Produto> produtos)
        {
            var listaItens = new List<Item>();
            Console.WriteLine("Quantos produtos deseja comprar?");
            int.TryParse(Console.ReadLine(), out int qtd);
            for (int i = 0; i < qtd; i++)
            {
                var novoItem = new Item();
                ExibirProdutos(produtos);
                Console.WriteLine("Qual produto deseja escolher? escolha pelo id");
                int.TryParse(Console.ReadLine(), out int ids);
                novoItem.Produto = produtos.Find(p => p.Id == ids);
                Console.WriteLine("Qual é a quantidade?");
                novoItem.Quantidade = int.Parse(Console.ReadLine());
                novoItem.Preco = novoItem.SubTotal();
                listaItens.Add(novoItem);
            }

            Console.WriteLine("Digite a data do pedido");
            var novoPedido = new Pedido();
            novoPedido.Produtos = listaItens;
            ExibirClientes(clientes);
            Console.WriteLine("Escolha um cliente se baseando no id");
            int.TryParse(Console.ReadLine(), out int id);
            novoPedido.Cliente = clientes.Find(c => c.Id == id);
            novoPedido.ValorPedido = novoPedido.Total();
            return novoPedido;
        }
    }
}
