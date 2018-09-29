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

        private List<Member> Members;

        public Roster(view.Console console)
        {
            Console = console;
            Members = GetCurrentMembers();
        }

        public void SetMembers(List<Member> members)
        {
            Members = members;
        }

        public void CreateNewMember()
        {
            Console.GetNewMemberName();
            string name = System.Console.ReadLine();
            Console.GetPersonalNumber();
            string personalNumber = System.Console.ReadLine();
            System.Console.WriteLine("New member's name is: " + name);
            System.Console.WriteLine("New member's personal number is: " + personalNumber);
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadLine();
            Member newMember;
            string memberId = GenerateMemberId();
            newMember = new Member(name, personalNumber, memberId);
            Members.Add(newMember);
            SaveMembersToFile();
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadLine();
        }

        public void ListMembers()
        {
            foreach (Member m in Members)
            {
                System.Console.WriteLine(m.ToString());
            }
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();
        }

        public void ListMembersWithDetails()
        {
            foreach (Member m in Members)
            {
                System.Console.WriteLine(m.ToString(true));
            }
            System.Console.WriteLine("Press any key to continue ...");
            System.Console.ReadKey();
        }

        public void ViewMember()
        {
            Console.ViewMemberById();
            string memberId = System.Console.ReadLine();
            Member member = FindMemberById(memberId);

            if (member.GetMemberId() != "0")
            {
                System.Console.WriteLine("");
                System.Console.Write(member.ToString(true));
                System.Console.WriteLine(Environment.NewLine + "Press any key to continue ...");
                System.Console.ReadKey();
            } else
            {
                Console.MemberNotFound();
            }
        }

        public void EditMember()
        {
            Console.EditMemberById();
            string memberId = System.Console.ReadLine();
            Member member = FindMemberById(memberId);

            if (member.GetMemberId() != "0")
            {
                Console.EditMemberMenu();
                string choice = System.Console.ReadLine();

                if (choice == "1")
                {
                    Console.GetNewMemberName();
                    string name = System.Console.ReadLine();
                    member.SetName(name);
                    SaveMembersToFile();
                    Console.Success();

                } else if (choice == "2")
                {
                    Console.GetPersonalNumber();
                    string personalNumber = System.Console.ReadLine();
                    member.SetPersonalNumber(personalNumber);
                    SaveMembersToFile();
                    Console.Success();

                } else if (choice == "3")
                {
                    Console.BoatMenu();
                    string newChoice = System.Console.ReadLine();
                    if(newChoice == "1")
                    {
                        AddBoat(member);                        
                    }
                    else if (newChoice == "2")
                    {
                        EditBoat(member);
                    }
                    else
                    {
                        Console.InvalidChoice();
                    }

                } else if (choice == "4")
                {
                    if (Console.ConfirmDelete(member.getName()))
                    {
                        Members.Remove(member);
                        SaveMembersToFile();
                    }

                } else
                {
                    Console.InvalidChoice();
                }
                System.Console.WriteLine(Environment.NewLine + "Press any key to continue ...");
                System.Console.ReadKey();
            }
            else
            {
                Console.MemberNotFound();
            }
        }

        public void AddBoat(Member member)
        {
            Console.AddBoatMenu();
            Console.ChooseBoatType();
            string type = BoatType();
            
            if(type.Length == 0)
            {
                Console.InvalidChoice();
            }
            else
            {
                Console.GetBoatLength();
                string lengthAsString = System.Console.ReadLine();
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
            string choice = System.Console.ReadLine();
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
            Console.EditBoatMenu(member.BoatsToString());
            string id = System.Console.ReadLine();
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
                Console.BoatNotFound();
            }
            else
            {
                Console.EditBoatChoice();
                string choice = System.Console.ReadLine();
                if (choice == "1")
                {
                    Console.ChooseBoatType();
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
                    Console.GetBoatLength();
                    string lengthAsString = System.Console.ReadLine();
                    int length;
                    if (Int32.TryParse(lengthAsString, out length))
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
            System.Console.WriteLine("Saving members ...");
            ListMembersWithDetails();
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
                    Name = m.getName(),
                    PersonalNumber = m.GetPersonalNumber(),
                    MemberId = m.GetMemberId(),
                    Boats = boatsToSave,
                };                

                membersToSave.Add(memberToSave);
            }

            string membersAsJson = JsonConvert.SerializeObject(membersToSave);
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
