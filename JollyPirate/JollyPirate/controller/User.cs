using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPirate.controller
{
    class User
    {
        public void StartSystem(model.JollyPirate a_system, view.Console a_view)
        {
            a_view.DisplayMenu();

            while(a_view.SystemActive())
            {
                a_view.DisplayMenu();
            }
        }
    }
}
