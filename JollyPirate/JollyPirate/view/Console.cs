using System;
using System.Collections.Generic;
using System.Text;

namespace Member.view
{
    class Console

    {
        private const char keyToExit = 'q';

        public void DisplayMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Welcome to The Jolly Pirates system!");
            System.Console.WriteLine("Press indicated key to navigate through system:");
            System.Console.WriteLine("1. Add member");
            System.Console.WriteLine("2. List members");
            System.Console.WriteLine("3. View member");
            System.Console.WriteLine("4. Edit member");
            System.Console.WriteLine("5. Delete member");
            System.Console.WriteLine($"Or press { keyToExit } to quit.");
        }

        public bool SystemActive()
        {
        return System.Console.ReadKey().KeyChar != keyToExit;
        }

        public char GetInput()
        {
            return System.Console.ReadKey().KeyChar;
        }

    }
}
