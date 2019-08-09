using Pedidos.Entitites;
using SalesApp.Entities.Model;
using SalesApp.Entities.Order;
using SalesApp.Op;
using System.Collections.Generic;

namespace SalesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Pedidoslst = new List<Pedido>();
            var Clienteslst = new List<Cliente>();
            var Produtoslst = new List<Produto>();
            Jhonson<Pedido>.Recuperar(Pedidoslst, "Pedidos");
            Jhonson<Cliente>.Recuperar(Clienteslst, "Clientes");
            Jhonson<Produto>.Recuperar(Produtoslst, "Produtos");
            View.Bora(Pedidoslst, Clienteslst, Produtoslst);
        }
    }
}
