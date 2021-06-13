using System;
using System.Diagnostics;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;

namespace tempaastapi.repository
{
    public class QueueMessageRepository : IQueueMessage
    {

        QueueClient _client;
        IConfiguration _config;
        public QueueMessageRepository(string queueName, IConfiguration config)
        {
            _config = config;

            _client = new QueueClient(_config["ConnectionStrings:StorageAccount"], queueName, new QueueClientOptions {
                MessageEncoding = QueueMessageEncoding.Base64
            });
            _client.CreateIfNotExists();

        }

        public void Post(string message)
        {
            try
            {
                if (_client.Exists())
                {
                    _client.SendMessage(message);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw e;
            }
        }
    }
}