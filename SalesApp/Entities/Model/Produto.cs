using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Entities.Model
{
    public class Produto
    {
        public int Nome { get; set; }
        public int Id { get; set; }
        public double Preco { get; set; }

        public Produto() { }

        public Produto(int nome, int id, int preco)
        {
            Nome = nome;
            Id = id;
            Preco = preco;
        }
    }
}
