using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public abstract class BaseReportGenerator
    {
        protected readonly IClientReader _clientReader;
        protected readonly IOrderReader _orderReader;

        protected BaseReportGenerator(IClientReader clientReader, IOrderReader orderReader)
        {
            _clientReader = clientReader;
            _orderReader = orderReader;
        }

        public void Generate()
        {
            GenerateHeader();
            GenerateBody();
            GenerateFooter();
        }

        protected virtual void GenerateHeader()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("        ОТЧЕТ ПО СИСТЕМЕ CRM       ");
            Console.WriteLine("===================================");
        }

        protected abstract void GenerateBody();

        protected virtual void GenerateFooter()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Отчет сгенерирован: {DateTime.Now}");
            Console.WriteLine("===================================");
        }
    }
}
