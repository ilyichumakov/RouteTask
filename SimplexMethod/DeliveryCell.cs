using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class DeliveryCell<T>
    {
        /// <summary>
        /// Представляет ячейку в транспортной таблице 
        /// <summary>
        
        public bool Visited
        {
            /// <summary>
            /// Возвращает true, если ячётка была использована в составлении опорного плана 
            /// <summary>
            
            get;
            set;
        }

        public T Value
        {
            get;
            set;
        }

        public DeliveryCell(T val)
        {
            Value = val;
            Visited = false;
        }
    }
}
