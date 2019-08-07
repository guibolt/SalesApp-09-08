using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Entitites
{
    public class Cliente
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Cliente(){ }

        public Cliente(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }

    
}
