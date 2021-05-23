using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace meatmonitorapi.Models
{
    public class TempReading : TableEntity {

        public TempReading() {
            RowKey = time.ToString();
        }
        public string name {get; set;}
        public DateTime time { get; set;}
        public Temperature temperature {get; set;}
    }

    public class Temperature
    {
        public float f {get; set;}
        public float c {get; set;}
    }
}