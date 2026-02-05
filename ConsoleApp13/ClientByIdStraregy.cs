using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class ClientByIdStrategy : IClientSearchStrategy
    {
        private readonly int _id;

        public ClientByIdStrategy(int id)
        {
            _id = id;
        }

        public bool IsMatch(Client client)
        {
            return client.Id == _id;
        }
    }
}
