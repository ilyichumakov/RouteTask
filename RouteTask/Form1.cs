using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplexMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<DataGridView> SimplexMatrixes;
        private List<object[]> inputData;
        protected List<IRouteSolveMethod> methods;
        int state;

        private void Form1_Load(object sender, EventArgs e)
        {
            inputData = new List<object[]>();

            inputData.Add(new object[] { "А1", "3", "7", "4", "3", "300" });
            inputData.Add(new object[] { "А2", "7", "5", "3", "9", "800" });
            inputData.Add(new object[] { "А3", "3", "7", "5", "8", "400" });
            inputData.Add(new object[] { "А4", "7", "6", "5", "9", "200" });
            inputData.Add(new object[] { "А5", "6", "7", "8", "4", "900" });
            inputData.Add(new object[] { "Потребность", "900", "700", "800", "200" });

            SimplexMatrixes = new List<DataGridView>();
            methods = new List<IRouteSolveMethod>();

            DrawInitial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SimplexMatrixes.Clear();

            List<List<object>> data = new List<List<object>>();

            object[] req = new object[inputData.Last().GetUpperBound(0)];

            object[] stocks = new object[inputData.Count - 1];

            for (int i = 0; i < inputData.Count - 1; i++)
            {
                int tail = inputData[i].GetUpperBound(0) - 1;
                data.Add(new List<object>());
                for (int j = 0; j < tail; j++)
                {
                    data[i].Add(cell(i, j + 1));
                }
                stocks[i] = cell(i, tail + 1);
            }

            for (int i = 0; i < inputData.Last().GetUpperBound(0); i++)
            {
                req[i] = cell(inputData.Count - 1, i + 1);
            }

            NorthWest nw = new NorthWest(data, req, stocks);
            LowCost lc = new LowCost(data, req, stocks);
            Vogel FliegtNachSüd = new Vogel(data, req, stocks);

            methods.Clear();

            methods.Add(nw);
            methods.Add(lc);
            methods.Add(FliegtNachSüd);

            IRouteSolveMethod optimum = FliegtNachSüd;

            foreach(IRouteSolveMethod m in methods)
            {
                var table = DrawSimplexTable(m);
                this.SimplexMatrixes.Add(table);
                if ((double)m.BasisResult < (double)optimum.BasisResult)
                {
                    optimum = m;
                }
            }
            


            AnswerLabel.Text = "Ответ: ";
            AnswerLabel.Text += optimum.BasisResult.ToString();            
            setVisibility(true);
        }

        private double cell(int i, int j)
        {
            return Double.Parse(dataTable.Rows[i].Cells[j].Value.ToString());
        }

        private DataGridView DrawTable<T>(T[,] data)
        {
            DataGridView table = new DataGridView();            

            for (int i = 0; i < data.GetUpperBound(0) + 1; i++) // z row, basis variables
            {
                table.Columns.Add("x" + (i + 1).ToString(), "x" + (i + 1).ToString());
            }            

            for (int i = 0; i < data.GetUpperBound(0) + 1; i++) // z row, basis variables
            {
                object[] row = new object[data.GetUpperBound(1) + 1];
                for (int j = 0; j < data.GetUpperBound(1) + 1; j++)
                {
                    row[j] = data[i, j];
                }
                table.Rows.Add(row);
            }
            
            return table;
        }

        private DataGridView DrawSimplexTable(IRouteSolveMethod solution)
        {
            DataGridView table = new DataGridView();

            table.Columns.Add("a", "Поставщики");

            for (int i = 0; i < solution.Rows[0].CellCount; i++)
            {
                table.Columns.Add("B" + (i + 1).ToString(), "B" + (i + 1).ToString());
            }            

            for (int i = 0; i < solution.Rows.Length; i++) 
            {
                object[] row = new object[solution.Rows[i].Cells.Length + 1];
                row[0] = "A" + (i + 1).ToString();
                for(int j = 0; j < solution.Rows[i].Cells.Length; j++)
                {
                    row[j + 1] = solution.Rows[i].Cells[j].Value;
                }                
                table.Rows.Add(row);
            }
            
            return table;
        }

        private void addRowsFromSource(DataGridView source, ref DataGridView target)
        {
            foreach (DataGridViewRow row in source.Rows)
            {
                object[] nLine = new object[row.Cells.Count];
                int i = 0;
                foreach (DataGridViewCell c in row.Cells)
                {
                    nLine[i] = c.Value;
                    i++;
                }
                target.Rows.Add(nLine);
            }
        }

        private void DrawInitial()
        {
            var arr = MathExtend.ListTo2DArr(inputData);

            var table = this.DrawTable(arr);            

            addRowsFromSource(table, ref dataTable);
            dataTable.Visible = true;
        }

        private void DrawAnother(int index)
        {
            DataGridView source = SimplexMatrixes[index];
            this.state = index;
            dgvContainer.Controls.Clear();
            dgvContainer.Controls.Add(source);
            source.Dock = DockStyle.Fill;
            
            source.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LabelState.Text = methods[state].Title;
        }

        private void ProcessDataMode_Click(object sender, EventArgs e)
        {
            var ob = (ToolStripMenuItem)sender;
            if (ob.Checked)
            {               

                inputDataMode.Checked = false;
                inputDataMode.Enabled = true;

                if (SimplexMatrixes.Count > 0)
                    DrawAnother(0);

                setVisibility(false);
            }

            ob.Enabled = false;
        }

        private void inputDataMode_Click(object sender, EventArgs e)
        {
            var ob = (ToolStripMenuItem)sender;
            if (ob.Checked)
            {
                ProcessDataMode.Checked = false;
                ProcessDataMode.Enabled = true;
                setVisibility(true);
            }

            ob.Enabled = false;
        }

        private void setVisibility(bool state)
        {
            dgvContainer.Visible = !state;
            dataTable.Visible = state;
            button1.Visible = state;
            label1.Visible = state;
            nextMatrix.Visible = !state;
            prevMatrix.Visible = !state;
            LabelState.Visible = !state;
            AnswerLabel.Visible = state;
        }

        private void nextMatrix_Click(object sender, EventArgs e)
        {
            if (SimplexMatrixes.Count > state + 1)
                DrawAnother(state + 1);
            else
                DrawAnother(0);
        }

        private void prevMatrix_Click(object sender, EventArgs e)
        {
            if (0 < state)
                DrawAnother(state - 1);
            else
                DrawAnother(SimplexMatrixes.Count - 1);
        }
    }
}
