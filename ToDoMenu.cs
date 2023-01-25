using static System.Console;

namespace H1GPDag8
{
    public class ToDoMenu
    {
        // Start menu
        public void MainMenu()
        {
            Clear();
            string[] mainMenuOptions = new string[] { "Add new todo", "View todos" };

            switch (MenuTemplate(mainMenuOptions))
            {
                case 1:
                    ToDoItem.AddNewItem();
                    break;
                case 2:
                    ToDoList.ShowAllTodos();
                    break;
                case 3:
                    Quit();
                    break; 
            }
        }

        public int MenuTemplate(string[] menuOptions)
        {
            int menuIndex = 1;
            foreach (var option in menuOptions)
            {
                WriteLine($"{menuIndex}. { option }");
                menuIndex++;
            }
            WriteLine($"{ menuIndex }. Afslut");
            WriteLine();

            int menuChoice;
            do
            {
                Write("Vælg venligst en mulighed fra menuen: ");
            } while (!Int32.TryParse(ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > (menuOptions.Length + 1));

            return menuChoice;
        }

        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}
