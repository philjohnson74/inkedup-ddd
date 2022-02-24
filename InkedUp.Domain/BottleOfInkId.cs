using System;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class BottleOfInkId : IEquatable<BottleOfInkId>
    {
        private Guid Value { get; }

        public BottleOfInkId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Bottle of ink id cannot be empty");
            
            Value = value;
        }

        public static implicit operator Guid(BottleOfInkId self) => self.Value;
        
        public static implicit operator BottleOfInkId(string value) 
            => new BottleOfInkId(Guid.Parse(value));

        public override string ToString() => Value.ToString();

        public bool Equals(BottleOfInkId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BottleOfInkId) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}