using Pedidos.Entitites;
using SalesApp.Entities.Model;
using SalesApp.Entities.Order;
using SalesApp.Op;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp
{
    static public class View
    {
        public static void Bora(List<Pedido> Pedidoslst, List<Cliente> Clienteslst, List<Produto> Produtoslst, bool RafaTheusPARASEMPRE)
        {
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
                        Console.Clear();
                        Console.WriteLine("CADASTRO DE PRODUTOS\n");
                        Console.WriteLine("Quantos produtos deseja cadastrar?");
                        int.TryParse(Console.ReadLine(), out int num);
                        for (int i = 0; i < num; i++) { Produtoslst.Add(Operacoes.CadastrarProduto(Produtoslst)); }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("CADASTRO DE CLIENTES \n");
                        Console.WriteLine("Quantos clientes deseja cadastrar?");
                        int.TryParse(Console.ReadLine(), out int cho);
                        for (int i = 0; i < cho; i++) { Clienteslst.Add(Operacoes.CadastrarCliente(Clienteslst)); }
                        break;
                    case 3:
                        Console.Clear();
                        Operacoes.ExibirProdutos(Produtoslst);
                        break;
                    case 4:
                        Console.Clear();
                        Operacoes.ExibirClientes(Clienteslst);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine(" REALIZAR VENDAS \n");
                        Pedidoslst.Add(Operacoes.RealizarPedido(Clienteslst, Produtoslst));
                        break;
                    case 6:
                        Console.Clear();
                        Operacoes.ExibirPedidos(Pedidoslst);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("REGISTROS SALVOS!!");
                        Operacoes.SalverPedidos(Pedidoslst);
                        Operacoes.SalvarClientes(Clienteslst);
                        Operacoes.SalverProdutos(Produtoslst);
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
