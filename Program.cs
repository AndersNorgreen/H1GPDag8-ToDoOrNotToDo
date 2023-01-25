using static System.Console;

namespace H1GPDag8
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoItem.AddFakeTodos();
            ToDoMenu main = new ToDoMenu();

            main.MainMenu();
            ReadKey();
        }
    }
}