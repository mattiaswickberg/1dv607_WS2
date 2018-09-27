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
            bool memberFound = false;

            foreach (Member m in Members)
            {
                if (m.GetMemberId() == memberId)
                {
                    memberFound = true;
                    System.Console.WriteLine("");
                    System.Console.Write(m.ToString());
                    System.Console.WriteLine(Environment.NewLine + "Press any key to continue ...");
                    System.Console.ReadKey();

                }                
            }

            if (!memberFound)
            {
                Console.MemberNotFound();
            }
        }

        public void EditMember()
        {
            throw new NotImplementedException();
        }
        public List<Member> GetCurrentMembers()
        {
            List<Member> members = new List<Member>();
            string currentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string membersJson = File.ReadAllText(String.Concat(currentDirectory, @"\members.txt"));
            dynamic membersList = JsonConvert.DeserializeObject(membersJson);

            foreach (dynamic m in membersList)
            {         
                Member member = new Member(Convert.ToString(m.Name), Convert.ToString(m.PersonalNumber), Convert.ToString(m.MemberId));
                //member.setBoats(memberInfo.Boats);

                members.Add(member);
            }
            return members;
        }

        public void SaveMembersToFile()
        {
            List<object> membersToSave = new List<object>();

            foreach (Member m in Members)
            {
                object memberToSave = new
                {
                    Name = m.getName(),
                    PersonalNumber = m.GetPersonalNumber(),
                    MemberId = m.GetMemberId(),
                    Boats = m.getBoats()
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
    }
}
