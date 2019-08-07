using Newtonsoft.Json;
using Pedidos.Entitites;
using SalesApp.Entities.Model;
using SalesApp.Entities.Order;
using SalesApp.Op;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Pedidoslst = new List<Pedido>();
            var Clienteslst = new List<Cliente>();
            var Produtoslst = new List<Produto>();
            Operacoes.RecuperarPedidos(Pedidoslst);
            Operacoes.RecuperarClientes(Clienteslst);
            Operacoes.RecuperarProdutos(Produtoslst);
            bool RafaTheusPARASEMPRE = false;
            while (!RafaTheusPARASEMPRE)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                Operacoes.Centralizar("DIGITE 1 PARA CADASTAR PRODUTO / DIGITE 2 PARA CADASTAR CLIENTE  / 3 PARA EXIBIR PRODUTOS \n");
                Operacoes.Centralizar("4 PARA EXIBIR CLIENTES  /  DIGITE 5 PARA REALIZAR VENDAS / DIGITE 6 PARA EXIBIR VENDAS / 7 PARA SALVAR REGISTROS \n");
                Operacoes.Centralizar("------------------------------------------------------------------------------------------------------------------------");
                Operacoes.Centralizar("------------------------------------------------------------------------------------------------------------------------");

                int.TryParse(Console.ReadLine(), out int decisao);

                switch (decisao)
                {
                    case 1:
                        Console.WriteLine("CADASTRO DE PRODUTOS\n");
                        Console.WriteLine("Quantos produtos deseja cadastrar?");
                        int.TryParse(Console.ReadLine(), out int num);
                        for (int i = 0; i < num; i++) { Produtoslst.Add(Operacoes.CadastrarProduto()); }
                        break;
                    case 2:
                        Console.WriteLine("CADASTRO DE CLIENTES \n");
                        Console.WriteLine("Quantos clientes deseja cadastrar?");
                        int.TryParse(Console.ReadLine(), out int cho);
                        for (int i = 0; i < cho; i++){ Clienteslst.Add(Operacoes.CadastrarCliente());}
                        break;
                    case 3:
                        Operacoes.ExibirProdutos(Produtoslst);
                        break;
                    case 4:
                        Operacoes.ExibirClientes(Clienteslst);
                        break;
                    case 5:
                        Console.WriteLine(" REALIZAR VENDAS \n");
                        Pedidoslst.Add(Operacoes.RealizarPedido(Clienteslst, Produtoslst));
                        break;
                    case 6:
                        Operacoes.ExibirPedidos(Pedidoslst);
                        break;
                    case 7:
                        Console.WriteLine("REGISTROS SALVOS!! ENTER PARA VOLTAR PARA TELA INICIAL");
                        Operacoes.SalvarJson(Pedidoslst);
                        Operacoes.SalvarJ(Clienteslst);
                        Operacoes.SalvarJhonson(Produtoslst);
                        break;
                    case 8:
                        Console.WriteLine("OBRIGADO E ATÉ MAIS. ENTER PARA SAIR");
                        Console.ReadLine();
                        RafaTheusPARASEMPRE = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
