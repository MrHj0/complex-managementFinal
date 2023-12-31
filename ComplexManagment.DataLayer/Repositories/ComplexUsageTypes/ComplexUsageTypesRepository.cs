﻿using ComplexManagment.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.Repositories.ComplexUsageTypes
{
    public interface ComplexUsageTypesRepository
    {
        void Add(ComplexUsageType complexUsageType);
        bool DuplicateComplexUsageType(int complexId,int usageTypeId);
    }
}
