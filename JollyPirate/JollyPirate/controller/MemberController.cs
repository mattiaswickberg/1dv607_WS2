

namespace JollyPirate.controller
{
    class MemberController
    {
        private model.Roster Roster;
        private view.MemberView MemberView;
        private view.BoatView BoatView;
        private BoatController BoatController;

        public MemberController(model.Roster roster, view.MemberView memberView, view.BoatView boatView)
        {
            Roster = roster;
            MemberView = memberView;
            BoatView = boatView;
            BoatController = new BoatController(BoatView, Roster);
        }

        public void EditMember(model.Member member)
        {
            if (member.GetMemberId() != "0")
            {
                MemberView.WriteMemberToConsole(member, true);
                MemberView.EditMemberMenu();
                string choice = System.Console.ReadLine();

                if (choice == "1")
                {
                    string name = MemberView.GetNewMemberName();
                    member.SetName(name);
                    MemberView.Success();
                }
                else if (choice == "2")
                {
                    string personalNumber = MemberView.GetPersonalNumber();
                    member.SetPersonalNumber(personalNumber);
                    MemberView.Success();
                }
                else if (choice == "3")
                {
                    BoatController.BoatMenu(member);
                }
                else
                {
                    MemberView.InvalidChoice();
                }
                MemberView.PressToContinue();
            }
            else
            {
                MemberView.MemberNotFound();
            }
        }
    }
}
