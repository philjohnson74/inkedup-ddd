using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class BottleOfInk: Entity<BottleOfInkId>
    {
        public BottleOfInkId Id { get; private set; }
        
        public UserId OwnerId { get; private set; }
        public BottleOfInkManufacturer Manufacturer { get; private set; }
        public BottleOfInkColour Colour { get; private set; }
        
        public BottleOfInk(BottleOfInkId id, UserId ownerId)
        {
            Apply(new Events.BottleOfInkCreated()
            {
                Id = id,
                OwnerId = ownerId
            });
        }

        public void UpdateManufacturer(BottleOfInkManufacturer manufacturer)
        {
            Apply(new Events.BottleOfInkManufacturerUpdated()
            {
                Id = Id,
                Manufacturer = manufacturer
            });
        }

        public void UpdateColour(BottleOfInkColour colour)
        {
            Apply(new Events.BottleOfInkColourUpdated()
            {
                Id = Id,
                Colour = colour
            });
        }
        
        public void Delete()
        {
            Apply(new Events.BottleOfInkDeleted
            {
                Id = Id
            });
        }
        
        public string GetInkName() => $"{Manufacturer} - {Colour}";
        
        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.BottleOfInkCreated e:
                    Id = new BottleOfInkId(e.Id);
                    OwnerId = new UserId(e.OwnerId);
                    break;
                case Events.BottleOfInkManufacturerUpdated e:
                    Id = new BottleOfInkId(e.Id);
                    Manufacturer = new BottleOfInkManufacturer(e.Manufacturer);
                    break;
                case Events.BottleOfInkColourUpdated e:
                    Id = new BottleOfInkId(e.Id);
                    Colour = new BottleOfInkColour(e.Colour);
                    break;
                case Events.BottleOfInkDeleted e:
                    Id = new BottleOfInkId(e.Id);
                    break;
            }
        }
        
        protected override void EnsureValidState()
        {
            var valid =
                Id != null &&
                OwnerId != null;

            if (!valid) throw new InvalidEntityStateException(this, $"Post-checks failed");
        }
    }
}