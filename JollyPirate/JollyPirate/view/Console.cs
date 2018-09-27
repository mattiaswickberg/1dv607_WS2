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
            System.Console.WriteLine("3. List members with details");
            System.Console.WriteLine("4. View member");
            System.Console.WriteLine("5. Edit member");
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

        public void GetBoatType()
        {
            System.Console.Clear();
            System.Console.WriteLine("Please choose type of boat:");
            System.Console.WriteLine("1. Sailboat");
            System.Console.WriteLine("2. Motorsailer");
            System.Console.WriteLine("3. Kayak/Canoe");
            System.Console.WriteLine("4. Other");
        }

        public void GetBoatLength()
        {
            System.Console.WriteLine("Type in the boat's length in whole meters:");
        }

        public void ViewMemberById()
        {
            System.Console.WriteLine("Type the Id of the member you want to view:");
        }

        public void EditMemberById()
        {
            System.Console.WriteLine("Type the Id of the member you want to edit:");
        }

        public void MemberNotFound()
        {
            System.Console.WriteLine("No member with that Id found.");
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();

        }
        public void BoatNotFound()
        {
            System.Console.WriteLine("No boat with that Id found.");
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();

        }


    }
}
