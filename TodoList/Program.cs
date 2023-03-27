using TodoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ToDo> toDoList = new List<ToDo>();
        List<Person> user = new List<Person>();
        List<string> category = new List<string>();

        string toDoArchiveName = "ToDoList.txt";
        string registerUser = "RegisterUser";

        if (File.Exists(toDoArchiveName))
        {
        }

        do
        {
            Console.Clear();

            int op = Menu();
            switch (op)
            {
                case 1:
                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Digite o nome da pessoa");
                    RegisterUser(Console.ReadLine());
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

                    ReturnTasks();
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

    private static void CompleteTask(List<ToDo> toDoList)
    {
        foreach(var item in toDoList)
        {
            Console.WriteLine(item.ToString());

            Console.WriteLine("[C]ompleta ou Em [A]ndamento");
            char c = char.Parse(Console.ReadLine());
            if (c == 'c')
            {
                item.SetStatus(true);
            }
        }
    }

    private static Person RegisterUser(string name)
    {
        Person person = new Person(name);

    }

    private static void WriteToDoFile(List<ToDo> list, string v)
    {
        try
        {
            StreamWriter sw = new StreamWriter(v);
            foreach (var item in list)
            {
                sw.WriteLine(item.ToFile());
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

    private static void WriteUserFile(List<Person> list, string v)
    {
        try
        {
            StreamWriter sw = new StreamWriter(v);
            foreach (var item in list)
            {
                sw.WriteLine(item.ToFile());
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

    private static void WriteCategoryFile(List<string> list, string v)
    {
        try
        {
            StreamWriter sw = new StreamWriter(v);
            foreach (var item in list)
            {
                sw.WriteLine(item);
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

    private static List<ToDo> ReadToDoFile(string v)
    {
        List<ToDo> toDoList = new List<ToDo>();

        try
        {
            string line;
            StreamReader sr = new StreamReader(v);
            while ((line = sr.ReadLine()) != null)
            {
                var aux = line.Split(';');
            }

            return toDoList;
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

    private static List<Person> ReadUserFile(string v)
    {
        List<Person> user = new List<Person>();

        try
        {
            string line;
            StreamReader sr = new StreamReader(v);
            while ((line = sr.ReadLine()) != null)
            {
                var aux = line.Split(';');
            }

            return user;
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

    private static List<string> ReadCategoryFile(string v)
    {
        List<string> category = new List<string>();

        try
        {
            string line;
            StreamReader sr = new StreamReader(v);
            while ((line = sr.ReadLine()) != null)
            {
                var aux = line.Split(';');
            }

            return category;
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