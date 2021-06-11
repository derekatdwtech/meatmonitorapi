using Microsoft.WindowsAzure.Storage.Table;

namespace tempaastapi.Models
{
    public class ProbeConfig : TableEntity {

        public ProbeConfig() { }
        public int readingIntervalInSeconds {get; set;}
        public int tempThresholdInCelcius {get;set;}
        public string userId {get; set;}
        public string nickname {get; set;}
       
    }
}