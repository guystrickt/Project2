using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class ClientListReportFactory : ReportGeneratorFactory
    {
        public override BaseReportGenerator CreateGenerator(IClientReader clientReader, IOrderReader orderReader)
        {
            return new ClientListReport(clientReader, orderReader);
        }
    }
}
