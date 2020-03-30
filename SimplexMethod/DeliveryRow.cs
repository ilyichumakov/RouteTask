using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class DeliveryRow<T> 
    {

        /// <summary>
        /// Представляет строку в транспортной таблице 
        /// <summary>
        
        private DeliveryCell<T>[] _cells;

        public DeliveryCell<T>[] Cells
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
                return _cells.GetUpperBound(0);
            }
        }

        public DeliveryRow(IEnumerable<T> values)
        {
            List<T> temp = new List<T>();

            foreach(T v in values)
            {
                temp.Add(v);
            }
            int capacity = temp.Count;

            _cells = new DeliveryCell<T>[capacity];

            for(int i = 0; i < capacity; i++)
            {
                _cells[i] = new DeliveryCell<T>(temp[i]);
            }
        }
    }
}
