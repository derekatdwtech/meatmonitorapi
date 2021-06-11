using System;
using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using tempaastapi.attributes;

namespace tempaastapi.Controllers
{
    [ApiController]
    [Route("api/sas")]
    [ApiKey]
    public class SasController : ControllerBase
    {
        private readonly ILogger<SasController> _logger;
        private ISas _Sas;
        public SasController(ILogger<SasController> logger, ISas Sas)
        {
            _logger = logger;
            _Sas = Sas;
        }

        
    }
}
