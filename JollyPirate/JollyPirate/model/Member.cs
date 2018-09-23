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
        private readonly string MemberId;
        private Boat[] Boats = Array.Empty<Boat>();

        public Member(String nameToAdd, String personalNumberToAdd)
        {
            Name = nameToAdd;
            PersonalNumber = personalNumberToAdd;
            MemberId = "1";
        }

        internal JollyPirate.model.Boat Boat
        {
            get => default(JollyPirate.model.Boat);
        }

        public String getName()
        {
            return Name;
        }

        public void setName(string name)
        {
            Name = name;
        }

        public String getPersonalNumber()
        {
            return PersonalNumber;
        }

        public void setPersonalNumber(string personalNumber)
        {
            PersonalNumber = personalNumber;
        }

        public String getMemberId() {
            return MemberId;
        }

        public Object registerNewBoat(String type, Int32 length)
        {
            throw new System.NotImplementedException();
        }

        public void SaveUserToFile()
        {
            object member = new
            {
                this.Name,
                this.PersonalNumber,
                this.MemberId,
                this.Boats
            };
            string memberAsJson = JsonConvert.SerializeObject(member);
            string currentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            Console.WriteLine(memberAsJson);
            File.WriteAllText(String.Concat(currentDirectory, @"\members.txt"), memberAsJson);
        }

    }
}
