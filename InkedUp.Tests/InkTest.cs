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
            Ink firstInk = new Ink(bottleOfInk);
            Ink secondInk = new Ink(bottleOfInk);
            Assert.Equal(firstInk, secondInk);
        }
    }
}