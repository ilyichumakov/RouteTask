using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public abstract class AbstractSolver : IRouteSolveMethod
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

        public AbstractSolver(List<List<object>> values, object[] requests, object[] stocks)
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

        protected abstract void processBasis();

        public virtual object BasisResult
        {
            get
            {
                double res = 0;
                              
                for (int row = 0; row < _rows.GetUpperBound(0) + 1; row++)
                {
                    for (int col = 0; col < _rows[row].CellCount; col++)
                    {
                        if ((double)_rows[row].Cells[col].Value == 0.0)
                            continue;
                        else
                            res += (double)_rows[row].Cells[col].Value * (double)_rows[row].Cells[col].Price;
                    }
                }

                return res;
            }
        }

        public DeliveryRow[] Basis
        {
            get
            {
                return this._rows;
            }
        }

        string IRouteSolveMethod.PrintBasis()
        {
            throw new NotImplementedException();
        }

    }
}
