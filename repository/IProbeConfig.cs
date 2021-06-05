using System;
using tempaastapi.Models;

namespace tempaastapi.repository {
    public interface IProbeConfig {
        ProbeConfig GetProbeConfig(string rowKey);
        ProbeConfig UpdateProbeConfig (ProbeConfig pc);
    }
}