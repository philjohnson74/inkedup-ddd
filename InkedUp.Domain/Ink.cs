using System;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class Ink : Value<Ink>
    {
        public string Name { get;  }

        public Ink(BottleOfInk bottleOfInk)
        {
            if (bottleOfInk == null)
                throw new ArgumentException("Bottle of ink must be specified", nameof(bottleOfInk));
            
            Name = bottleOfInk.GetInkName();
        }
    }
}