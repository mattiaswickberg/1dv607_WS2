﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Member.model
{
    class Member
    {
        private String name;
        private String personalNumber;
        private String memberId;
        private Array boats;


        public String getName()
        {
            return name;
        }

        public String getPersonalNumber()
        {
            return personalNumber;
        }

        public String getMemberId() {
            return memberId;
        }

        public Object registerNewBoat(String type, Int32 length)
        {

        }
               
        public void WriteDataToFile(String dataToWrite)
        {
            string currentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            System.IO.File.WriteAllText(String.Concat(currentDirectory, @"\members.txt"), dataToWrite);
        }

    }
}
