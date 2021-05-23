using System;
using meatmonitorapi.Models;

namespace meatmonitorapi.repository {
    public interface IProbeConfig {
        ProbeConfig GetProbeConfig(Guid id);
        ProbeConfig UpdateProbeConfig (ProbeConfig pc);
    }
}