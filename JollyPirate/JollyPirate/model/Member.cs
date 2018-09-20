using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Member.model
{
    class Member
    {
               
        public void WriteDataToFile(String dataToWrite)
        {
            string currentDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            System.IO.File.WriteAllText(String.Concat(currentDirectory, @"\members.txt"), dataToWrite);
        }

    }
}
