using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class PenModel : Value<PenModel>
    {
        public string Value { get; }

        internal PenModel(string text) => Value = text;
    
        public static PenModel FromString(string text) =>
            new PenModel(text);
    
        public static implicit operator string(PenModel text) =>
            text.Value;
    }
}