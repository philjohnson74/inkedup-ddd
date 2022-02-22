namespace InkedUp.Domain
{
    public class BottleOfInk
    {
        public BottleOfInkId Id { get; private set; }

        public BottleOfInk(BottleOfInkId id, UserId ownerId)
        {
            Id = id;
            OwnerId = ownerId;
        }

        public void UpdateManufacturer(BottleOfInkManufacturer manufacturer) => Manufacturer = manufacturer;
        
        public void UpdateColour(BottleOfInkColour colour) => Colour = colour;

        public string GetInkName() => $"{Manufacturer} - {Colour}";

        public UserId OwnerId { get;  }
        public BottleOfInkManufacturer Manufacturer { get; private set; }
        public BottleOfInkColour Colour { get; private set; }
    }
}