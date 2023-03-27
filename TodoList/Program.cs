using TodoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ToDo> toDoList = new List<ToDo>();
        string toDoArchiveName = "ToDoList.txt";
        string registerUser = "RegisterUser";

        if (File.Exists(toDoArchiveName))
        {
            ReadFile(toDoArchiveName);
        }

        // Ler, ToFile, concluir tarefas, toString pessoa
        do
        {
            Console.Clear();

            int op = Menu();
            switch (op)
            {
                case 1:
                    WriteFile(toDoList, toDoArchiveName);
                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Digite o nome da pessoa");
                    RegisterUser(Console.ReadLine());
                    WriteFile(toDoList, registerUser);
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

                    Console.WriteLine("Aperte qualquer tecla para continuar");
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

    private static Person RegisterUser(string name)
    {
        Person person = new Person(name);

        return person;
    }

    private static void WriteFile(List<ToDo> toDoList, string v)
    {
        try
        {
            StreamWriter sw = new StreamWriter(v);
            foreach (ToDo toDo in toDoList)
            {
                sw.WriteLine(toDo.ToFile());
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            Console.WriteLine("Arquivo gravado");
        }
    }

    private static void ReadFile(string v)
    {
        List<ToDo> toDoList;

        try
        {
            string line;
            StreamReader sr = new StreamReader(v);
            while ((line = sr.ReadLine()) != null)
            {
                var aux = line.Split(';');
            }
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            Console.WriteLine("Arquivo Lido");
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