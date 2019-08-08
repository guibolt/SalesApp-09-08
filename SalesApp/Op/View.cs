using Pedidos.Entitites;
using SalesApp.Entities.Model;
using SalesApp.Entities.Order;
using SalesApp.Op;
using System;
using System.Collections.Generic;

namespace SalesApp
{
    static public class View
    {
      static  bool RafaTheusPARASEMPRE = false;
        public static void Bora(List<Pedido> Pedidoslst, List<Cliente> Clienteslst, List<Produto> Produtoslst)
        {
            while (!RafaTheusPARASEMPRE)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                Operacoes.Centralizar("DIGITE 1 PARA CADASTAR PRODUTO / DIGITE 2 PARA CADASTAR CLIENTE  / 3 PARA EXIBIR PRODUTOS / 4 PARA EXIBIR CLIENTES \n");
                Operacoes.Centralizar("             DIGITE 5 PARA REALIZAR VENDAS / DIGITE 6 PARA EXIBIR VENDAS / 7 PARA SAIR /  \n");
                Operacoes.Centralizar("------------------------------------------------------------------------------------------------------------------------");
                Operacoes.Centralizar("------------------------------------------------------------------------------------------------------------------------");

                int.TryParse(Console.ReadLine(), out int decisao);

                switch (decisao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("CADASTRO DE PRODUTOS\n");
                        Console.WriteLine("Quantos produtos deseja cadastrar?\n");
                        int.TryParse(Console.ReadLine(), out int num);
                        for (int i = 0; i < num; i++) { Produtoslst.Add(Operacoes.CadastrarProduto(Produtoslst)); }
                        Jhonson<Produto>.Salvar(Produtoslst, "Produtos");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("CADASTRO DE CLIENTES \n");
                        Console.WriteLine("Quantos clientes deseja cadastrar?\n");
                        int.TryParse(Console.ReadLine(), out int cho);
                        for (int i = 0; i < cho; i++) { Clienteslst.Add(Operacoes.CadastrarCliente(Clienteslst)); }
                        Jhonson<Cliente>.Salvar(Clienteslst, "Clientes");
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
                        Jhonson<Pedido>.Salvar(Pedidoslst, "Pedidos");

                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Operacoes.ExibirPedidos(Pedidoslst);
                        break;
                    case 7:
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
