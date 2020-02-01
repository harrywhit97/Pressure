namespace Pressure
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_CurPBar = new System.Windows.Forms.TextBox();
            this.but_Start = new System.Windows.Forms.Button();
            this.but_EndSave = new System.Windows.Forms.Button();
            this.tbox_CurPPsi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_Time = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbo_Ports = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tBox_TstName = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.but_Check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Pressure (bar)";
            // 
            // tbox_CurPBar
            // 
            this.tbox_CurPBar.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_CurPBar.Location = new System.Drawing.Point(235, 202);
            this.tbox_CurPBar.Margin = new System.Windows.Forms.Padding(6);
            this.tbox_CurPBar.Name = "tbox_CurPBar";
            this.tbox_CurPBar.Size = new System.Drawing.Size(187, 21);
            this.tbox_CurPBar.TabIndex = 4;
            // 
            // but_Start
            // 
            this.but_Start.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.but_Start.Location = new System.Drawing.Point(77, 339);
            this.but_Start.Name = "but_Start";
            this.but_Start.Size = new System.Drawing.Size(100, 60);
            this.but_Start.TabIndex = 13;
            this.but_Start.Text = "START TEST";
            this.but_Start.UseVisualStyleBackColor = true;
            this.but_Start.Click += new System.EventHandler(this.But_Start_Click);
            // 
            // but_EndSave
            // 
            this.but_EndSave.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.but_EndSave.Location = new System.Drawing.Point(183, 339);
            this.but_EndSave.Name = "but_EndSave";
            this.but_EndSave.Size = new System.Drawing.Size(100, 60);
            this.but_EndSave.TabIndex = 14;
            this.but_EndSave.Text = "SAVE CURRENT";
            this.but_EndSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.but_EndSave.UseVisualStyleBackColor = true;
            this.but_EndSave.Click += new System.EventHandler(this.But_EndSave_Click);
            // 
            // tbox_CurPPsi
            // 
            this.tbox_CurPPsi.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_CurPPsi.Location = new System.Drawing.Point(235, 243);
            this.tbox_CurPPsi.Margin = new System.Windows.Forms.Padding(6);
            this.tbox_CurPPsi.Name = "tbox_CurPPsi";
            this.tbox_CurPPsi.Size = new System.Drawing.Size(187, 21);
            this.tbox_CurPPsi.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "Current Pressure (psi)";
            // 
            // tbox_Time
            // 
            this.tbox_Time.AllowDrop = true;
            this.tbox_Time.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_Time.Location = new System.Drawing.Point(235, 285);
            this.tbox_Time.Margin = new System.Windows.Forms.Padding(6);
            this.tbox_Time.Name = "tbox_Time";
            this.tbox_Time.Size = new System.Drawing.Size(187, 21);
            this.tbox_Time.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 285);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 22);
            this.label3.TabIndex = 19;
            this.label3.Text = "Time since start";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "COM Ports";
            // 
            // cmbo_Ports
            // 
            this.cmbo_Ports.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbo_Ports.FormattingEnabled = true;
            this.cmbo_Ports.Location = new System.Drawing.Point(236, 12);
            this.cmbo_Ports.Name = "cmbo_Ports";
            this.cmbo_Ports.Size = new System.Drawing.Size(96, 22);
            this.cmbo_Ports.TabIndex = 22;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 sec",
            "2 sec",
            "10 sec",
            "30 sec",
            "1 minute"});
            this.comboBox1.Location = new System.Drawing.Point(235, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 22);
            this.comboBox1.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 22);
            this.label5.TabIndex = 23;
            this.label5.Text = "Log Time Interval";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 22);
            this.label6.TabIndex = 25;
            this.label6.Text = "Name of Test";
            // 
            // tBox_TstName
            // 
            this.tBox_TstName.BackColor = System.Drawing.SystemColors.Window;
            this.tBox_TstName.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_TstName.Location = new System.Drawing.Point(235, 54);
            this.tBox_TstName.Margin = new System.Windows.Forms.Padding(6);
            this.tBox_TstName.Name = "tBox_TstName";
            this.tBox_TstName.Size = new System.Drawing.Size(187, 21);
            this.tBox_TstName.TabIndex = 26;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(547, 36);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(580, 325);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 22);
            this.label7.TabIndex = 28;
            this.label7.Text = "Test Start Time";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(235, 135);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 21);
            this.textBox1.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.button1.Location = new System.Drawing.Point(289, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 60);
            this.button1.TabIndex = 30;
            this.button1.Text = "END AND SAVE";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // but_Check
            // 
            this.but_Check.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.but_Check.Location = new System.Drawing.Point(338, 12);
            this.but_Check.Name = "but_Check";
            this.but_Check.Size = new System.Drawing.Size(84, 30);
            this.but_Check.TabIndex = 31;
            this.but_Check.Text = "CHECK";
            this.but_Check.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.but_Check.UseVisualStyleBackColor = true;
            this.but_Check.Click += new System.EventHandler(this.but_Check_Click);
            // 
            // Form1
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1178, 455);
            this.Controls.Add(this.but_Check);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tBox_TstName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbo_Ports);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbox_Time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbox_CurPPsi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_EndSave);
            this.Controls.Add(this.but_Start);
            this.Controls.Add(this.tbox_CurPBar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Futura Lt BT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Pressure Measurement";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_CurPBar;
        private System.Windows.Forms.Button but_Start;
        private System.Windows.Forms.Button but_EndSave;
        private System.Windows.Forms.TextBox tbox_CurPPsi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_Time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbo_Ports;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBox_TstName;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button but_Check;
    }
}

