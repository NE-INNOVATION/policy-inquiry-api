using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace policy_Inquiry_api
{
	public class PolicyInquiryService
	{
        private readonly IMongoCollection<PolicyInquiry> _policyInquiry;

        public PolicyInquiryService(IIrquiDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _policyInquiry = database.GetCollection<PolicyInquiry>(settings.PolicyInquiryCollectionName);
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
