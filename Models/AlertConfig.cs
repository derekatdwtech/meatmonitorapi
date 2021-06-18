using Microsoft.WindowsAzure.Storage.Table;

namespace tempaastapi.Models
{
    public class AlertConfigEntity : TableEntity
    {

        public AlertConfigEntity() { }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string user_id { get; set; }
        public string probe_id { get; set; }

    }

    public class AlertConfig
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string probe_id { get; set; }
    }

}
