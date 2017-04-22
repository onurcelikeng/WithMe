using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;

namespace WithMe.Service.Storage
{
    public class ConnectionString
    {
        private string account = CloudConfigurationManager.GetSetting("StorageAccountName");
        private string key = CloudConfigurationManager.GetSetting("StorageAccountKey");


        public CloudStorageAccount GetConnectionString()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}