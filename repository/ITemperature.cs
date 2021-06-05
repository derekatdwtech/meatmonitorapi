using System;
using System.Collections.Generic;
using tempaastapi.Models;

namespace tempaastapi.repository {
    public interface ITemperature {
        TempReading GetLatestTemperature();
        TempTableEntity UpdateTemperature (TempReading tr);
        List<TempTableEntity> GetTemperatureBetweenTime(string probeName, string startTime, string endTime);
    }
}