using Pedidos.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Entities.Order
{
    public class Pedido
    {

        public DateTime Data { get; set; }
        public List<Item> Produtos { get; set; } = new List<Item>();
        public Cliente Cliente { get; set; }

        public Pedido() { }

        public Pedido(DateTime data, List<Item> produtos, Cliente cliente)
        {
            Data = data;
            Produtos = produtos;
            Cliente = cliente;
        }

        public void AddcionarItem(Item produto)
        {
            Produtos.Add(produto);
        }
        public void RemoverItem(Item produto)
        {
            Produtos.Remove(produto);
        }
        public double Total()
        {
            double porc, sum = 0.0;

            foreach (var item in Produtos)
            {
                sum += item.SubTotal();
            }

            if (sum > 100)
            {
                porc = sum * 0.05;
                return sum - porc;
            }
            else if (sum > 300)
            {
                porc = sum * 0.10;
                return sum - porc;
            }
            return sum;
        }

    }
}
