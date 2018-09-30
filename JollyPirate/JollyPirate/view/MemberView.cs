using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPirate.view
{
    class MemberView
    {
        public string GetNewMemberName()
        {
            System.Console.Clear();
            System.Console.WriteLine("Please type in name of member that you want to save and press enter:");
            System.Console.WriteLine("Or type 'back' to return to main menu.");
            return System.Console.ReadLine();
        }
        public string GetPersonalNumber()
        {
            System.Console.WriteLine("Type in the member's personal number: ");
            System.Console.WriteLine("Or type 'back' to return to main menu.");
            return System.Console.ReadLine();
        }

        public void NewMemberAdded(string member)
        {
            System.Console.Write("Member was added successfully: ");
            System.Console.Write(member);
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

        public void WriteMemberToConsole(string member)
        {
            System.Console.WriteLine("---------------------------------------" + Environment.NewLine);
            System.Console.Write(member + Environment.NewLine);
        }

        public string ViewMemberById()
        {
            System.Console.WriteLine("Type the Id of the member you want to view:");
            return System.Console.ReadLine();
        }

        public string EditMemberById()
        {
            System.Console.WriteLine("Type the Id of the member you want to edit:");
            return System.Console.ReadLine();
        }

        public void MemberNotFound()
        {
            System.Console.WriteLine("No member with that Id found.");
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();

        }

    }
}
