using System.Collections.Generic;
using TodoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ToDo> toDoList = new List<ToDo>();
        List<string> categoryList = new List<string>();
        categoryList.Add("Important");
        categoryList.Add("Personal");
        categoryList.Add("Professional");

        do
        {
            Console.Clear();

            int op = Menu();
            switch (op)
            {
                case 1:

                    CreateTask(categoryList);
                    Console.ReadKey();
                    break;

                case 2:

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 3:

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 4:

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 5:

                    ReturnTasks(toDoList);
                    Console.ReadKey();
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;
            }

        } while (true);


    }

    private static void CreateTask(List<string> categoryList)
    {
        Console.Write("Informe uma descrição para tarefa: ");
        string description = Console.ReadLine();
        char ownerName = '.';

        Person person = new Person();
        
            Console.Write("Deseja informar um nome para proprietário da tarefa? Digite 's' para SIM, ou 'n' para NÃO: ");
            ownerName = char.Parse(Console.ReadLine());

        if(ownerName == 's')
        {
            Console.Write("Informe o nome: ");
            person.SetName(Console.ReadLine());
        }

        Console.Write("Deseja informe uma data para o termino? Digite 's' para SIM, ou 'n' para NÃO :");
        char endDate = char.Parse(Console.ReadLine());

        Console.WriteLine();

        Console.Write("Informe  o ano: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Informe  o mês: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Informe  o dia: ");
        int day = int.Parse(Console.ReadLine());

        DateTime date = new DateTime(year, month, day);

        ListCategory(categoryList);


        Console.WriteLine("Deseja adicionar uma nova categoria: ");
        char answer = char.Parse(Console.ReadLine());
        string newCategory = "";

        if (answer == 's')

        {
            Console.Write("Informe a nova categoria desejada: ");
             newCategory = Console.ReadLine();
            categoryList.Add(newCategory);
        }
        ToDo task = new ToDo(description, newCategory, date); 



    }

    private static void ListCategory(List<string> category)
    {
        Console.WriteLine("CATEGORIAS DISPONÍVEIS:");
        foreach (string item in category)
        {
            Console.WriteLine(item);
        }
        Console.ReadKey();
    }
    

    private static void ReturnTasks(List<ToDo> ToDoList)
    {
        foreach (ToDo task in ToDoList)
        {
            Console.WriteLine(task.ToString());
        }
    }

    private static int Menu()
    {
        Console.Clear();
        Console.WriteLine(">>>Menu de opções<<<\n\n1 - Criar Tarefa \n2 - Cadastrar Pessoas\n" +
            "3 - Criar Categorias\n4 - Concluir Tarefa\n5 - Listar Tarefas\n6 - Sair\n\n" +
            "Escolha uma opção: ");

        var aux = InsertInt();

        return aux;

    }

    private static int InsertInt()
    {
        int value;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Digite um número inteiro");
            }
            else
            {
                return value;
            }

        } while (true);
    }

    
}