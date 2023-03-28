using System.Collections.Generic;
using TodoList;

internal class Program
{
    private static void Main(string[] args)
    {
        List<ToDo> toDoList = new List<ToDo>();
        List<Person> userList = new List<Person>();
        List<string> categoryList = new List<string>();


        string toDoArchiveName = "ToDoList.txt";
        string registerUser = "RegisterUser.txt";
        string registerCategory = "Category.txt";


        if (File.Exists(toDoArchiveName))
        {
            toDoList = ReadToDoFile(toDoArchiveName);
        }

        if (File.Exists(registerUser))
        {
            userList = ReadUserFile(registerUser);
        }

        if (File.Exists(registerCategory))
        {
            categoryList = ReadCategoryFile(registerCategory);
        }
        else
        {
            categoryList.Add("Importante");
            categoryList.Add("Profissional");
            categoryList.Add("Pessoal");
        }

        do
        {
            Console.Clear();

            int op = Menu();
            switch (op)
            {
                case 1:
                    CreateTask(categoryList, toDoList);

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Digite o nome da pessoa");
                    var name = Console.ReadLine();
                    userList.Add(RegisterUser(name));

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("Digite a nova categoria: ");
                    var newCategory = Console.ReadLine();

                    categoryList = CreateCategory(categoryList, newCategory);

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 4:
                    CompleteTask(toDoList);

                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                    break;

                case 5:
                    ReturnTasks(toDoList);

                    Console.ReadKey();
                    break;

                case 6:
                    EditTask(toDoList, userList, categoryList);
                    break;

                case 7:
                    WriteToDoFile(toDoList, toDoArchiveName);
                    WriteCategoryFile(categoryList, registerCategory);
                    WriteUserFile(userList, registerUser);
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

    private static void EditTask(List<ToDo> toDoList, List<Person> userList, List<string> categoryList)
    {
       
        ListTasks(toDoList);
        Console.WriteLine("Informe a tarefa escolhida: ");
        int position = InsertInt();


        
        bool condition = true;

        do
        {
            int option = EditionMenu();

            switch (option)
            {

                case 1:
                    Console.WriteLine("Informe a nova descrição: ");
                    string description = Console.ReadLine();
                    toDoList[position - 1].Description = description;
                    break;
                case 2:
                    
                    ListCategory(categoryList);
                   
                    Console.WriteLine("Informe a categoria escolhida: ");
                    int cat = InsertInt();
                    string categ = categoryList[cat - 1];
                    toDoList[position - 1].Category = categ;
                    break;
                case 3:
                    Console.WriteLine("Alterando data de conclusão...");
                    Console.Write("Informe a data no formato (dd/mm/aaaa):  ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    toDoList[position-1].DueDate= date;
                    break;

                case 4:
                    ListUser(userList);
                    Console.Write("Informe o novo usuário: ");
                    int userNumber = InsertInt();
                    Person us = userList[userNumber - 1];
                    toDoList[position -1].Owner = us;



                    break;
                case 5:
                    condition = false;
                    break;
                default:
                    Console.WriteLine("Informe um valor de acordo com  o menu...");
                    break;
            }
        } while (condition);
    }

    private static void ListTasks(List<ToDo> toDoList)
    {
        Console.WriteLine("TAREFAS DISPONÍVEIS:");
        int i = 1;
        foreach (var item in toDoList)
        {
            Console.WriteLine(i + "-" + item.Description);
            i++;
        }
    }

    private static int EditionMenu()
    {

        Console.Clear();
        Console.WriteLine(">>>Menu de opções<<<\n\n1 - Editar descrição \n2 - Editar categoria\n" +
            "3 - Editar data de conclusão\n4 - Editar pessoa \n5 - Sair\n\n" +
            "Escolha uma opção: ");

        var aux = InsertInt();

        return aux;

    }

    private static void CreateTask(List<string> categoryList, List<ToDo> toDoList)
    {
        Console.Write("Informe uma descrição para tarefa: ");
        string description = Console.ReadLine();
        char ownerName = '.';

        Console.Write("Deseja informe uma data para o termino? Digite 's' para SIM, ou 'n' para NÃO :");
        char endDate = char.Parse(Console.ReadLine());
        int year = 1960;
        int month = 1;
        int day = 1;

        if (endDate == 's')
        {
            Console.Write("Informe  o ano: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Informe  o mês: ");
            month = int.Parse(Console.ReadLine());

            Console.Write("Informe  o dia: ");
            day = int.Parse(Console.ReadLine());
        }

        DateTime date = new DateTime(year, month, day);

        ListCategory(categoryList);
        Console.WriteLine("Informe a categoria escolhida: ");
        int newCategory = InsertInt();

        ToDo task = new ToDo(description, categoryList[newCategory - 1], date);
        toDoList.Add(task);

    }


    private static void ListUser(List<Person> userList)
    {
        int number = 1;
        foreach (Person person in userList)
        {
            Console.WriteLine(number + "-" + person.ToString());
        }
    }

    private static List<string> CreateCategory(List<string> category, string s)
    {
        category.Add(s);

        return category;
    }

    private static void CompleteTask(List<ToDo> toDoList)
    {
        foreach (var item in toDoList)
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
        return person;
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
            sw.Close();
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
            sw.Close();
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
            sw.Close();
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
        ToDo toDoFile;

        try
        {
            string line;
            DateTime createDate, dueDate;
            Person person;
            StreamReader sr = new StreamReader(v);
            while ((line = sr.ReadLine()) != null)
            {
                var aux = line.Split(';');

                Guid id = Guid.Parse(aux[0]);
                var description = aux[1];
                var category = aux[2];

                var status = bool.Parse(aux[5]);
                var ownerId = Guid.Parse(aux[6]);
                var ownerName = aux[7];

                createDate = DateTime.Parse(aux[3]);
                dueDate = DateTime.Parse(aux[4]);

                person = new(ownerName, ownerId);
                toDoFile = new(id, description, category, createDate, dueDate, status, person);
                toDoList.Add(toDoFile);
            }
            sr.Close();
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
        List<Person> userList = new List<Person>();
        Person user;
        try
        {
            string line;
            StreamReader sr = new StreamReader(v);
            while ((line = sr.ReadLine()) != null)
            {
                var aux = line.Split(';');

                user = new(aux[1], Guid.Parse(aux[0]));
                userList.Add(user);
            }
            sr.Close();

            return userList;
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
        List<string> categoryList = new List<string>();

        try
        {
            string line;
            StreamReader sr = new StreamReader(v);
            while ((line = sr.ReadLine()) != null)
            {
                categoryList.Add(line);
            }
            sr.Close();

            return categoryList;
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

    private static void ListCategory(List<string> category)
    {
        Console.WriteLine("CATEGORIAS DISPONÍVEIS:");
        int i = 1;
        foreach (string item in category)
        {
            Console.WriteLine(i + "-" + item);
            i++;
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
            "3 - Criar Categorias\n4 - Concluir Tarefa\n5 - Listar Tarefas\n6 - Editar Tarefa\n7 - Sair\n\n" +
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