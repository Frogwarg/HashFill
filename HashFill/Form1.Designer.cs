namespace HashFill
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.openTable = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chainTable = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buildBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.collisionLabel = new System.Windows.Forms.Label();
            this.treeOutput = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chainTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(411, 446);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.openTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(403, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Открытая";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // openTable
            // 
            this.openTable.AllowUserToAddRows = false;
            this.openTable.AllowUserToDeleteRows = false;
            this.openTable.AllowUserToResizeColumns = false;
            this.openTable.AllowUserToResizeRows = false;
            this.openTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.openTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.openTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.openTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openTable.Location = new System.Drawing.Point(3, 3);
            this.openTable.Name = "openTable";
            this.openTable.Size = new System.Drawing.Size(397, 414);
            this.openTable.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chainTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(403, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Цепочка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chainTable
            // 
            this.chainTable.AllowUserToAddRows = false;
            this.chainTable.AllowUserToDeleteRows = false;
            this.chainTable.AllowUserToResizeColumns = false;
            this.chainTable.AllowUserToResizeRows = false;
            this.chainTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.chainTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.chainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chainTable.Location = new System.Drawing.Point(3, 3);
            this.chainTable.Name = "chainTable";
            this.chainTable.Size = new System.Drawing.Size(397, 414);
            this.chainTable.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.treeOutput);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(403, 420);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Бинарное дерево";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buildBtn);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(449, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Разрешение коллизий";
            // 
            // buildBtn
            // 
            this.buildBtn.Location = new System.Drawing.Point(64, 59);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(75, 23);
            this.buildBtn.TabIndex = 1;
            this.buildBtn.Text = "Построить";
            this.buildBtn.UseVisualStyleBackColor = true;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Открытая адрессация",
            "Метод цепочек",
            "Бинарное дерево"});
            this.comboBox1.Location = new System.Drawing.Point(11, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(449, 195);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(449, 247);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(192, 177);
            this.textBox2.TabIndex = 3;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(566, 195);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 21);
            this.findBtn.TabIndex = 4;
            this.findBtn.Text = "Найти";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Поиск:";
            // 
            // collisionLabel
            // 
            this.collisionLabel.AutoSize = true;
            this.collisionLabel.Location = new System.Drawing.Point(457, 436);
            this.collisionLabel.Name = "collisionLabel";
            this.collisionLabel.Size = new System.Drawing.Size(171, 13);
            this.collisionLabel.TabIndex = 6;
            this.collisionLabel.Text = "Среднее колличество коллизий:";
            // 
            // treeOutput
            // 
            this.treeOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeOutput.DetectUrls = false;
            this.treeOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOutput.Location = new System.Drawing.Point(0, 0);
            this.treeOutput.Name = "treeOutput";
            this.treeOutput.Size = new System.Drawing.Size(403, 420);
            this.treeOutput.TabIndex = 0;
            this.treeOutput.Text = "";
            this.treeOutput.WordWrap = false;
            this.treeOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 467);
            this.Controls.Add(this.collisionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Андронатий 21ПИ ЛБ1";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chainTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buildBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label collisionLabel;
        private System.Windows.Forms.DataGridView openTable;
        private System.Windows.Forms.DataGridView chainTable;
        private System.Windows.Forms.RichTextBox treeOutput;
    }
}

