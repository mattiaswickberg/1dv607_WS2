namespace JollyPirate.view
{
    class Console

    {

        public void DisplayMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Welcome to The Jolly Pirates system!");
            System.Console.WriteLine("Press indicated key and enter to make your choice:");
            System.Console.WriteLine("1. Add member");
            System.Console.WriteLine("2. List members");
            System.Console.WriteLine("3. View member");
            System.Console.WriteLine("4. Edit member");
            System.Console.WriteLine("5. Delete member");
            System.Console.WriteLine($"Or type 'quit' to exit.");
        }

        public void GetNewMemberName()
        {
            System.Console.Clear();
            System.Console.WriteLine("You want to create a new member! Please type in name of member and press enter:");
        }
        public void GetPersonalNumber()
        {
            System.Console.WriteLine("Type in the new member's personal number: ");
        }
    }
}
