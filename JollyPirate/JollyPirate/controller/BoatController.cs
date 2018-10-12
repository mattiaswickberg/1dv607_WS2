using System;

namespace JollyPirate.controller
{
    class BoatController
    {
        private view.BoatView BoatView;
        private model.Roster Roster;

        public BoatController(view.BoatView boatView, model.Roster roster)
        {
            BoatView = boatView;
            Roster = roster;
        }

        public void BoatMenu(model.Member member)
        {
            string newChoice = BoatView.BoatMenu();
            if (newChoice == "1")
            {
                AddBoat(member);
                
            }
            else if (newChoice == "2")
            {
                EditBoat(member);
            }
            else if (newChoice == "3")
            {
                DeleteBoat(member);
            }
            else
            {
                BoatView.InvalidChoice();
            }
        }
        public void AddBoat(model.Member member)
        {
            BoatView.AddBoatMenu();
            string type = BoatType();

            if (type.Length == 0)
            {
                BoatView.InvalidChoice();
            }
            else
            {
                string lengthAsString = BoatView.GetBoatLength();
                if (Int32.TryParse(lengthAsString, out int length))
                {
                    member.RegisterNewBoat(type, length, "0");
                    Roster.ListMembersWithDetails();
                    BoatView.Success();
                }
                else
                {
                    BoatView.InvalidChoice();
                }
            }
        }

        public string BoatType()
        {
            string choice = BoatView.ChooseBoatType();
            string type = "";

            switch (choice)
            {
                case "1":
                    {
                        type = "Sailboat";
                        break;
                    }
                case "2":
                    {
                        type = "Motorsailer";
                        break;
                    }
                case "3":
                    {
                        type = "Kayak/Canoe";
                        break;
                    }
                case "4":
                    {
                        type = "Other";
                        break;
                    }
            }
            return type;
        }

        public void EditBoat(model.Member member)
        {
            string id = BoatView.EditBoatMenu(member.getBoats());
            model.Boat boat = new model.Boat("Other", 1, "0");
            foreach (model.Boat b in member.getBoats())
            {
                if (b.GetId() == id)
                {
                    boat = b;
                }
            }
            if (boat.GetId() == "0")
            {
                BoatView.BoatNotFound();
            }
            else
            {
                string choice = BoatView.EditBoatChoice();
                if (choice == "1")
                {
                    BoatView.ChangeType();
                    string type = BoatType();

                    if (type.Length == 0)
                    {
                        BoatView.InvalidChoice();
                    }
                    else
                    {
                        boat.setType(type);
                        BoatView.Success();
                    }
                }
                else if (choice == "2")
                {
                    string lengthAsString = BoatView.GetBoatLength();
                    if (Int32.TryParse(lengthAsString, out int length))
                    {
                        boat.setLength(length);
                        BoatView.Success();
                    }
                    else
                    {
                        BoatView.InvalidChoice();
                    }

                }
                else
                {
                    BoatView.InvalidChoice();
                }
            }
        }

        public void DeleteBoat(model.Member member)
        {
            string id = BoatView.GetBoatIdToDelete(member.getBoats());
            if (BoatView.ConfirmDelete())
            {
                member.DeleteBoat(id);
            }

        }
    }
}
