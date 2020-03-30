using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class LowCost : AbstractSolver
    {
        private DeliveryRow[] _rows;

        public LowCost(List<List<object>> values, object[] requests, object[] stocks) : base(values, requests, stocks)
        {

        }

        protected override void processBasis()
        {
            int row = 0;
            int col = 0;

            foreach(object request in Clients)
            {
                //_rows[row].Cells[col].Value = request;                
                double target = (double)request;

                while (target > 0) 
                {
                    if((double)_rows[row].Stock >= target)
                    {
                        _rows[row].Cells[col].Value = target;
                        _rows[row].Cells[col].Visited = true;
                        _rows[row].Stock = (double)_rows[row].Stock - target;
                        target = 0;
                    }
                    else
                    {
                        _rows[row].Cells[col].Value = (double)_rows[row].Cells[col].Value + (double)_rows[row].Stock;
                        _rows[row].Cells[col].Visited = true;
                        target -= (double)_rows[row].Stock;
                        _rows[row].Stock = 0;
                        row++;
                    }                    
                }

                col++;
            }
        }

    }
}
