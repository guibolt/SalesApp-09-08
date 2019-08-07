using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SalesApp.Entities.Model
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Id { get; set; }

        public Produto() { }

        public Produto(string nome, double preco, int id )
        {
            Nome = nome;
            Preco = preco;
            Id = id;
          
        }
        public override string ToString()
        {
            return $"Nome do produto: {Nome} Preço unitario { Preco.ToString(CultureInfo.InvariantCulture)} Id {Id} ";
        }
    }
}
