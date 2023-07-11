using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.Units
{
    public class GetAllUnitsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public int ComplexId { get; set; }
        public string ComplexName { get; set; }
    }
}
