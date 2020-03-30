using System;
using System.Collections.Generic;

namespace SimplexMethod
{
    public interface IRouteSolveMethod<T>
    {
        T Basis { get; }

        string PrintBasis();


    }
}
