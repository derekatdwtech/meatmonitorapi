using System;
using System.Collections.Generic;
using meatmonitorapi.Models;

namespace meatmonitorapi.repository {
    public interface IAlertConfig {
        List<AlertConfigEntity> GetAllAlertConfig(string partitionKey);
        AlertConfigEntity UpdateAlertConfig (AlertConfig pc);
    }
}