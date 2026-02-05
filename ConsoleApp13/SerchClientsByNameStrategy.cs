using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class SerchClientsByNameStrategy : IClientSerchStrategy
    {
        private readonly string _name;
        public SerchClientsByNameStrategy(string name)
        {
            _name = name;
        }
        public bool IsMatch(Client client)
        {
            return client.Name.ToLower().Contains(_name);
        }
    }

}
