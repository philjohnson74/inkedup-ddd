using System;

namespace InkedUp.Domain
{
    public class BottleOfInk
    {
        public BottleOfInkId Id { get; private set; }

        public BottleOfInk(BottleOfInkId id, UserId ownerId)
        {
            Id = id;
            _ownerId = ownerId;
        }

        public void UpdateManufacturer(string manufacturer) => _manufacturer = manufacturer;
        
        public void UpdateColour(string colour) => _colour = colour;
        
        public void UpdatePhoto(string photo) => _photo = photo;
        
        public string GetInkName() => $"{_manufacturer} - {_colour}";

        private UserId _ownerId;
        private string _manufacturer;
        private string _colour;
        private string _photo;
    }
}