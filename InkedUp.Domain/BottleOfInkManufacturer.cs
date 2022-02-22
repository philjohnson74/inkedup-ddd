using System;
using System.Net.Mime;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class BottleOfInkManufacturer : Value<BottleOfInkManufacturer>
    {
        public string Value { get; }

        internal BottleOfInkManufacturer(string text) => Value = text;
    
        public static BottleOfInkManufacturer FromString(string text) =>
            new BottleOfInkManufacturer(text);
    
        public static implicit operator string(BottleOfInkManufacturer text) =>
            text.Value;
    }
}