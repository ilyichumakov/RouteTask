using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class NorthWest : IRouteSolveMethod
    {
        private DeliveryRow[] _rows;

        public object[] Clients
        {
            /// <summary>
            /// Запросы от клиентов 
            /// <summary>

            get;
            set;
        }

        public DeliveryRow[] Rows
        {
            get
            {
                return this._rows;
            }
        }        

        public NorthWest(List<List<object>> values, object[] requests, object[] stocks)
        {
            List<object> temp = new List<object>();
            _rows = new DeliveryRow[values.Count];
            Clients = new object[requests.GetUpperBound(0) + 1];

            int i = 0;

            foreach (List<object> row in values)
            {
                _rows[i] = new DeliveryRow(row);
                _rows[i].Stock = stocks[i];                
                i++;
            }

            i = 0;

            foreach (object r in requests)
            {
                Clients[i] = r;
                i++;
            }

            processBasis();
        }

        private void processBasis()
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

        public object BasisResult => throw new NotImplementedException();

        public DeliveryRow[] Basis => throw new NotImplementedException();

        string IRouteSolveMethod.PrintBasis()
        {
            throw new NotImplementedException();
        }

    }
}
