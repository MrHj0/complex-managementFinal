using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Dto.UsageTypes
{
    public class AddUsageTypeDto
    {
        [Required,MaxLength(50)]
        public string Title { get; set; }
    }
}
