using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace JollyPirate.model
{
    class Roster
    {
        internal view.Console Console;
        internal view.MemberView MemberView;
        internal view.BoatView BoatView;

        private List<Member> Members;

        public Roster(view.Console console, view.MemberView memberView, view.BoatView boatView)
        {
            Console = console;
            MemberView = memberView;
            BoatView = boatView;
            Members = GetCurrentMembers();
        }

        public void SetMembers(List<Member> members)
        {
            Members = members;
        }

        public void CreateNewMember()
        {            
            string name = MemberView.GetNewMemberName();
            if (name != "back")
            {
                string personalNumber = MemberView.GetPersonalNumber();
                if (personalNumber != "back")
                {
                    Member newMember;
                    string memberId = GenerateMemberId();
                    newMember = new Member(name, personalNumber, memberId);
                    Members.Add(newMember);
                    SaveMembersToFile();
                    MemberView.NewMemberAdded(newMember.ToString());
                }                
            }            
        }

        public void ListMembers()
        {
            foreach (Member m in Members)
            {
                MemberView.WriteMemberToConsole(m.ToString());
            }
            Console.PressToContinue();
        }

        public void ListMembersWithDetails()
        {
            foreach (Member m in Members)
            {
                MemberView.WriteMemberToConsole(m.ToString(true));
            }
            Console.PressToContinue();
        }

        public void ViewMember()
        {
            
            string memberId = MemberView.ViewMemberById();
            Member member = FindMemberById(memberId);

            if (member.GetMemberId() != "0")
            {
                MemberView.WriteMemberToConsole(member.ToString(true));
                Console.PressToContinue();
            }
            else
            {
                MemberView.MemberNotFound();
            }
        }

        public void EditMember()
        {
            string memberId = MemberView.EditMemberById();
            Member member = FindMemberById(memberId);

            if (member.GetMemberId() != "0")
            {
                MemberView.WriteMemberToConsole(member.ToString(true));
                MemberView.EditMemberMenu();
                string choice = System.Console.ReadLine();

                if (choice == "1")
                {
                    string name = MemberView.GetNewMemberName();
                    member.SetName(name);
                    Console.Success();

                } else if (choice == "2")
                {
                    string personalNumber = MemberView.GetPersonalNumber();
                    member.SetPersonalNumber(personalNumber);
                    Console.Success();

                } else if (choice == "3")
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
                        Console.InvalidChoice();
                    }

                } else if (choice == "4")
                {
                    if (MemberView.ConfirmDelete(member.GetName()))
                    {
                        Members.Remove(member);
                    }

                } else
                {
                    Console.InvalidChoice();
                }
                Console.PressToContinue();
            }
            else
            {
                MemberView.MemberNotFound();
            }
            SaveMembersToFile();
        }

        public void AddBoat(Member member)
        {
            BoatView.AddBoatMenu();
            string type = BoatType();
            
            if(type.Length == 0)
            {
                Console.InvalidChoice();
            }
            else
            {
                string lengthAsString = BoatView.GetBoatLength();
                if (Int32.TryParse(lengthAsString, out int length))
                {
                    member.RegisterNewBoat(type, length, "0");
                    SaveMembersToFile();
                    Console.Success();
                }
                else
                {
                    Console.InvalidChoice();
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

        public void EditBoat(Member member)
        {
            string id = BoatView.EditBoatMenu(member.BoatsToString());
            Boat boat = new Boat("Other", 1, "0");
            foreach (Boat b in member.getBoats())
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
                BoatView.EditBoatChoice();
                string choice = System.Console.ReadLine();
                if (choice == "1")
                {
                    BoatView.ChangeType();
                    string type = BoatType();
                    
                    if (type.Length == 0)
                    {
                        Console.InvalidChoice();
                    }
                    else
                    {
                        boat.setType(type);
                        Console.Success();
                        SaveMembersToFile();
                    }
                }
                else if (choice == "2")
                {
                    string lengthAsString = BoatView.GetBoatLength();
                    if (Int32.TryParse(lengthAsString, out int length))
                    {
                        boat.setLength(length);
                        SaveMembersToFile();
                        Console.Success();
                    }
                    else
                    {
                        Console.InvalidChoice();
                    }

                }
                else
                {
                    Console.InvalidChoice();
                }
            }
        }

        public void DeleteBoat(Member member)
        {
            string boatsAsString = member.BoatsToString();
            string id = BoatView.GetBoatIdToDelete(boatsAsString);
            if (BoatView.ConfirmDelete())
            {
                member.DeleteBoat(id);
            }
            
        }


        public List<Member> GetCurrentMembers()
        {
            List<Member> members = new List<Member>();
            dynamic membersList = new List<object>();
            string currentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string membersJson = File.ReadAllText(String.Concat(currentDirectory, @"\members.txt"));
            membersList = JsonConvert.DeserializeObject(membersJson);

            if(membersList != null)
            {
                foreach (dynamic m in membersList)
                {
                    Member member = new Member(Convert.ToString(m.Name), Convert.ToString(m.PersonalNumber), Convert.ToString(m.MemberId));

                    List<Boat> boats = new List<Boat>();

                    foreach (dynamic b in m.Boats)
                    {
                        Boat boat = new Boat(Convert.ToString(b.Type), Convert.ToInt32(b.Length), Convert.ToString(b.Id));
                        boats.Add(boat);
                    }

                    member.SetBoats(boats);

                    members.Add(member);
                }
            }
            
            return members;
        }

        public void SaveMembersToFile()
        {
            List<object> membersToSave = new List<object>();

            foreach (Member m in Members)
            {
                List<Boat> boats = m.getBoats();
                List<object> boatsToSave = new List<object>();

                foreach (Boat b in boats)
                {
                    object boatToSave = new
                    {
                        Type = b.getType(),
                        Length = b.getLength(),
                        Id = b.GetId(),
                    };
                    boatsToSave.Add(boatToSave);
                }

                object memberToSave = new
                {
                    Name = m.GetName(),
                    PersonalNumber = m.GetPersonalNumber(),
                    MemberId = m.GetMemberId(),
                    Boats = boatsToSave,
                };                

                membersToSave.Add(memberToSave);
            }

            string membersAsJson = JsonConvert.SerializeObject(membersToSave, Formatting.Indented);
            string currentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            File.WriteAllText(String.Concat(currentDirectory, @"\members.txt"), membersAsJson);
        }

        private string GenerateMemberId()
        {
            int memberIdAsInt = 1000;

            foreach (Member m in Members)
            {
                Int32 mId = Int32.Parse(m.GetMemberId());
                if (mId >= memberIdAsInt)
                {
                    memberIdAsInt = (mId + 1);
                }
            }
            return memberIdAsInt.ToString();
        }

        private Member FindMemberById(string id)
        {
            Member member = new Member("", "", "0");

            foreach (Member m in Members)
            {
                if (m.GetMemberId() == id)
                {
                    member = m;
                }
            }

            return member;
        }
    }
}
