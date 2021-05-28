using System;
using meatmonitorapi.Models;

namespace meatmonitorapi.repository {
    public interface IProbeConfig {
        ProbeConfig GetProbeConfig(string rowKey);
        ProbeConfig UpdateProbeConfig (ProbeConfig pc);
    }
}