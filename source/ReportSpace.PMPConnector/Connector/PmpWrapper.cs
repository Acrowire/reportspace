using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSpace.PMPConnector.Connector
{
    public class PmpWrapper<T>
    {
        public List<T> Resources { get; set; }

        public List<string> Messages { get; set; }

        public bool Success { get; set; }

        public string Meta { get; set; }

        public string Links { get; set; }

        public string Linked { get; set; }


    }
}
