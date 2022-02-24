using System;
using InkedUp.Domain;
using Xunit;

namespace InkedUp.Tests
{
    public class BottleOfInkTest
    {
        private readonly BottleOfInk _bottleOfInk;

        public BottleOfInkTest()
        {
            _bottleOfInk = new BottleOfInk(
                new BottleOfInkId(Guid.NewGuid()), 
                new UserId(Guid.NewGuid())
            );
        }

        [Fact]
        public void Can_update_manufacturer_of_bottle_of_ink()
        {
            _bottleOfInk.UpdateManufacturer(BottleOfInkManufacturer.FromString("Montblanc"));

            Assert.Equal("Montblanc", _bottleOfInk.Manufacturer);
        }
        
        [Fact]
        public void Can_update_colour_of_bottle_of_ink()
        {
            _bottleOfInk.UpdateColour(BottleOfInkColour.FromString("Irish Green"));
            
            Assert.Equal("Irish Green", _bottleOfInk.Colour);
        }
        
        [Fact]
        public void Can_get_ink_name_from_bottle_of_ink()
        {
            _bottleOfInk.UpdateManufacturer(BottleOfInkManufacturer.FromString("Montblanc"));
            _bottleOfInk.UpdateColour(BottleOfInkColour.FromString("Irish Green"));
            
            Assert.Equal("Montblanc - Irish Green", _bottleOfInk.GetInkName());
        }
    }
}