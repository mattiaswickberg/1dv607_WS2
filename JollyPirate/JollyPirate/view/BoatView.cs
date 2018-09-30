using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPirate.view
{
    class BoatView
    {
        public string BoatMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("1. Add new boat");
            System.Console.WriteLine("2. Edit existing boat");
            System.Console.WriteLine("3. Delete boat");
            return System.Console.ReadLine();
        }

        public void ChangeType()
        {
            System.Console.WriteLine("Choose the new type for your boat:");
        }

        public string GetBoatLength()
        {
            System.Console.WriteLine("Type in the boat's length in whole meters:");
            return System.Console.ReadLine();
        }


        public void BoatNotFound()
        {
            System.Console.WriteLine("No boat with that Id found.");
        }

        public void AddBoatMenu()
        {
            System.Console.WriteLine("Add a new boat: Please choose what type of boat you want to add:");
        }

        public string ChooseBoatType()
        {
            System.Console.WriteLine("1. Sailboat");
            System.Console.WriteLine("2. Motorsailer");
            System.Console.WriteLine("3. Kayak/Canoe");
            System.Console.WriteLine("4. Other");
            return System.Console.ReadLine();
        }

        public string EditBoatMenu(string boats)
        {
            System.Console.WriteLine(boats);
            System.Console.WriteLine("Type in the id of the boat you want to edit:");
            return System.Console.ReadLine();
        }

        public string EditBoatChoice()
        {
            System.Console.WriteLine("Which of the following do you want to edit?");
            System.Console.WriteLine("1. Type");
            System.Console.WriteLine("2. Length");
            return System.Console.ReadLine();
        }

        public string GetBoatIdToDelete(string boats)
        {
            System.Console.WriteLine(boats);
            System.Console.WriteLine("Type in the id of the boat you want to delete:");
            return System.Console.ReadLine();
        }

        public bool ConfirmDelete()
        {
            System.Console.WriteLine("Are you sure? y/n");
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
    }
}
