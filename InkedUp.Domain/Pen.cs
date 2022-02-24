using System;
using InkedUp.Framework;

namespace InkedUp.Domain
{
    public class Pen : Entity<PenId>
    {
        public PenId Id { get; private set; }
        public UserId OwnerId { get; private set; }
        public PenManufacturer Manufacturer { get; private set; }
        public PenModel Model { get; private set; }
        public PenInkName InkName { get; private set; }
        public PenState State { get; private set; }

        public Pen(PenId id, UserId ownerId)
        {
            Apply(new Events.PenCreated
            {
                Id = id,
                OwnerId = ownerId
            });
        }

        public void UpdateManufacturer(PenManufacturer manufacturer)
        {
            Apply(new Events.PenManufacturerUpdated
            {
                Id = Id,
                Manufacturer = manufacturer
            });
        }

        public void UpdateModel(PenModel model)
        {
            Apply(new Events.PenModelUpdated
            {
                Id = Id,
                Model = model
            });
        }

        public void InkUp(BottleOfInk bottleOfInk)
        {
            Apply(new Events.PenInkedUp
            {
                Id = Id,
                InkName = PenInkName.FromBottleOfInk(bottleOfInk),
            });
        }
        
        public void Flush()
        {
            Apply(new Events.PenFlushed
            {
                Id = Id
            });
        }
        
        public void Delete()
        {
            Apply(new Events.PenDeleted
            {
                Id = Id
            });
        }
        
        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.PenCreated e:
                    Id = new PenId(e.Id);
                    OwnerId = new UserId(e.OwnerId);
                    break;
                case Events.PenManufacturerUpdated e:
                    Id = new PenId(e.Id);
                    Manufacturer = new PenManufacturer(e.Manufacturer);
                    break;
                case Events.PenModelUpdated e:
                    Id = new PenId(e.Id);
                    Model = new PenModel(e.Model);
                    break;
                case Events.PenInkedUp e:
                    Id = new PenId(e.Id);
                    InkName = new PenInkName(e.InkName);
                    State = PenState.InkedUp;
                    break;
                case Events.PenFlushed e:
                    Id = new PenId(e.Id);
                    InkName = null;
                    State = PenState.Empty;
                    break;
                case Events.PenDeleted e:
                    Id = new PenId(e.Id);
                    break;
            }
        }
        
        protected override void EnsureValidState()
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

        public enum PenState
        {
            Empty,
            InkedUp
        }
    }
}