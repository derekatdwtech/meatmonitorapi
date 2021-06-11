using tempaastapi.Models;
using tempaastapi.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tempaastapi.attributes;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Http;

namespace tempaastapi.Controllers
{
    [ApiController]
    [Route("api/message")]
    [ApiKey]
    public class QueueMessageController : ControllerBase
    {
        private readonly ILogger<QueueMessageController> _logger;
        private IQueueMessage _qmr;
        private IConfiguration _config;
        public QueueMessageController(ILogger<QueueMessageController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpPost]
        public ActionResult Post([FromBody] string message, string queue)
        {
            try
            {
                _qmr = new QueueMessageRepository(queue, _config);
                _qmr.Post(message);
                return Ok("Successfully posted message");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
