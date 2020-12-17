using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace policy_Inquiry_api
{
    [BsonIgnoreExtraElements]
    public class PolicyInquiry
	{        
        [BsonElement("policyNumber")]
        public string PolicyNumber { get; set; }

        [BsonElement("drivers")]
        public List<Driver> Drivers { get; set; }

        [BsonElement("vehicles")]
        public List<Vehicle> Vehicles { get; set; }

        [BsonElement("coverages")]
        public Coverages Coverages { get; set; }

        [BsonElement("customer")]
        public Customer Customer { get; set; }
    }

    public class Coverages
    {
        [BsonElement("bi")]
        public bool Bi { get; set; }

        [BsonElement("pd")]
        public bool Pd { get; set; }
        [BsonElement("med")]
        public bool Med { get; set; }

        [BsonElement("comp")]
        public bool Comp { get; set; }
        [BsonElement("col")]
        public bool Col { get; set; }
        [BsonElement("premium")]
        public string Premium { get; set; }
    }

    public class Customer
    {
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("dob")]
        public string Dob { get; set; }
        [BsonElement("stAddress")]
        public string StreetAddress { get; set; }
        [BsonElement("apt")]
        public string Apt { get; set; }
        [BsonElement("zip")]
        public string Zip { get; set; }
    }

    public class InquiryRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Driver
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("maritalStatus")]
        public string MaritalStatus { get; set; }
        [BsonElement("licenseNum")]
        public string LicensedNum { get; set; }


        [BsonElement("employmentStatus")]
        public string EmploymentStatus { get; set; }
        [BsonElement("currentIns")]
        public string CurrentIns { get; set; }
        [BsonElement("education")]
        public string Education { get; set; }
        [BsonElement("id")]
        public string Id { get; set; }
    }

    public class Vehicle
    {
        [BsonElement("year")]
        public string Year { get; set; }
        [BsonElement("make")]
        public Int32 Make { get; set; }
        [BsonElement("model")]
        public Int32 Model { get; set; }
        [BsonElement("vehicleOwned")]
        public string VehicleOwned { get; set; }
        [BsonElement("vehicleUsage")]
        public string VehicleUsage { get; set; }
        [BsonElement("vehiclePrimaryUse")]

        public string VehiclePrimaryUse { get; set; }
        [BsonElement("annualMileage")]
        public string AnnualMileage { get; set; }

        [BsonElement("daysDriven")]

        public string DaysDriven { get; set; }
        [BsonElement("milesDriven")]
        public string MilesDriven { get; set; }

        [BsonElement("id")]
        public string Id { get; set; }
    }
   
}
