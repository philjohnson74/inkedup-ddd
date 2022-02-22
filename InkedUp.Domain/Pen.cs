using System;

namespace InkedUp.Domain
{
    public class Pen
    {
        public PenId Id { get; private set; }

        public Pen(PenId id, UserId ownerId)
        {
            if (id == default)
                throw new ArgumentException("Identity must be specified", nameof(id));
            
            Id = id;
            OwnerId = ownerId;
        }

        public void UpdateManufacturer(PenManufacturer manufacturer) => Manufacturer = manufacturer;
        
        public void UpdateModel(PenModel model) => Model = model;

        public void InkUp(PenInkName inkName) => InkName = inkName;

        private UserId OwnerId { get;  }
        public PenManufacturer Manufacturer { get; private set; }
        public PenModel Model { get; private set; }
        public PenInkName InkName { get; private set; }
    }
}