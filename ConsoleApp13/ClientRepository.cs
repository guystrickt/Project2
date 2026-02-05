using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(IStorage<Client> storage) : base(storage)
        {
            if (_items.Any())
            {
                _nextId = _items.Cast<Client>().Max(c => c.Id) + 1;
            }
        }
        public override Client GetById(int id) => _items.FirstOrDefault(c => c.Id == id);
    }
}
