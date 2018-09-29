using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace JollyPirate.model
{
    class Member
    {
        private string Name;
        private string PersonalNumber;
        private string MemberId;
        private List<Boat> Boats;

        public Member(string nameToAdd, string personalNumberToAdd, string memberIdToAdd)
        {
            Name = nameToAdd;
            PersonalNumber = personalNumberToAdd;
            MemberId = memberIdToAdd;
            Boats = new List<Boat>();
        }

        internal Boat Boat
        {
            get => default(Boat);
        }

        public string getName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetPersonalNumber()
        {
            return PersonalNumber;
        }

        public void SetPersonalNumber(string personalNumber)
        {
            PersonalNumber = personalNumber;
        }

        public string GetMemberId()
        {
            return MemberId;
        }

        public void SetMemberId(string id)
        {
            MemberId = id;
        }

        public List<Boat> getBoats()
        {
            return Boats;
        }

        public void SetBoats(List<Boat> boats)
        {
            Boats = boats;
        }

        public string ToString(bool details = false)
        {
            if (details)
            {
                return "Member: " + Name + Environment.NewLine + ". Personal Number: " + PersonalNumber + Environment.NewLine + ". Member Id: " + MemberId + Environment.NewLine + ". Boats: " + BoatsToString();
            } else
            {
                return "Member: " + Name + ". Member Id: " + MemberId + ". Number of boats: " + NumberOfBoats() + ".";
            }
        }


        public void RegisterNewBoat(String type, Int32 length, string id)
        {
            if (id == "0")
            {
                id = GenerateBoatId();
            }
            Boat boat = new Boat(type, length, id);
            Boats.Add(boat);
        }

        private string GenerateBoatId()
        {
            int id = 100;

            foreach (Boat b in Boats)
            {
                Int32 bId = Int32.Parse(b.GetId());
                if (bId >= id)
                {
                    id = (bId + 1);
                }
            }
            return id.ToString();
        }

        private string NumberOfBoats()
        {
            return Boats.Count.ToString();
        }

        public string BoatsToString()
        {
            string boats = "";

            foreach (Boat b in Boats)
            {
                boats += Environment.NewLine + "Boat with id: " + b.GetId() + Environment.NewLine + "Type: " + b.getType() + Environment.NewLine + "Length: " + b.getLength() + Environment.NewLine;
            }

            return boats;
        }
    }
}
