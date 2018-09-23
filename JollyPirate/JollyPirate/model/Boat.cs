using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPirate.model
{
    class Boat
    {
        private string Type;
        private int Length;

        public Boat(string type, int length)
        {

        }

        public string getType()
        {
            return Type;
        }

        public void setType(string newType)
        {
            Type = newType;
        }

        public int getLength()
        {
            return Length;
        }

        public void setLength(int newLength)
        {
            Length = newLength;
        }


    }
}
