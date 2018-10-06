using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace JollyPirate.model
{
    class Roster
    {
        internal view.Console Console;
        internal view.MemberView MemberView;

        private List<Member> Members;

        public Roster(view.Console console, view.MemberView memberView)
        {
            Console = console;
            MemberView = memberView;
            Members = GetCurrentMembers();
        }

        public void SetMembers(List<Member> members)
        {
            Members = members;
        }

        public void CreateNewMember(string name, string personalNumber)
        {
            Member newMember;
            string memberId = GenerateMemberId();
            newMember = new Member(name, personalNumber, memberId);
            Members.Add(newMember);
            SaveMembersToFile();
            MemberView.NewMemberAdded(newMember);

        }

        public void ListMembers()
        {
            foreach (Member m in Members)
            {
                MemberView.WriteMemberToConsole(m);
            }
            Console.PressToContinue();
        }

        public void ListMembersWithDetails()
        {
            foreach (Member m in Members)
            {
                MemberView.WriteMemberToConsole(m, true);
            }
            Console.PressToContinue();
        }

        public void ViewMember()
        {
            
            string memberId = MemberView.ViewMemberById();
            Member member = FindMemberById(memberId);

            if (member.GetMemberId() != "0")
            {
                MemberView.WriteMemberToConsole(member);
                Console.PressToContinue();
            }
            else
            {
                MemberView.MemberNotFound();
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

        public Member FindMemberById(string id)
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
     
        public void DeleteMember(Member member)
        {           
            if (MemberView.ConfirmDelete(member.GetName()))
            {
                Members.Remove(member);
            }
        }
        public void SetName(string id, string name)
        {
            Member member = FindMemberById(id);
            member.SetName(name);
        }        
    }    
}
