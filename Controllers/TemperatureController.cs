using System;
using meatmonitorapi.Models;
using meatmonitorapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace meatmonitorapi.Controllers
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

        [HttpPost]
        public TempReading UpdateTemperature(TempReading tr) {
            return _tr.UpdateTemperature(tr);
        }
    }
}
