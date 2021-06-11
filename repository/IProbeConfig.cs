using tempaastapi.Models;

namespace tempaastapi.repository
{
    public interface IProbeConfig {
        ProbeConfig GetProbeConfig(string partitionKey, string rowKey);
        ProbeConfig UpdateProbeConfig (ProbeConfig pc);
    }
}