using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class DeliveryRow
    {

        /// <summary>
        /// Представляет строку в транспортной таблице 
        /// <summary>
        
        private DeliveryCell[] _cells;

        public DeliveryCell[] Cells
        {
            get
            {
                return this._cells;
            }
        }

        public int CellCount
        {
            get
            {
                return _cells.GetUpperBound(0) + 1;
            }
        }

        public double Stock
        {
            /// <summary>
            /// Остаток на складе 
            /// <summary>
            
            get;
            set;
        }

        public DeliveryRow(IEnumerable<object> values)
        {
            List<double> temp = new List<double>();

            foreach(object v in values)
            {
                temp.Add((double)v);
            }
            int capacity = temp.Count;

            _cells = new DeliveryCell[capacity];

            for(int i = 0; i < capacity; i++)
            {
                _cells[i] = new DeliveryCell(temp[i]);
                _cells[i].Value = 0.0;
            }
        }
    }
}
