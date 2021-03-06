﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public abstract class AbstractSolver : IRouteSolveMethod
    {
        protected DeliveryRow[] _rows;

        public virtual string Title
        {
            get { return "Title"; }
        }

        public double[] Clients
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
            Clients = new double[requests.GetUpperBound(0) + 1];

            int i = 0;

            foreach (List<object> row in values)
            {
                _rows[i] = new DeliveryRow(row);
                _rows[i].Stock = (double)stocks[i];                
                i++;
            }

            i = 0;

            foreach (object r in requests)
            {
                Clients[i] = (double)r;
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
                        if (_rows[row].Cells[col].Value == 0.0)
                            continue;
                        else
                            res += _rows[row].Cells[col].Value * _rows[row].Cells[col].Price;
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
                
        protected void markColumn(int index)
        {
            int i = 0;
            foreach (DeliveryRow row in _rows)
            {
                int j = 0;
                foreach (DeliveryCell cell in row.Cells)
                {
                    if (j == index)
                        _rows[i].Cells[j].Visited = true;
                    j++;
                }
                i++;
            }
        }

        protected void markRow(int index)
        {
            int j = 0;
            foreach (DeliveryCell cell in _rows[index].Cells)
            {
                _rows[index].Cells[j].Visited = true;
                j++;
            }
        }

        protected bool isFinished()
        {
            foreach (double request in Clients)
            {
                if (request > 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
