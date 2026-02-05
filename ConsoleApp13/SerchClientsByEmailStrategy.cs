using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp13
{
    public class SerchClientsByEmailStrategy : IClientSerchStrategy
    {
        private readonly string _emailDomain;
        public SerchClientsByEmailStrategy(string email)
        {
            _emailDomain = email;
        }
        public bool IsMatch(Client client)
        {
            return client.Name.ToLower().Contains(_emailDomain);
        }
    }
}
