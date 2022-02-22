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
            State = PenState.Empty;
        }

        public void UpdateManufacturer(PenManufacturer manufacturer)
        {
            Manufacturer = manufacturer;
            EnsureValidState();
        }

        public void UpdateModel(PenModel model)
        {
            Model = model;
            EnsureValidState();
        }

        public void InkUp(BottleOfInk bottleOfInk)
        {
            InkName = PenInkName.FromBottleOfInk(bottleOfInk);
            State = PenState.InkedUp;
            EnsureValidState();
        }
        
        protected void EnsureValidState()
        {
            var valid =
                Id != null &&
                OwnerId != null &&
                (State switch
                {
                    PenState.Empty =>
                        InkName == null,
                    PenState.InkedUp =>
                        Manufacturer != null
                        && Model != null
                        && InkName != null
                });

            if (!valid) throw new InvalidEntityStateException(this, $"Post-checks failed in state {State}");
        }

        private UserId OwnerId { get;  }
        public PenManufacturer Manufacturer { get; private set; }
        public PenModel Model { get; private set; }
        public PenInkName InkName { get; private set; }
        public PenState State { get; private set; }

        public enum PenState
        {
            Empty,
            InkedUp
        }
    }
}