
namespace policy_Inquiry_api
{
	public class IrquiMongoDbModels
    {
	}

    public class IrquiDatabaseSettings : IIrquiDatabaseSettings
    {
        public string PolicyInquiryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IIrquiDatabaseSettings
    {
        string PolicyInquiryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
