using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Entitites
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int Id { get; set; }

        public Cliente(){ }

        public Cliente(string name, int id)
        {
            Nome = name;
            Id = id;
        }
        public override string ToString()
        {
            return $"Nome: {Nome} ID: {Id}";
        }
    }

    
}
