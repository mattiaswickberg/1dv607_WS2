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
            System.Console.WriteLine("Or type 'quit' to exit.");
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

        public void EditMemberMenu()
        {
            System.Console.WriteLine("Which of the following do you want to edit?");
            System.Console.WriteLine("1. Name");
            System.Console.WriteLine("2. Personal number");
            System.Console.WriteLine("3. Boats");
            System.Console.WriteLine("4. Delete member");
        }

        public void BoatMenu()
        {
            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("1. Add new boat");
            System.Console.WriteLine("2. Edit existing boat");
        }

        public void AddBoatMenu()
        {
            System.Console.WriteLine("Add a new boat: Please choose what type of boat you want to add:");
        }

        public void ChooseBoatType()
        {
            System.Console.WriteLine("1. Sailboat");
            System.Console.WriteLine("2. Motorsailer");
            System.Console.WriteLine("3. Kayak/Canoe");
            System.Console.WriteLine("4. Other");
        }

        public void EditBoatMenu(string boats)
        {
            System.Console.WriteLine(boats);
            System.Console.WriteLine("Type in the id of the boat you want to edit:");            
        }

        public void EditBoatChoice()
        {
            System.Console.WriteLine("Which of the following do you want to edit?");
            System.Console.WriteLine("1. Type");
            System.Console.WriteLine("2. Length");
        }

        public bool ConfirmDelete(string memberName)
        {
            System.Console.WriteLine("Are you sure you want to delete member: " + memberName + "?");
            System.Console.WriteLine("Y/N");
            char confirmation = System.Console.ReadKey().KeyChar;
            if (confirmation == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InvalidChoice()
        {
            System.Console.WriteLine("You have made an invalid choice. Press any key to continue");
            System.Console.ReadKey();
        }


        public void Success()
        {
            System.Console.WriteLine("Your changes have been made!");
            System.Console.WriteLine("Press any key to continue");
            System.Console.ReadKey();
        }
    }
}
