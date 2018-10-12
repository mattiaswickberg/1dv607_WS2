using System;
using System.Collections.Generic;

namespace JollyPirate.view
{
    class MemberView
    {
        public string InputMemberIdToDelete()
        {
            System.Console.WriteLine("Type the Id of the member you want to delete:");
            return System.Console.ReadLine();
        }
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

        public void NewMemberAdded(model.Member member)
        {
            System.Console.Write("Member was added successfully: ");
            WriteMemberToConsole(member);
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();
        }
        public void EditMemberMenu()
        {
            System.Console.WriteLine("Which of the following do you want to edit?");
            System.Console.WriteLine("1. Name");
            System.Console.WriteLine("2. Personal number");
            System.Console.WriteLine("3. Boats");
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

        public void WriteMemberToConsole(model.Member member, bool details = false)
        {
            if(details)
            {
                System.Console.WriteLine("---------------------------------------" + Environment.NewLine);
                System.Console.Write("Name: " + member.GetName()
                    + Environment.NewLine + ". Personal Number: " + member.GetPersonalNumber()
                    + Environment.NewLine + ". Member Id: " + member.GetMemberId()
                    + Environment.NewLine + ". Boats: " + BoatsToString(member.getBoats()));
            }
            else
            {
                System.Console.Write(Environment.NewLine 
                    + "Name: " + member.GetName() 
                    + ". Member Id: " + member.GetMemberId() 
                    + ". Number of boats: " + member.getBoats().Count.ToString() + "." 
                    + Environment.NewLine);
            }            
        }

        public string ViewMemberById()
        {
            System.Console.WriteLine("Type the Id of the member you want to view:");
            return System.Console.ReadLine();
        }        

        public void MemberNotFound()
        {
            System.Console.WriteLine("No member with that Id found.");
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();

        }

        public void InvalidChoice()
        {
            System.Console.WriteLine("You have made an invalid choice.");
            PressToContinue();
        }


        public void Success()
        {
            System.Console.WriteLine("Your changes have been made succesfully!");
            PressToContinue();
        }

        public void PressToContinue()
        {
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();
        }
        public string BoatsToString(List<model.Boat> Boats)
        {
            string boats = "";

            foreach (model.Boat b in Boats)
            {
                boats += Environment.NewLine + "Boat with id: " + b.GetId()
                    + Environment.NewLine + "Type: " + b.getType()
                    + Environment.NewLine + "Length: " + b.getLength()
                    + Environment.NewLine;
            }
            return boats;
        }

    }
}
