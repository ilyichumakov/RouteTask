using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class LowCost : AbstractSolver
    {
        public LowCost(List<List<object>> values, object[] requests, object[] stocks) : base(values, requests, stocks)
        {

        }

        protected override void processBasis()
        {
            while(!isFinished())
            {
                markCellByValue(getMinCost());
            }
        }

        protected double getMinCost()
        {
            double min = -1;
            foreach(DeliveryRow row in _rows)
            {
                foreach(DeliveryCell cell in row.Cells)
                {
                    if ((cell.Price < min || min == -1) && !cell.Visited)
                        min = cell.Price;
                }
            }

            return min;
        }

        protected void markCellByValue(double val)
        {
            int i = 0;
            foreach (DeliveryRow row in _rows)
            {
                int j = 0;
                foreach (DeliveryCell cell in row.Cells)
                {                    
                    if (cell.Price == val && !cell.Visited)
                    {
                        _rows[i].Cells[j].Visited = true;
                        if(row.Stock >= Clients[j])
                        {
                            _rows[i].Cells[j].Value += Clients[j];
                            row.Stock -= Clients[j];
                            Clients[j] = 0;                            
                            markColumn(j);
                        }
                        else
                        {
                            _rows[i].Cells[j].Value += row.Stock;
                            Clients[j] -= row.Stock;
                            row.Stock = 0;                             
                            markRow(i);
                        }
                        return;
                    }
                    j++;   
                }
                i++;
            }
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
                if(request > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
