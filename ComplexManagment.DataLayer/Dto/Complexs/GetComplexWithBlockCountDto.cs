using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Complexs
{
    public class GetComplexWithBlockCountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegisteredUnits { get; set; }
        public int RemainingUnits { get; set; }
        public int BlocksCount { get; set; }
    }
}
