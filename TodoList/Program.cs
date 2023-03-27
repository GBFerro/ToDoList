using System.Collections.Generic;
using TodoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ToDo> toDoList = new List<ToDo>();
        List<String>categoryList = new List<String>();
        do
        {
            Console.Clear();

            int op = Menu();
            switch (op)
            {
                case 1:

                    CreateTask();
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

    private static void CreateTask()
    {
        throw new NotImplementedException();
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

        var aux = IsInt();

        return aux;

    }

    private static int IsInt()
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