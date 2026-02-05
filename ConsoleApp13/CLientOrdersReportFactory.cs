using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class ClientOrdersReportFactory : ReportGeneratorFactory
    {
        public override BaseReportGenerator CreateGenerator(IClientReader clientReader, IOrderReader orderReader)
        {
            return new ClientOrdersReport(clientReader, orderReader);
        }
    }
}
