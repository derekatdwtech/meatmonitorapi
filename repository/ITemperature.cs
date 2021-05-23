using System;
using meatmonitorapi.Models;

namespace meatmonitorapi.repository {
    public interface ITemperature {
        TempReading GetLatestTemperature();
        TempReading UpdateTemperature (TempReading tr);
    }
}