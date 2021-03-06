﻿using System;
using System.Collections.Generic;

namespace SimplexMethod
{
    public interface IRouteSolveMethod
    {
        string Title { get; }
        object BasisResult { get; }

        string PrintBasis();

        DeliveryRow[] Rows
        {
            get;
        }

        DeliveryRow[] Basis
        {
            get;
        }

        double[] Clients
        {
            get;
            set;
        }
    }
}
