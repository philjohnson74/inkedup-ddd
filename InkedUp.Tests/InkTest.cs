using System;
using InkedUp.Domain;
using Xunit;

namespace InkedUp.Tests
{
    public class PenInkNameTest
    {
        [Fact]
        public void PenInkName_objects_with_the_same_name_should_be_equal()
        {
            BottleOfInk bottleOfInk = new BottleOfInk(
                new BottleOfInkId(Guid.NewGuid()), 
                new UserId(Guid.NewGuid())
                );
            PenInkName firstInk = PenInkName.FromBottleOfInk(bottleOfInk);
            PenInkName secondInk = PenInkName.FromBottleOfInk(bottleOfInk);
            
            Assert.Equal(firstInk, secondInk);
        }
        
        [Fact]
        public void PenInkName_name_is_taken_from_bottle_of_ink()
        {
            BottleOfInk bottleOfInk = new BottleOfInk(
                new BottleOfInkId(Guid.NewGuid()), 
                new UserId(Guid.NewGuid())
            );
            bottleOfInk.UpdateManufacturer(BottleOfInkManufacturer.FromString("Montblanc"));
            bottleOfInk.UpdateColour(BottleOfInkColour.FromString("Irish Green"));
            
            PenInkName penInkName = PenInkName.FromBottleOfInk(bottleOfInk);

            Assert.Equal("Montblanc - Irish Green", penInkName.Value);
        }
        
        [Fact]
        public void PenInkName_needs_bottle_of_ink_to_be_dispensed_from()
        { 
            Assert.Throws<ArgumentException>(() => PenInkName.FromBottleOfInk(null));
        }
    }
}