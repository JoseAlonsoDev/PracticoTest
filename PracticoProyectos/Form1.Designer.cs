namespace PracticoProyectos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            workerHours = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(306, 7);
            label1.Name = "label1";
            label1.Size = new Size(108, 30);
            label1.TabIndex = 0;
            label1.Text = "Proyectos";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(320, 272);
            label2.Name = "label2";
            label2.Size = new Size(74, 30);
            label2.TabIndex = 1;
            label2.Text = "Tareas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { name, description, status, workerHours });
            dataGridView1.Location = new Point(361, 64);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(342, 165);
            dataGridView1.TabIndex = 2;
            // 
            // name
            // 
            name.HeaderText = "name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // description
            // 
            description.HeaderText = "description";
            description.MinimumWidth = 6;
            description.Name = "description";
            description.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.Width = 125;
            // 
            // workerHours
            // 
            workerHours.HeaderText = "workerHours";
            workerHours.MinimumWidth = 6;
            workerHours.Name = "workerHours";
            workerHours.Width = 125;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(357, 346);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(346, 150);
            dataGridView2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(83, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(83, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 553);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn workerHours;
        private DataGridView dataGridView2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
