using Microsoft.WindowsAzure.Storage.Table;

namespace tempaastapi.Models
{
    public class TempTableEntity : TableEntity
    {

        public TempTableEntity()
        {

        }

        public string user_id { get; set; }
        public string probe_id {get;set;}
        public string time { get; set; }
        public string temp_c { get; set; }
        public string temp_f { get; set; }
    }

    public class TempReading
    {
        public string probe_id { get; set; }
        public string user_id {get; set; }
        public string time { get; set; }
        public Temperature temperature { get; set; }
    }

    public class Temperature
    {
        public decimal f { get; set; }
        public decimal c { get; set; }
    }
}