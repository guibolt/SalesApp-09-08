using SalesApp.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Entities.Order
{
   public class Item
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public double Preco { get; set; }  
       

        public Item(){ }

        public Item(Produto produto,int quantidade, double preco)
        {
            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
         
        }

        public double SubTotal()
        {
            return Quantidade * Produto.Preco;
        }

        public override string ToString()
        {
            return $" Nome do produto: {Produto.Nome} Quantidade {Quantidade}";
        }
    }
}
