using System;
using System.Net.Mime;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class BottleOfInkColour : Value<BottleOfInkColour>
    {
        public string Value { get; }

        internal BottleOfInkColour(string text) => Value = text;
    
        public static BottleOfInkColour FromString(string text) =>
            new BottleOfInkColour(text);
    
        public static implicit operator string(BottleOfInkColour text) =>
            text.Value;
    }
}