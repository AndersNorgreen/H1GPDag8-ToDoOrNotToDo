using static System.Console;

namespace H1GPDag8
{
    public class ToDoItem
    {
        public int ID            { get; set; }
        public DateTime Created  { get; set; }
        public DateTime Deadline { get; set; }
        public string Title      { get; set; }
        public string ToDo       { get; set; }
        public bool IsDone       { get; set; }
        public bool IsFavorite   { get; set; }
        public long Repeat       { get; set; } // DateTime ticks

        public static void AddNewItem()
        {
            Clear();

            ToDoItem newToDo = new ToDoItem();

            newToDo.ID = ToDoList.toDos.Count + 1;
            newToDo.Created = DateTime.Now;

            string newTitleValue;
            do
            {
                WriteLine("What is the title of our todo?");
                newTitleValue = ReadLine();

            } while (string.IsNullOrEmpty(newTitleValue));
            newToDo.Title = newTitleValue;

            string newTodoValue;
            do
            {
                WriteLine("What are we to do?");
                newTodoValue = ReadLine();

            } while (string.IsNullOrEmpty(newTodoValue));
            newToDo.ToDo = newTodoValue;

            newToDo.IsDone = false;

            DateTime deadline;
            do
            {
                Write("When is the todo due: ");

            } while (!DateTime.TryParse(ReadLine(), out deadline));
            newToDo.Deadline = deadline;

            string favorite;
            do
            {
                Write("Do you want to favorite? y/n ");
                favorite = ReadLine();

            } while (favorite != "y" && favorite != "n");

            if (favorite == "y")
                newToDo.IsFavorite = true;
            else
                newToDo.IsFavorite = false;

            newToDo.Repeat = 0; // Skal færdigimplementeres

            ToDoList.toDos.Add(newToDo);

            WriteLine("The new todo has been added! Press any key to return to the main menu...");
            ReadKey();
            ToDoMenu menu = new ToDoMenu();
            menu.MainMenu();
        }

        public void ShowItemData(ToDoItem toDoItem)
        {
            WriteLine($">>> You are now viewing the todo '{toDoItem.Title}' " + (toDoItem.IsFavorite == true ? " *" : "" + " <<<"));
            WriteLine($"ID: {toDoItem.ID}");
            WriteLine($"Created on: {toDoItem.Created.ToString("dd. MMMM yyyy")}");
            WriteLine($"Deadline on: {toDoItem.Deadline.ToString("dd. MMMM yyyy")}");
            WriteLine("You are to:");
            WriteLine($"    {toDoItem.ToDo}");
            WriteLine($"The assignment is " + (toDoItem.IsDone == true ? "closed" : "still open"));


        }

        public static void AddFakeTodos()
        {
            ToDoItem item1 = new ToDoItem();
            item1.Title = "First Todo";
            item1.ID = ToDoList.toDos.Count + 1;
            item1.Created = DateTime.Now;
            item1.Deadline = DateTime.Now.AddDays(1);
            item1.ToDo = "Create the first todo";
            item1.IsDone = true;
            item1.IsFavorite = true;
            item1.Repeat = 0;
            ToDoList.toDos.Add(item1);

            ToDoItem item2 = new ToDoItem();
            item2.Title = "Second Todo";
            item2.ID = ToDoList.toDos.Count + 1;
            item2.Created = DateTime.Now;
            item2.Deadline = DateTime.Now.AddDays(2);
            item2.ToDo = "Create the second todo";
            item2.IsDone = false;
            item2.IsFavorite = false;
            item2.Repeat = 0;
            ToDoList.toDos.Add(item2);

            ToDoItem item3 = new ToDoItem();
            item3.Title = "Third Todo";
            item3.ID = ToDoList.toDos.Count + 1;
            item3.Created = DateTime.Now;
            item3.Deadline = DateTime.Now.AddDays(3);
            item3.ToDo = "Create the third todo";
            item3.IsDone = false;
            item3.IsFavorite = false;
            item3.Repeat = 0;
            ToDoList.toDos.Add(item3);
        }

        public static void DeleteToDo()
        {
            ToDoMenu menu = new ToDoMenu();

            int menuChoice;
            do
            {
                Write("Please choose an ID from the list: ");

            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > ToDoList.toDos.Count);

            string isSure;
            do
            {
                Write($"Are you sure you want to delete todo at index { menuChoice }? y/n");
                isSure = ReadLine().ToLower();
            } while (isSure != "y" && isSure != "n");

            if (isSure == "y")
            {
                ToDoList.toDos.RemoveAt(menuChoice - 1);

                WriteLine("Todo has been deleted! Press any key to return to the main menu");
                ReadKey();
                menu.MainMenu();
            }
            else
            {
                menu.MainMenu();
            }
        }
    }
}
