using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public class ConsoleUI
    {
        private readonly CrmServise _crmService;

        public ConsoleUI(CrmServise crmService)
        {
            _crmService = crmService;
        }

        public void Show()
        {
            Console.WriteLine("---система запущена---");
            Console.WriteLine("клиент добавлен");
        }
        
    }
}
