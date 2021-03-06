﻿using System;
using System.Collections.Generic;

namespace JollyPirate.model
{
    public class Member
    {
        private string Name;
        private string PersonalNumber;
        private string MemberId;
        private List<Boat> Boats;

        /**
         * Constructor for member class
         **/
        public Member(string nameToAdd, string personalNumberToAdd, string memberIdToAdd)
        {
            Name = nameToAdd;
            PersonalNumber = personalNumberToAdd;
            MemberId = memberIdToAdd;
            Boats = new List<Boat>();
        }

         /**
         * getters and setters for private properties
         **/
        public string GetName()
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

        /**
        * Adds a new boat to the member's boat list. 
        **/
        public void RegisterNewBoat(String type, Int32 length, string id)
        {
            if (id == "0")
            {
                id = GenerateBoatId();
            }
            Boat boat = new Boat(type, length, id);
            Boats.Add(boat);
        }

        public void DeleteBoat(string id)
        {
            Boat boat = new Boat("", 0, "0");

            foreach (Boat b in Boats)
            {

                if (b.GetId() == id)
                {
                    boat = b;
                }                
            }
            if (boat.GetId() != "0")
            {
                Boats.Remove(boat);
            }
        }

        /**
        * Generates a new id for a member's boat, unique among hat member's boats. 
        **/
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
    }
}
