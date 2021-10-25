using System;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class PenId : Value<PenId>
    {
        private readonly Guid _value;

        public PenId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Pen id cannot be empty");

            _value = value;
        }
    }
}