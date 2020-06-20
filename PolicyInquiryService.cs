using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace policy_Inquiry_api
{
	public class PolicyInquiryService
	{
        private readonly IMongoCollection<PolicyInquiry> _policyInquiry;
        private readonly ILogger<PolicyInquiryService> _logger;

        public PolicyInquiryService(IIrquiDatabaseSettings settings, ILogger<PolicyInquiryService> logger)
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("ConnectionString"));
            var database = client.GetDatabase(System.Environment.GetEnvironmentVariable("DatabaseName"));

            _policyInquiry = database.GetCollection<PolicyInquiry>(System.Environment.GetEnvironmentVariable("PolicyInquiryCollectionName"));

            _logger = logger;
            _logger.LogInformation("ConnectionString" + System.Environment.GetEnvironmentVariable("ConnectionString"));
            _logger.LogInformation("ConnectionString" + System.Environment.GetEnvironmentVariable("DatabaseName"));
            _logger.LogInformation("ConnectionString" + System.Environment.GetEnvironmentVariable("PolicyInquiryCollectionName"));
        }

        public List<PolicyInquiry> Get() =>
          _policyInquiry.Find(policyInquiry => true).ToList();

        public PolicyInquiry Get(string policyNumber) =>
           _policyInquiry.Find<PolicyInquiry>(policyInquiry => policyInquiry.PolicyNumber == policyNumber).FirstOrDefault();

        public PolicyInquiry Create(PolicyInquiry policyInquiry)
        {
            _policyInquiry.InsertOne(policyInquiry);
            return policyInquiry;
        }
    }
}
