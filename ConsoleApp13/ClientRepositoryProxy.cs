using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class ClientRepositoryProxy : IClientRepository
    {
        private readonly IClientRepository _realRepository;
        private Dictionary<int, Client> _cache;
        public ClientRepositoryProxy(IClientRepository realRepository)
        {
            _realRepository = realRepository;
            _cache = new Dictionary<int, Client>();
        }
        public void Add(Client entity)
        {
           _realRepository.Add(entity);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[Proxy] кеш подчищен из-за добавления новой записи");
            _cache.Clear();
        }
        public IEnumerable<Client> GetAll()
        {
          return _realRepository.GetAll();
        }
        public Client GetById(int id)
        { 
            if(_cache.TryGetValue(id, out Client client))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[Proxy] клиент с Id = {id} найден в кэше");
                Console.ResetColor();
                return client;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Proxy] клиент с Id = {id} не найден в кэше. Запрос к ");
            Console.ResetColor();
            var client = _realRepository.GetById(id);
            if (client != null)
            { 
               _cache[id] = client; 
            }
            return client;
        }
        public Task SaveAsync()
        { 
        
        }
    }
}
