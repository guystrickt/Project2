using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public abstract class ReportGeneratorFactory
    {
        public abstract BaseReportGenerator CreateGenerator(IClientReader clientReader, IOrderReader orderReader);
    }
}
