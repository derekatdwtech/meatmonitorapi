using System;
using System.Collections.Generic;
using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tempaastapi.Controllers
{
    [ApiController]
    [Route("temperature")]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;
        private ITemperature _tr;
        public TemperatureController(ILogger<TemperatureController> logger, ITemperature tr)
        {
            _logger = logger;
            _tr = tr;
        }

        [HttpGet("{id}")]
        public TempReading Get(Guid id)
        {
            return _tr.GetLatestTemperature();
           
        }

        [HttpGet]
        public List<TempTableEntity> GetTempReadingBetweenDates(string probeName, string startTime, string endTime) {
            return _tr.GetTemperatureBetweenTime(probeName, startTime, endTime);
        }

        [HttpPost]
        public TempTableEntity UpdateTemperature(TempReading tr) {
            return _tr.UpdateTemperature(tr);
        }
    }
}
