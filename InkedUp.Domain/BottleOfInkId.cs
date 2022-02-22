using System;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class BottleOfInkId : Value<BottleOfInkId>
    {
        private readonly Guid _value;

        public BottleOfInkId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Bottle of ink id cannot be empty");

            _value = value;
        }
    }
}