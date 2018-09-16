using System;

namespace JollyPirate
{
    class Program
    {
        static void Main(string[] args)
        {
            model.JollyPirate m = new model.JollyPirate();
            view.Console v = new view.Console();
            controller.User c = new controller.User();

            c.StartSystem(m, v);
        }
    }
}
