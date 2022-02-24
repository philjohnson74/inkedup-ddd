using System;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class PenId : IEquatable<PenId>
    {
        private Guid Value { get; }

        public PenId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Pen id cannot be empty");
            
            Value = value;
        }

        public static implicit operator Guid(PenId self) => self.Value;
        
        public static implicit operator PenId(string value) 
            => new PenId(Guid.Parse(value));

        public override string ToString() => Value.ToString();

        public bool Equals(PenId other)
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
            return Equals((PenId) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}