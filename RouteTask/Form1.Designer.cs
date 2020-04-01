namespace SimplexMethod
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bread1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bread2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bread3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bread4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inputDataMode = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessDataMode = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvContainer = new System.Windows.Forms.Panel();
            this.nextMatrix = new System.Windows.Forms.Label();
            this.prevMatrix = new System.Windows.Forms.Label();
            this.LabelState = new System.Windows.Forms.Label();
            this.AnswerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataTable
            // 
            this.dataTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Bread1,
            this.Bread2,
            this.Bread3,
            this.Bread4,
            this.Column1});
            this.dataTable.Location = new System.Drawing.Point(177, 71);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(594, 228);
            this.dataTable.TabIndex = 0;
            // 
            // Product
            // 
            this.Product.HeaderText = "Поставщик";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product.Width = 150;
            // 
            // Bread1
            // 
            this.Bread1.HeaderText = "В1";
            this.Bread1.Name = "Bread1";
            // 
            // Bread2
            // 
            this.Bread2.HeaderText = "В2";
            this.Bread2.Name = "Bread2";
            // 
            // Bread3
            // 
            this.Bread3.HeaderText = "В3";
            this.Bread3.Name = "Bread3";
            // 
            // Bread4
            // 
            this.Bread4.HeaderText = "В4";
            this.Bread4.Name = "Bread4";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Запас";
            this.Column1.Name = "Column1";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(418, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Решить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(390, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Потребитель";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputDataMode,
            this.ProcessDataMode});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem1.Text = "Вид";
            // 
            // inputDataMode
            // 
            this.inputDataMode.Checked = true;
            this.inputDataMode.CheckOnClick = true;
            this.inputDataMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.inputDataMode.Enabled = false;
            this.inputDataMode.Name = "inputDataMode";
            this.inputDataMode.Size = new System.Drawing.Size(173, 22);
            this.inputDataMode.Text = "Исходные данные";
            this.inputDataMode.Click += new System.EventHandler(this.inputDataMode_Click);
            // 
            // ProcessDataMode
            // 
            this.ProcessDataMode.CheckOnClick = true;
            this.ProcessDataMode.Name = "ProcessDataMode";
            this.ProcessDataMode.Size = new System.Drawing.Size(173, 22);
            this.ProcessDataMode.Text = "Методы решения";
            this.ProcessDataMode.Click += new System.EventHandler(this.ProcessDataMode_Click);
            // 
            // dgvContainer
            // 
            this.dgvContainer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvContainer.Location = new System.Drawing.Point(164, 59);
            this.dgvContainer.Name = "dgvContainer";
            this.dgvContainer.Size = new System.Drawing.Size(619, 259);
            this.dgvContainer.TabIndex = 4;
            // 
            // nextMatrix
            // 
            this.nextMatrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextMatrix.BackColor = System.Drawing.Color.PeachPuff;
            this.nextMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextMatrix.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextMatrix.Location = new System.Drawing.Point(613, 324);
            this.nextMatrix.Name = "nextMatrix";
            this.nextMatrix.Size = new System.Drawing.Size(170, 29);
            this.nextMatrix.TabIndex = 2;
            this.nextMatrix.Text = "Далее";
            this.nextMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nextMatrix.Visible = false;
            this.nextMatrix.Click += new System.EventHandler(this.nextMatrix_Click);
            // 
            // prevMatrix
            // 
            this.prevMatrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prevMatrix.BackColor = System.Drawing.Color.PeachPuff;
            this.prevMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prevMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prevMatrix.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prevMatrix.Location = new System.Drawing.Point(164, 326);
            this.prevMatrix.Name = "prevMatrix";
            this.prevMatrix.Size = new System.Drawing.Size(170, 29);
            this.prevMatrix.TabIndex = 2;
            this.prevMatrix.Text = "Назад";
            this.prevMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.prevMatrix.Visible = false;
            this.prevMatrix.Click += new System.EventHandler(this.prevMatrix_Click);
            // 
            // LabelState
            // 
            this.LabelState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelState.BackColor = System.Drawing.Color.LightGreen;
            this.LabelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelState.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LabelState.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelState.Location = new System.Drawing.Point(244, 24);
            this.LabelState.Name = "LabelState";
            this.LabelState.Size = new System.Drawing.Size(513, 29);
            this.LabelState.TabIndex = 2;
            this.LabelState.Text = "0";
            this.LabelState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelState.Visible = false;
            this.LabelState.Click += new System.EventHandler(this.prevMatrix_Click);
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AnswerLabel.BackColor = System.Drawing.Color.LightGreen;
            this.AnswerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnswerLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AnswerLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnswerLabel.Location = new System.Drawing.Point(389, 379);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(170, 29);
            this.AnswerLabel.TabIndex = 2;
            this.AnswerLabel.Text = "Ответ:";
            this.AnswerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AnswerLabel.Visible = false;
            this.AnswerLabel.Click += new System.EventHandler(this.prevMatrix_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.LabelState);
            this.Controls.Add(this.prevMatrix);
            this.Controls.Add(this.nextMatrix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataTable);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgvContainer);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(768, 480);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Simplex Method";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inputDataMode;
        private System.Windows.Forms.ToolStripMenuItem ProcessDataMode;
        private System.Windows.Forms.Panel dgvContainer;
        private System.Windows.Forms.Label nextMatrix;
        private System.Windows.Forms.Label prevMatrix;
        private System.Windows.Forms.Label LabelState;
        private System.Windows.Forms.Label AnswerLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bread1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bread2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bread3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bread4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

