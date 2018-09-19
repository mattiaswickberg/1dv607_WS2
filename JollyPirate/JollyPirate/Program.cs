using System;

namespace Member
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Member m = new model.Member();
            view.Console v = new view.Console();
            controller.User c = new controller.User();

            c.StartSystem(m, v);
        }
    }
}
