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
        
        private DeliveryCell<object>[] _cells;

        public DeliveryCell<object>[] Cells
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

        public object Stock
        {
            /// <summary>
            /// Остаток на складе 
            /// <summary>
            
            get;
            set;
        }

        public DeliveryRow(IEnumerable<object> values)
        {
            List<object> temp = new List<object>();

            foreach(object v in values)
            {
                temp.Add(v);
            }
            int capacity = temp.Count;

            _cells = new DeliveryCell<object>[capacity];

            for(int i = 0; i < capacity; i++)
            {
                _cells[i] = new DeliveryCell<object>(temp[i]);
                _cells[i].Value = 0.0;
            }
        }
    }
}
