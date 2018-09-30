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

        internal view.BoatView BoatView
        {
            get => new view.BoatView();
        }

        internal view.MemberView MemberView
        {
            get => new view.MemberView();
        }

        internal model.Roster Roster
        {
            get => new model.Roster(Console, MemberView, BoatView);
        }

        public void StartSystem()
        {
            Roster.GetCurrentMembers();

            string input;
            bool systemActive = true;

            while(systemActive)
            {
                input = Console.DisplayMenu();

                switch (input)
                {
                    case "quit":
                        {
                            systemActive = false;
                            break;
                        }
                    case "1":
                        {
                            Roster.CreateNewMember();
                            break;
                        }
                    case "2":
                        {
                            Roster.ListMembers();
                            break;
                        }
                    case "3":
                        {
                            Roster.ListMembersWithDetails();
                            break;
                        }
                    case "4":
                        {
                            Roster.ViewMember();
                            break;
                        }
                    case "5":
                        {
                            Roster.EditMember();
                            break;
                        }
                    default:
                        {
                            Console.InvalidChoice();
                            break;
                        }
                }                
            }
        }       
    }
}
