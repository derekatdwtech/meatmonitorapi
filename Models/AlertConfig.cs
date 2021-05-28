using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace meatmonitorapi.Models {
    public class AlertConfigEntity : TableEntity {

        public AlertConfigEntity() {
            PartitionKey = "alertconfig";
        }

        public string firstName {get;set;}
        public string lastName {get;set;}
        public string phoneNumber {get;set;}
       
    }

    public class AlertConfig {
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string phoneNumber {get;set;}
        public string id {get;set;}
    }
}
