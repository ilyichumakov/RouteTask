using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class Vogel : AbstractSolver
    {
        private double max = 0;

        public Vogel(List<List<object>> values, object[] requests, object[] stocks) : base(values, requests, stocks)
        {

        }

        protected override void processBasis()
        {
            while (!isFinished())
            {
                processStep();
            }
        }

        protected void processStep()
        {
            List<double> minRows = new List<double>();
            List<double> minCols = new List<double>();

            int i = 0;
            int limit = _rows[0].CellCount;

            foreach (DeliveryRow row in _rows)
            {
                minRows.Add(getRowDiff(i));
                i++;
            }

            for (int j = 0; j < limit; j++)
            {
                minCols.Add(getColumnDiff(j));
            }

            double localMax = minRows.Max();
            double potential = minCols.Max();
            if(potential > localMax)
            {
                int row = getMinInColumn(minCols.IndexOf(potential));
                markCell(row, minCols.IndexOf(potential));
            }
            else
            {
                int col = getMinInRow(minRows.IndexOf(localMax));
                markCell(minRows.IndexOf(localMax), col);
            }
        }

        protected int getMinInRow(int index)
        {
            double min = -1;
            int i = 0;
            int res = 0;
            foreach (DeliveryCell cell in _rows[index].Cells)
            {
                if ((cell.Price < min || min == -1) && !cell.Visited)
                {
                    min = cell.Price;
                    res = i;
                }               
                i++;
            }

            if (min == -1)
                return 0;

            return res;
        }

        protected int getMinInColumn(int index)
        {
            double min = -1;
            int res = 0;
            int i = 0;
            foreach (DeliveryRow row in _rows)
            {         
                if ((row.Cells[index].Price < min || min == -1) && !row.Cells[index].Visited)
                {
                    min = row.Cells[index].Price;
                    res = i;
                }
                
                i++;              
            }

            if (min == -1)
                return 0;

            return res;
        }

        protected double getColumnDiff(int index)
        {
            int i = 0;
            List<double> tariffs = new List<double>();
            foreach(DeliveryRow row in _rows)
            {
                if (!_rows[i].Cells[index].Visited)
                    tariffs.Add(_rows[i].Cells[index].Price);
                i++;
            }

            if (tariffs.Count == 0)
                tariffs.Add(0.0);
            
            if (tariffs.Count == 1)
                tariffs.Add(0.0);     

            return minDiff(tariffs);
        }
         
        protected double getRowDiff(int index)
        {
            int i = 0;
            List<double> tariffs = new List<double>();
       
            foreach(DeliveryCell cell in _rows[index].Cells)
            {
                if(!cell.Visited) tariffs.Add(_rows[index].Cells[i].Price);
                i++;
            }

            if (tariffs.Count == 0)
                tariffs.Add(0.0);

            if (tariffs.Count == 1)
                tariffs.Add(0.0);

            return minDiff(tariffs);
        }

        protected double minDiff(List<double> tariffs)
        {
            double min1, min2;

            min1 = tariffs.Min();
            tariffs.Remove(min1);
            min2 = tariffs.Min();

            return min2 - min1; //min2 >= min1 => min2 - min1 >= 0
        }

        protected void markCell(int i, int j)
        {          
            _rows[i].Cells[j].Visited = true;
            if (_rows[i].Stock >= Clients[j])
            {
                _rows[i].Cells[j].Value += Clients[j];
                _rows[i].Stock -= Clients[j];
                Clients[j] = 0;
                markColumn(j);
            }
            else
            {
                _rows[i].Cells[j].Value += _rows[i].Stock;
                Clients[j] -= _rows[i].Stock;
                _rows[i].Stock = 0;
                markRow(i);
            }
            return;                    
        }
    }
}
