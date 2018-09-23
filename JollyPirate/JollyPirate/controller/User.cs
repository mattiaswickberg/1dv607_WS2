using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPirate.controller
{
    class User
    {
        internal model.Member Member
        {
            get => default(model.Member);
        }

        internal view.Console Console
        {
            get => new view.Console();
        }

        public void StartSystem()
        {
            Console.DisplayMenu();

            string input;
            bool systemActive = true;

            while(systemActive)
            {
                Console.DisplayMenu();

                input = System.Console.ReadLine();
                System.Console.WriteLine(input);


                if (input == "quit")
                {
                    systemActive = false;
                }

                if (input == "1")
                {
                    CreateNewMember();
                }
            }
        }

        private String[] ListMembers()
        {
            throw new System.NotImplementedException();
        }

        private String[] ListMembersWithDetails()
        {
            throw new System.NotImplementedException();
        }

        private void CreateNewMember()
        {
            Console.GetNewMemberName();
            string name = System.Console.ReadLine();
            Console.GetPersonalNumber();
            string personalNumber = System.Console.ReadLine();
            System.Console.WriteLine("New member's name is: " + name);
            System.Console.WriteLine("New member's personal number is: " + personalNumber);
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadLine();
            model.Member newMember;
            newMember = new model.Member(name, personalNumber);
            newMember.SaveUserToFile();
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadLine();
        }
        
    }
}
