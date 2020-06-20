﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace policy_Inquiry_api
{
	public class PolicyInquiryService
	{
        private readonly IMongoCollection<PolicyInquiry> _policyInquiry;
        private readonly ILogger<PolicyInquiryService> _logger;

        private readonly IMongoDatabase _database;

        public PolicyInquiryService(IIrquiDatabaseSettings settings, ILogger<PolicyInquiryService> logger)
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("ConnectionString"));
            _database = client.GetDatabase(System.Environment.GetEnvironmentVariable("DatabaseName"));

            _policyInquiry = _database.GetCollection<PolicyInquiry>(System.Environment.GetEnvironmentVariable("PolicyInquiryCollectionName"));

            _logger = logger;
            _logger.LogInformation("ConnectionString" + System.Environment.GetEnvironmentVariable("ConnectionString"));
            _logger.LogInformation("ConnectionString" + System.Environment.GetEnvironmentVariable("DatabaseName"));
            _logger.LogInformation("ConnectionString" + System.Environment.GetEnvironmentVariable("PolicyInquiryCollectionName"));
        }

        private string GetData(string collectionName, string policyNumber)
        {
            var collection = _database.GetCollection<BsonDocument>(collectionName);

            var builders = Builders<BsonDocument>.Filter.Eq("policyNumber", policyNumber);
            var result = collection.Find(builders).FirstOrDefault();

            RemoveIdObject(result);
            return result?.ToJson();
    
        }

        private static void RemoveIdObject(BsonDocument response)
        {
            BsonElement bsonElement;
            if (response.TryGetElement("_id", out bsonElement))
                response.RemoveElement(bsonElement);
        }

        public List<PolicyInquiry> Get() =>
          _policyInquiry.Find(policyInquiry => true).ToList();

        public string Get(string policyNumber) =>
           GetData(System.Environment.GetEnvironmentVariable("PolicyInquiryCollectionName"), policyNumber);

        public PolicyInquiry Create(PolicyInquiry policyInquiry)
        {
            _policyInquiry.InsertOne(policyInquiry);
            return policyInquiry;
        }
    }
}
