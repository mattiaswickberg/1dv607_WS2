using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPirate.model
{
    public class Boat
    {
        private string Type;
        private int Length;
        private readonly string Id;
        
        /**
        * Constructor for the boat class
        **/
        public Boat(string type, int length, string id)
        {
            Type = type;
            Length = length;
            Id = id;
        }

        /**
        * Getters and setters
        **/
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

        public string GetId()
        {
            return Id;
        }
    }
}
