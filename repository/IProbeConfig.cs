using System.Collections.Generic;
using tempaastapi.Models;

namespace tempaastapi.repository
{
    public interface IProbeConfig {
        ProbeConfig GetProbeConfig(string partitionKey, string rowKey);
        List<ProbeConfig> GetAllProbeConfigs (string userId);
        ProbeConfig UpdateProbeConfig (ProbeConfig pc);
    }
}