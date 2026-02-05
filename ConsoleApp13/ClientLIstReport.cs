using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class ClientListReport : BaseReportGenerator
    {
        public ClientListReport(IClientReader clientReader, IOrderReader orderReader) : base(clientReader, orderReader) { }

        protected override void GenerateBody()
        {
            Console.WriteLine("\n--- Список всех клиентов ---");
            var clients = _clientReader.GetAllClients();
            foreach (var client in clients)
            {
                Console.WriteLine($"ID: {client.Id}, Имя: {client.Name}, Email: {client.Email}");
            }
        }
    }
}
