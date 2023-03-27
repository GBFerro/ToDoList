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
            
        }

        public ToDo(string id, string description, string category, Person owner, DateTime dueDate, bool status)
        {
            var temp = Guid.NewGuid();
            Id = temp.ToString().Substring(0, 8);
            Description = description;
            Category = category;
            Owner = owner;
            Created = DateTime.Now;
            DueDate = dueDate;
            Status = status;
        }

        public bool setStatus()
        {
            return true;
        }

       

        public override string ToString()
        {
            return $"ID: {this.Id} DESCRIÇÃO: {this.Description} CATEGORIA: {this.Category}" +
                $" PROPRIETÁRIO: {this.Owner}  DATA DE INICIO: {this.Created} DATA FINAL: {this.DueDate}" +
                $" STATUS: {this.Status}";
        }


    }
}
