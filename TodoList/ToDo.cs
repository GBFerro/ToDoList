using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class ToDo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Person Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }

        public ToDo(string description, string category, DateTime dueDate)
        {
            this.Id = Guid.NewGuid();
            Description = description;
            Category = category; 
            Owner = new Person();
            Created = DateTime.Now;
            DueDate = dueDate;
            Status = false;
        }

        public ToDo(Guid id,string description, string category, DateTime created, DateTime dueDate, bool status, Person owner)
        {
            Id = id;
            Description = description;
            Category = category;
            Owner = owner;
            Created = created;
            DueDate = dueDate;
            Status = status;
        }

        public void SetStatus(bool b)
        {
            Status = b;
        }

        public string ToFile()
        {
            return $"{this.Id};{this.Description};{this.Category};{this.Created};{this.DueDate};{this.Status};{this.Owner.ToFile()}";
        }

        public override string ToString()
        {
            return $"ID: {this.Id} \nDESCRIÇÃO: {this.Description} \nCATEGORIA: {this.Category}" +
                $" \nPROPRIETÁRIO: {this.Owner}  \nDATA DE INICIO: {this.Created} \nDATA FINAL: {this.DueDate}" +
                $" \nSTATUS: {this.Status}\n\n";
        }
    }
}
