using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace JollyPirate.controller
{
    class User
    {
        internal view.Console Console
        {
            get => new view.Console();
        }

        internal model.Roster Roster
        {
            get => new model.Roster(Console);
        }

        public void StartSystem()
        {
            Console.DisplayMenu();

            Roster.GetCurrentMembers();

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
                    Roster.CreateNewMember();
                }

                if ( input == "2")
                {
                    Roster.ListMembers();

                }
                if (input == "3")
                {
                    Roster.ListMembersWithDetails();
                }

                if (input == "4")
                {
                    Roster.ViewMember();
                }

                if (input == "5")
                {
                    Roster.EditMember();
                }
            }
        }       
    }
}
