namespace JollyPirate.view
{
    class Console

    {

        public string DisplayMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Welcome to The Jolly Pirates system!");
            System.Console.WriteLine("Press indicated key and enter to make your choice:");
            System.Console.WriteLine("1. Add member");
            System.Console.WriteLine("2. List members");
            System.Console.WriteLine("3. List members with details");
            System.Console.WriteLine("4. View member");
            System.Console.WriteLine("5. Edit member");
            System.Console.WriteLine("6. Delete member");
            System.Console.WriteLine("Or type 'quit' to exit.");
            return System.Console.ReadLine();
        }

        public void InputMemberId()
        {
            System.Console.WriteLine("Type the Id of the member you want to edit:");
        }

        public void InvalidChoice()
        {
            System.Console.WriteLine("You have made an invalid choice.");
            PressToContinue();
        }


        public void Success()
        {
            System.Console.WriteLine("Your changes have been made!");
            PressToContinue();
        }

        public void PressToContinue()
        {
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();
        }
    }
}
