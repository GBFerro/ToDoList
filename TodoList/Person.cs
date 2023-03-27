using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class Person
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Person(string? name)
        {
            Name = name;
        }

        public string ToFile()
        {
            return $"{this.Id};{this.Name}";
        }        

        public override string ToString()
        {
            return $"ID: {this.Id}\nNome: {this.Name}";
        }
    }
}
