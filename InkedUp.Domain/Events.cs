using System;

namespace InkedUp.Domain
{
    public static class Events
    {
        public class PenCreated
        {
            public Guid Id { get; set; }
            public Guid OwnerId { get; set; }
        }

        public class BottleOfInkCreated
        {
            public Guid Id { get; set; }
            public Guid OwnerId { get; set; }
        }

        public class PenManufacturerUpdated
        {
            public Guid Id { get; set; }
            public string Manufacturer { get; set; }
        }

        public class PenModelUpdated
        {
            public Guid Id { get; set; }
            public string Model { get; set; }
        }

        public class BottleOfInkManufacturerUpdated
        {
            public Guid Id { get; set; }
            public string Manufacturer { get; set; }
        }

        public class BottleOfInkColourUpdated
        {
            public Guid Id { get; set; }
            public string Colour { get; set; }
        }

        public class PenInkedUp
        {
            public Guid Id { get; set; }
            public string InkName { get; set; }
        }
        
        public class PenFlushed
        {
            public Guid Id { get; set; }
        }
        
        public class InkDeleted
        {
            public Guid Id { get; set; }
        }
        
        public class PenDeleted
        {
            public Guid Id { get; set; }
        }
                
        public class BottleOfInkDeleted
        {
            public Guid Id { get; set; }
        }
    }
}