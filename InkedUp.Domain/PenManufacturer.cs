using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class PenManufacturer : Value<PenManufacturer>
    {
        public string Value { get; }

        internal PenManufacturer(string text) => Value = text;
    
        public static PenManufacturer FromString(string text) =>
            new PenManufacturer(text);
    
        public static implicit operator string(PenManufacturer text) =>
            text.Value;
    }
}