using System;
using RabbitMQ.Client;

namespace Learners.Services
{
    public class QueueHandler : IDisposable 
    {
        private static ConnectionFactory _factory;
        private static IConnection _connection;
        public IModel model;
        private const string ExchangeNme = "KnowledgeExchange";
        public QueueHandler () {
            _factory = new ConnectionFactory {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                DispatchConsumersAsync = true
            };
            _connection = _factory.CreateConnection();
            model = _connection.CreateModel();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}