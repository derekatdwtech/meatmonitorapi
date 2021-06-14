using System.Collections.Generic;
using tempaastapi.Models;

namespace tempaastapi.repository
{
    public interface IAlertConfig {
        List<AlertConfigEntity> GetAllAlertConfig(string user_id);
        AlertConfigEntity UpdateAlertConfig (AlertConfig pc, string user_id);

        List<Alert> GetRecentAlerts(string user_id, string startTime, string endTime);
    }
}