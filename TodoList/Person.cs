using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{

    internal class Person
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }


        public Person()
        {
            Id = Guid.NewGuid();
            this.Name = "EU";
        }

        public Person(string? name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Person(string name, Guid id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string ToFile()
        {
            return $"{this.Id};{this.Name}";
        }

        public override string ToString()
        {
            return $"\n\tID: {this.Id}\n\tNome: {this.Name}";
        }
    }
}
