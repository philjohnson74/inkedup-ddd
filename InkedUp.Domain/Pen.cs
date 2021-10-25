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
            _ownerId = ownerId;
        }

        public void UpdateManufacturer(string manufacturer) => _manufacturer = manufacturer;
        
        public void UpdateModel(string model) => _model = model;
        
        public void UpdatePhoto(string photo) => _photo = photo;
        
        public void InkUp(Ink ink) => _ink = ink;

        private UserId _ownerId;
        private string _manufacturer;
        private string _model;
        private string _photo;
        private Ink _ink;
    }
}