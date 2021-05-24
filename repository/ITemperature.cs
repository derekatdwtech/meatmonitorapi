using System;
using meatmonitorapi.Models;

namespace meatmonitorapi.repository {
    public interface ITemperature {
        TempReading GetLatestTemperature();
        TempTableEntity UpdateTemperature (TempReading tr);
    }
}