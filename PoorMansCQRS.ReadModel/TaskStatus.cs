﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoorMansCQRS.ReadModel
{
    public enum TaskStatus : int
    {
        Active = 1,
        Closed = 2,
        Inactive = 3
    }
}
