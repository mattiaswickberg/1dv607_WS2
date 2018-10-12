using System;

namespace JollyPirate.controller
{
    class User
    {
        private view.Console Console;
        private view.BoatView BoatView;
        private view.MemberView MemberView;
        private model.Roster Roster;
        private RosterController RosterController;
        private MemberController MemberController;

        public User()
        {
            Console = new view.Console();
            BoatView = new view.BoatView();
            MemberView = new view.MemberView();
            Roster = new model.Roster(Console, MemberView);
            RosterController = new RosterController(MemberView, Roster);
            MemberController = new MemberController(Roster, MemberView, BoatView);

        }
        public void StartSystem()
        {
            string input;
            bool systemActive = true;

            while(systemActive)
            {
                input = Console.DisplayMenu();

                switch (input)
                {
                    case "quit":
                        {
                            Roster.SaveMembersToFile();
                            systemActive = false;
                            break;
                        }
                    case "1":
                        {
                            RosterController.AddNewMember();
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
                            string memberId = EditMemberById();
                            model.Member member = Roster.FindMemberById(memberId);
                            MemberController.EditMember(member);
                            break;
                        }
                    case "6":
                        {
                            RosterController.DeleteMember();
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
        public string EditMemberById()
        {
            Console.InputMemberId();
            return System.Console.ReadLine();
        }        
    }
}
