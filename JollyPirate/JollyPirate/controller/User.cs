using System;
using System.Collections.Generic;
using System.Text;

namespace Member.controller
{
    class User
    {
        public void StartSystem(model.Member a_system, view.Console a_view)
        {
            a_view.DisplayMenu();

            while(a_view.SystemActive())
            {
                a_view.DisplayMenu();

            }
        }

        public String[] ListMembers()
        {

        }

        public String[] ListMembersWithDetails()
        {

        }

        public Object CreateNewMember(String name, String personalNumber)
        {

        }


        public void WriteDataToFile(model.Member a_system, String roster)
        {
            a_system.WriteDataToFile(roster);
        }
    }
}
