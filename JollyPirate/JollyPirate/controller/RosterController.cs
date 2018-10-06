
namespace JollyPirate.controller
{
    class RosterController
    {
        private view.MemberView MemberView;
        private model.Roster Roster;

        public RosterController(view.MemberView memberView, model.Roster roster)
        {
            MemberView = memberView;
            Roster = roster;
        }
        public void AddNewMember()
        {
            string name = MemberView.GetNewMemberName();
            if (name != "back")
            {
                string personalNumber = MemberView.GetPersonalNumber();
                if (personalNumber != "back")
                {
                    Roster.CreateNewMember(name, personalNumber);
                }
            }
        }

        public void DeleteMember()
        {
            string memberId = DeleteMemberById();
            model.Member member = Roster.FindMemberById(memberId);
            Roster.DeleteMember(member);
        }
        public string DeleteMemberById()
        {
            System.Console.WriteLine("Type the Id of the member you want to delete:");
            return System.Console.ReadLine();
        }
    }
}
