using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class Vogel : AbstractSolver
    {
        public Vogel(List<List<object>> values, object[] requests, object[] stocks) : base(values, requests, stocks)
        {

        }

        protected override void processBasis()
        {
            
        }
    }
}
