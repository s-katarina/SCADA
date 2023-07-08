using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class InputTableRecord
    {
        public string TagName { get; set; }
        public bool IsScanning { get; set; }
        public string IOAddress { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
    }
}
