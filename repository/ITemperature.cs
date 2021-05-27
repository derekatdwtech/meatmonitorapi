using System;
using System.Collections.Generic;
using meatmonitorapi.Models;

namespace meatmonitorapi.repository {
    public interface ITemperature {
        TempReading GetLatestTemperature();
        TempTableEntity UpdateTemperature (TempReading tr);
        List<TempTableEntity> GetTemperatureBetweenTime(string startTime, string endTime);
    }
}