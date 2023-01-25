using static System.Console;
using System.Linq;

namespace H1GPDag8
{
    class ToDoList
    {
        public static List<ToDoItem> toDos = new List<ToDoItem>();

        public static void ShowAllTodos ()
        {
            Clear();
            foreach (ToDoItem item in toDos)
            {
                WriteLine($"{ item.ID }. { item.Title } " + (item.IsFavorite == true ? "*" : ""));
            }
     
            WriteLine(Environment.NewLine + "Press <S> to see more info, <D> to delete a todo or <T> to return to the main menu");

            while (ReadKey(true).Key != ConsoleKey.T || ReadKey(true).Key != ConsoleKey.S || ReadKey(true).Key != ConsoleKey.D)
            {
                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.T:
                        ToDoMenu mainMenu = new ToDoMenu();
                        Clear();
                        mainMenu.MainMenu();
                        break;
                    case ConsoleKey.S:
                        ShowTodoFromList();
                        break;
                    case ConsoleKey.D:
                        ToDoItem.DeleteToDo();
                        break;
                }
            }
        }

        private static void ShowTodoFromList()
        {
            int menuChoice;
            do
            {
                Write("Please choose an ID from the list: ");

            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > toDos.Count);

            foreach (ToDoItem item in toDos)
            {
                if (menuChoice == item.ID)
                {
                    Clear();
                    item.ShowItemData(item);
                }
            }
        }
    }
}
