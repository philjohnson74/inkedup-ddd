using System;
using InkedUp.Domain;
using Xunit;

namespace InkedUp.Tests
{
    public class InkTest
    {
        [Fact]
        public void Ink_objects_with_the_same_name_should_be_equal()
        {
            BottleOfInk bottleOfInk = new BottleOfInk(
                new BottleOfInkId(Guid.NewGuid()), 
                new UserId(Guid.NewGuid())
                );
            Ink firstInk = Ink.FromBottleOfInk(bottleOfInk);
            Ink secondInk = Ink.FromBottleOfInk(bottleOfInk);
            
            Assert.Equal(firstInk, secondInk);
        }
        
        [Fact]
        public void Ink_name_is_taken_from_bottle_of_ink()
        {
            BottleOfInk bottleOfInk = new BottleOfInk(
                new BottleOfInkId(Guid.NewGuid()), 
                new UserId(Guid.NewGuid())
            );
            bottleOfInk.UpdateManufacturer("Montblanc");
            bottleOfInk.UpdateColour("Irish Green");
            
            Ink ink = Ink.FromBottleOfInk(bottleOfInk);

            Assert.Equal("Montblanc - Irish Green", ink.Name);
        }
        
        [Fact]
        public void Ink_needs_bottle_of_ink_to_be_dispensed_from()
        { 
            Assert.Throws<ArgumentException>(() => Ink.FromBottleOfInk(null));
        }
    }
}