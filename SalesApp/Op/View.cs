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
        static bool RafaTheusPARASEMPRE = false;
        public static void Bora(List<Pedido> Pedidoslst, List<Cliente> Clienteslst, List<Produto> Produtoslst)
        {
            Operacoes.Centralizar("IDENTIFIQUE-SE\n");
            Console.WriteLine("Digite 1 para lojista e 2 para Cliente e 3 para Sair");
            int.TryParse(Console.ReadLine(), out int escolha);

            while (!RafaTheusPARASEMPRE)
            {
                if (escolha == 1)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Operacoes.Centralizar("      DIGITE 1 PARA CADASTAR PRODUTO / DIGITE 2 PARA CADASTAR CLIENTE  / 3 PARA EXIBIR PRODUTOS  \n");
                    Operacoes.Centralizar("      / 4 PARA EXIBIR CLIENTES  /     DIGITE 5 PARA EXIBIR VENDAS / 6 PARA SAIR /  \n");
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
                            Operacoes.ExibirPedidos(Pedidoslst);
                            break;
                        case 6:
                            Console.WriteLine("OBRIGADO E ATÉ MAIS. ENTER PARA SAIR");
                            Console.ReadLine();
                            RafaTheusPARASEMPRE = true;
                            break;
                        default:
                            break;
                    }
                }
                else if (escolha == 2)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                    Operacoes.Centralizar("DIGITE 1 PARA EXIBIR PRODUTO / DIGITE 2 PARA COMPRAR PRODUTOS  / 3 PARA SAIR \n");
                    Operacoes.Centralizar("------------------------------------------------------------------------------------------------------------------------");
                    Operacoes.Centralizar("------------------------------------------------------------------------------------------------------------------------");

                    int.TryParse(Console.ReadLine(), out int decisao);

                    switch (decisao)
                    {
                        case 1:
                            Console.Clear();
                            Operacoes.ExibirProdutos(Produtoslst);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine(" Comprar Produtos!\n");
                            Pedidoslst.Add(Operacoes.RealizarPedido(Clienteslst, Produtoslst));
                            Jhonson<Pedido>.Salvar(Pedidoslst, "Pedidos");
                            break;

                        case 3:
                            Console.Clear();
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
}
