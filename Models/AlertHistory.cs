using Microsoft.WindowsAzure.Storage.Table;

namespace tempaastapi.Models {
    public class AlertHistory : TableEntity {
        public string recipients {get; set;}
        public string details {get; set;}
        public string sendTime {get; set;}
        
    }
}