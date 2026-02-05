using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class LegacyClientAdapter : IClientReader
    {
        private readonly LegacyClientService _adapter;

        public LegacyClientAdapter(LegacyClientService adapter)
        {
            _adapter = adapter;
        }

        public IEnumerable<Client> GetAllClients()
        {
            Console.WriteLine("[Adapter] Получаю данные из старой системы и адаптирую их...");
            string legacyData = _adapter.GetClientsAsString();
            var adaptedClients = new List<Client>();

            var clientStrings = legacyData.Split(';');
            foreach (var clientStr in clientStrings)
            {
                var parts = clientStr.Split(',');
                var client = new Client(int.Parse(parts[0]), parts[1], parts[2], DateTime.MinValue);
                adaptedClients.Add(client);
            }

            return adaptedClients;
        }

        public IEnumerable<Client> FindClients(IClientSearchStrategy strategy)
        {
            return Enumerable.Empty<Client>();
        }

        public Client GetClientById(int id)
        {
            return GetAllClients().FirstOrDefault(c => c.Id == id);
        }
    }
}
