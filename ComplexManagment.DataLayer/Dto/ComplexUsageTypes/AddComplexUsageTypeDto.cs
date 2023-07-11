using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.ComplexUsageTypes
{
    public class AddComplexUsageTypeDto
    {
        [Required]
        public int UsageTypeId { get; set; }
        [Required]
        public int ComplexId { get; set; }
    }
}
