using System;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class PenInkName : Value<PenInkName>
    {
        public string Value { get; }
        
        internal PenInkName(string text) => Value = text;
        
        public static PenInkName FromString(String inkName) => new PenInkName(inkName);
        
        public static PenInkName FromBottleOfInk(BottleOfInk bottleOfInk) => new PenInkName(bottleOfInk);

        private PenInkName(BottleOfInk bottleOfInk)
        {
            if (bottleOfInk == null)
                throw new ArgumentException("Bottle of ink must be specified", nameof(bottleOfInk));
            
            Value = bottleOfInk.GetInkName();
        }
        
        public static implicit operator string(PenInkName text) =>
            text.Value;
    }
}