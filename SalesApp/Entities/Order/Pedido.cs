using Pedidos.Entitites;
using System;
using System.Collections.Generic;

namespace SalesApp.Entities.Order
{
    public class Pedido
    {
        public Cliente Cliente { get; set; }
        public List<Item> Produtos { get; set; } = new List<Item>();
        public double ValorTotalDoPedido { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string IdPedido { get; set; } = Guid.NewGuid().ToString().Substring(0, 6);
        public Pedido() { }
        public Pedido(DateTime data, List<Item> produtos, Cliente cliente) { Data = data;Produtos = produtos; Cliente = cliente; }
        public double Total()
        {
            double porc, sum = 0;

            foreach (var item in Produtos)
            {
                sum += item.SubTotal();
            }
            if (sum > 300)
            {
                porc = sum * 0.10;
                return sum - porc;
            }
            else if (sum > 100)
            {
                porc = sum * 0.05;
                return sum - porc;
            }
            return sum;
        }
    }
}