using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace policy_Inquiry_api
{
    [BsonIgnoreExtraElements]
    public class PolicyInquiry
	{        
        [BsonElement("PolicyNumber")]
        public string PolicyNumber { get; set; }

        [BsonElement("Drivers")]
        public List<Driver> Drivers { get; set; }

        [BsonElement("Vehicles")]
        public List<Vehicle> Vehicles { get; set; }

        [BsonElement("Coverges")]
        public Coverages Coverages { get; set; }

        [BsonElement("Customer")]
        public Customer Customer { get; set; }
    }

    public class Coverages
    {
        [BsonElement("Bi")]
        public bool Bi { get; set; }

        [BsonElement("Pd")]
        public bool Pd { get; set; }
        [BsonElement("Med")]
        public bool Med { get; set; }

        [BsonElement("Comp")]
        public bool Comp { get; set; }
        [BsonElement("Col")]
        public bool Col { get; set; }
        [BsonElement("Premium")]
        public string Premium { get; set; }
    }

    public class Customer
    {
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("Dob")]
        public string Dob { get; set; }
        [BsonElement("StreetAddress")]
        public string StreetAddress { get; set; }
        [BsonElement("Apt")]
        public string Apt { get; set; }
        [BsonElement("Zip")]
        public string Zip { get; set; }
    }

    public class Driver
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Gender")]
        public string Gender { get; set; }
        [BsonElement("Dob")]
        public string Dob { get; set; }
        [BsonElement("MaritalStatus")]
        public string MaritalStatus { get; set; }
        [BsonElement("LicensedAge")]
        public string LicensedAge { get; set; }
    }

    public class Vehicle
    {
        [BsonElement("Year")]
        public string Year { get; set; }
        [BsonElement("Make")]
        public string Make { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("VehicleOwned")]
        public string VehicleOwned { get; set; }
        [BsonElement("VehicleUsage")]
        public string VehicleUsage { get; set; }
        [BsonElement("VehiclePrimaryUse")]

        public string VehiclePrimaryUse { get; set; }
        [BsonElement("AnnualMileage")]
        public string AnnualMileage { get; set; }
    }
   
}
