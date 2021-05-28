using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace meatmonitorapi.Models {
    public class ProbeConfig : TableEntity {

        public ProbeConfig() {
            PartitionKey = "probeconfig";
        }
        public int readingIntervalInSeconds {get; set;}
        public int tempThresholdInCelcius {get;set;}
       
    }
}