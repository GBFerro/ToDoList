using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class ToDo
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Person Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }

        public ToDo()
        {
            var temp = Guid.NewGuid();
            Id = temp.ToString().Substring(0, 8);
            //Description = description;
            //Category = category;
            //Owner = owner;
            //Created = created;
            //DueDate = dueDate;
        }


    }
}
