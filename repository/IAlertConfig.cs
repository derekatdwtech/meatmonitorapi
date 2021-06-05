using System;
using System.Collections.Generic;
using tempaastapi.Models;

namespace tempaastapi.repository {
    public interface IAlertConfig {
        List<AlertConfigEntity> GetAllAlertConfig(string partitionKey);
        AlertConfigEntity UpdateAlertConfig (AlertConfig pc);
    }
}