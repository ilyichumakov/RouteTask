using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethod
{
    public class RouteAlgorythms
    {
        private double[,] _matrix;
        private double[,] _dataMatrix;
        private double[] _target; // function like z = c0 + c1x1 + c2x2 ... just put here the c0, c1 and etc.
        private int basisCount;
        private int freeCount;

        private int[] _plan; // we will store here order of variables in column
        private int[] _allVariables;

        public string Plan
        {
            get
            {
                double[,] res = ResultMatrix;
                string plan = "";
                for(int j = 0; j < freeCount; j++)
                {
                    if(res[j, 0] == 0)
                    {
                        continue;
                    }

                    string sign = "+ ";
                    if (j == 0)
                        sign = "";

                    if (res[j, 0] < 0)
                        sign = "- ";
                    plan += sign + res[j,0] + "x" + _plan[j] + " ";
                }

                plan = plan.Substring(0, plan.Length - 1);

                return plan;
                //return this._plan;
            }
        }

        public List<double[,]> Steps { get
            {
                return this._tempMatrixes;
            }
        }

        public double[,] ResultMatrix
        {
            get
            {                
                return this._tempMatrixes.Last();
            }
        }

        public double Result
        {
            get
            {
                return this._tempMatrixes.Last()[basisCount, 0];
            }
        }

        private List<double[,]> _tempMatrixes;

        public RouteAlgorythms(double[,] matrix, double[] target)
        {
            _dataMatrix = matrix;
            _target = target;
        }

        public void ProcessMatrix(int freeCount, int basisCount)
        {
            this.basisCount = basisCount;
            this.freeCount = freeCount;
            
            OptimizeMatrix();
            CreateSimplex();

            int target = freeCount;
            bool fiction = NeedFiction();
            if (fiction)
            {
                target++;
            }

            int k = 0;
            _tempMatrixes = new List<double[,]>() { (double[,])_matrix.Clone() };
            while (!checkBFS(target) && k < 100)
            {
                RowImprove(target);
                if(fiction && checkBFS(target))
                {
                    fiction = false;
                    target--;
                } 
                k++;
            }
            
        }    

        private void OptimizeMatrix() // get rid of all fractions
        {
            for(int i = 0; i < _dataMatrix.GetUpperBound(0); i++)
            {                
                for (int j = 0; j < _dataMatrix.GetUpperBound(1); j++)
                {
                    double frac = Math.Abs(_dataMatrix[i, j] - Math.Truncate(_dataMatrix[i, j]));
                    
                    if (frac > 0)
                    {
                        MathExtend.MultipleMatrixRow(ref _dataMatrix, 1 / frac, i);
                    }
                }
            }
        }

        private void CreateSimplex() // first simplex table filling
        {
            _matrix = new double[freeCount + 2, basisCount + freeCount + 2];
            _plan = new int[basisCount];
            _allVariables = new int[freeCount + basisCount];

            for(int i = 0; i < basisCount; i++)
            {
                _plan[i] = freeCount + i + 1;
            }

            for(int i = 0; i < freeCount + basisCount; i++)
            {
                _allVariables[i] = i + 1;
            }

            for(int i = 0; i < freeCount; i++) // first column besides c0
            {
                _matrix[i, 0] = _dataMatrix[i, basisCount + freeCount];
            }

            for (int i = 0; i <= freeCount; i++) // z row besides basis variables
            {
                _matrix[freeCount, i] = - _target[i];
            }

            for (int i = freeCount + 1; i < basisCount + freeCount; i++) // z row, basis variables
            {
                _matrix[basisCount, i] = 0;
            }

            for (int i = 0; i < basisCount; i++) // a11, a12 and etc
            {
                for (int j = 1; j < basisCount + freeCount + 1; j++)
                {
                    _matrix[i, j] = _dataMatrix[i, j - 1];
                }
            }

            for (int i = 0; i < basisCount + 2; i++) // sum rows
            {
                double sum = 0;
                for (int j = 0; j < basisCount + freeCount + 1; j++) 
                {
                    sum += _matrix[i, j];
                }
                _matrix[i, basisCount + freeCount + 1] = sum;
            }
        }

        private bool NeedFiction()
        {
            bool res = false;
            for (int i = 0; i < freeCount; i++) // first column besides c0
            {
                if(_matrix[i, 0] < 0)
                {
                    res = true;
                    MathExtend.SumMatrixRows(ref _matrix, i, freeCount + 1);
                }
            }
            return res;
        }

        private bool checkBFS(int targetRow)
        {
            bool res = true;
            var matrix = _tempMatrixes.Last();
            for (int i = 1; i < basisCount + freeCount + 1; i++) // besides c0
            {
                if (matrix[targetRow, i] < 0)
                {
                    res = false;                    
                }
            }
            return res;
        }

        private void RowImprove(int target)
        {
            int col = SolvingColumn(target);
            int row = SolvingRow(col);           

            double[,] tempMatrix = MathExtend.Copy(_tempMatrixes[_tempMatrixes.Count - 1]);
            MathExtend.Jordan(ref tempMatrix, row, col);

            _tempMatrixes.Add(CalcSum(tempMatrix));

            int temp = _plan[row];
            _plan[row] = _allVariables[col - 1];
            _allVariables[col - 1] = _plan[row];

            //_tempMatrixes.Add(tempMatrix);
        }

        private int SolvingColumn(int target) // search for solving column
        {
            double absMax = 0;
            int absMaxIndex = 0;
            var matrix = _tempMatrixes.Last();
            for (int i = 1; i < basisCount + freeCount + 1; i++)
            {
                if (matrix[target, i] < 0)
                {
                    if (Math.Abs(matrix[target, i]) > absMax)
                    {
                        absMax = -matrix[target, i];
                        absMaxIndex = i;
                    }
                }
            }
            return absMaxIndex;
        }

        private int SolvingRow(int solvingColumn) // search for solving row
        {
            double minPositive = -1;
            int minPositiveIndex = 0;
            var matrix = _tempMatrixes.Last();
            for (int i = 0; i < freeCount; i++)
            {
                if (matrix[i, solvingColumn] == 0) continue;
                double frac = matrix[i, 0] / matrix[i, solvingColumn];
                if (frac >= 0)
                {
                    if (frac < minPositive || minPositive == -1)
                    {
                        minPositive = frac;
                        minPositiveIndex = i;
                    }
                }
            }

            if (minPositive == -1)
                throw new FormatException("При заданной системе ограничений функция z неограничена, т.е. поставленная задача линейного программирования решений не имеет");

            return minPositiveIndex;
        }

        private double[,] CalcSum(double[,] Matrix)
        {
            double sum = 0;
            for (int i = 0; i < Matrix.GetUpperBound(0) + 1; i++)
            {
                sum = 0;
                for (int j = 0; j < Matrix.GetUpperBound(1); j++)
                {
                    sum += Matrix[i, j];
                }
                Matrix[i, Matrix.GetUpperBound(1)] = sum;
            }

            return Matrix;
        }
    }
}
