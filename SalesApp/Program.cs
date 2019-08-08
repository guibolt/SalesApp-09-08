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
            View.Bora(Pedidoslst, Clienteslst, Produtoslst, RafaTheusPARASEMPRE);
        }
    }
}
