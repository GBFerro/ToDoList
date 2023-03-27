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
        

        public  Person()
        {
            this.Name = "EU";
        }

        public void SetName(string name)
        {
            this.Name = name;
        }


      
    }
}
