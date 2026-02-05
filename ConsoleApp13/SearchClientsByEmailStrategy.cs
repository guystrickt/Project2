using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class SearchClientsByEmailStrategy : IClientSearchStrategy
    {
        private readonly string _emailDomain;

        public SearchClientsByEmailStrategy(string emailDomain)
        {
            _emailDomain = emailDomain.ToLower();
        }

        public bool IsMatch(Client client)
        {
            return client.Email.ToLower().EndsWith(_emailDomain);
        }
    }
}
