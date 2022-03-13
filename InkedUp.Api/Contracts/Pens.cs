using System;

namespace InkedUp.Api.Contracts
{
    public static class Pens
    {
        public static class V1
        {
            public class Create
            {
                public Guid Id { get; set; }
                public Guid OwnerId { get; set; }
            }

            public class UpdateManufacturer
            {
                public Guid Id { get; set; }
                public string Manufacturer { get; set; }
            }

            public class UpdateModel
            {
                public Guid Id { get; set; }
                public string Model { get; set; }
            }

            public class InkUp
            {
                public Guid Id { get; set; }
                public string InkName { get; set; }
            }
            
            public class Flush
            {
                public Guid Id { get; set; }
            }
            
            public class Delete
            {
                public Guid Id { get; set; }
            }
        }
    }
}