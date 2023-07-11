using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Entities
{
    public class BlockUsageType
    {
        public int BlockId { get; set; }
        public int UsagetypeId { get; set; }

        public Blook Block { get; set; }
        public UsageType UsageType { get; set; }
    }
}
