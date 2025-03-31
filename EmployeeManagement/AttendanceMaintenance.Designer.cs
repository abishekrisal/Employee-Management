namespace EmployeeManagement
{
    partial class Attendance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLeaveReport = new System.Windows.Forms.Button();
            this.btnAttendanceReport = new System.Windows.Forms.Button();
            this.btnCheckHours = new System.Windows.Forms.Button();
            this.btnAdjustAttendance = new System.Windows.Forms.Button();
            this.btnLogOut1 = new System.Windows.Forms.Button();
            this.btnEmployeeRecord1 = new System.Windows.Forms.Button();
            this.btnLogIn1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 110);
            this.panel1.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Attendance";
            // 
            // btnLeaveReport
            // 
            this.btnLeaveReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaveReport.Location = new System.Drawing.Point(17, 551);
            this.btnLeaveReport.Name = "btnLeaveReport";
            this.btnLeaveReport.Size = new System.Drawing.Size(190, 56);
            this.btnLeaveReport.TabIndex = 11;
            this.btnLeaveReport.Text = "Leave Report";
            this.btnLeaveReport.UseVisualStyleBackColor = true;
            // 
            // btnAttendanceReport
            // 
            this.btnAttendanceReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendanceReport.Location = new System.Drawing.Point(17, 406);
            this.btnAttendanceReport.Name = "btnAttendanceReport";
            this.btnAttendanceReport.Size = new System.Drawing.Size(190, 56);
            this.btnAttendanceReport.TabIndex = 10;
            this.btnAttendanceReport.Text = "Attendance Report";
            this.btnAttendanceReport.UseVisualStyleBackColor = true;
            // 
            // btnCheckHours
            // 
            this.btnCheckHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckHours.Location = new System.Drawing.Point(17, 477);
            this.btnCheckHours.Name = "btnCheckHours";
            this.btnCheckHours.Size = new System.Drawing.Size(190, 56);
            this.btnCheckHours.TabIndex = 2;
            this.btnCheckHours.Text = "CheckHours";
            this.btnCheckHours.UseVisualStyleBackColor = true;
            // 
            // btnAdjustAttendance
            // 
            this.btnAdjustAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustAttendance.Location = new System.Drawing.Point(17, 335);
            this.btnAdjustAttendance.Name = "btnAdjustAttendance";
            this.btnAdjustAttendance.Size = new System.Drawing.Size(190, 56);
            this.btnAdjustAttendance.TabIndex = 3;
            this.btnAdjustAttendance.Text = "Adjust Attendance";
            this.btnAdjustAttendance.UseVisualStyleBackColor = true;
            // 
            // btnLogOut1
            // 
            this.btnLogOut1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut1.Location = new System.Drawing.Point(17, 172);
            this.btnLogOut1.Name = "btnLogOut1";
            this.btnLogOut1.Size = new System.Drawing.Size(190, 50);
            this.btnLogOut1.TabIndex = 63;
            this.btnLogOut1.Text = "LogOut";
            this.btnLogOut1.UseVisualStyleBackColor = true;
            this.btnLogOut1.Click += new System.EventHandler(this.btnLogOut1_Click);
            // 
            // btnEmployeeRecord1
            // 
            this.btnEmployeeRecord1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeRecord1.Location = new System.Drawing.Point(17, 271);
            this.btnEmployeeRecord1.Name = "btnEmployeeRecord1";
            this.btnEmployeeRecord1.Size = new System.Drawing.Size(190, 50);
            this.btnEmployeeRecord1.TabIndex = 62;
            this.btnEmployeeRecord1.Text = "Employee Record";
            this.btnEmployeeRecord1.UseVisualStyleBackColor = true;
            // 
            // btnLogIn1
            // 
            this.btnLogIn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn1.Location = new System.Drawing.Point(17, 116);
            this.btnLogIn1.Name = "btnLogIn1";
            this.btnLogIn1.Size = new System.Drawing.Size(190, 50);
            this.btnLogIn1.TabIndex = 61;
            this.btnLogIn1.Text = "LogIn";
            this.btnLogIn1.UseVisualStyleBackColor = true;
            this.btnLogIn1.Click += new System.EventHandler(this.btnLogIn1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btnAddEmployee);
            this.panel2.Controls.Add(this.btnLogIn1);
            this.panel2.Controls.Add(this.btnLeaveReport);
            this.panel2.Controls.Add(this.btnLogOut1);
            this.panel2.Controls.Add(this.btnEmployeeRecord1);
            this.panel2.Controls.Add(this.btnAttendanceReport);
            this.panel2.Controls.Add(this.btnAdjustAttendance);
            this.panel2.Controls.Add(this.btnCheckHours);
            this.panel2.Location = new System.Drawing.Point(1063, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 677);
            this.panel2.TabIndex = 110;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.Location = new System.Drawing.Point(17, 625);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(190, 50);
            this.btnAddEmployee.TabIndex = 64;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 70;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1045, 561);
            this.dataGridView1.TabIndex = 111;
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 701);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Attendance";
            this.Text = "Employee Attendance ";
            this.Load += new System.EventHandler(this.Attendance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLeaveReport;
        private System.Windows.Forms.Button btnAttendanceReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckHours;
        private System.Windows.Forms.Button btnAdjustAttendance;
        private System.Windows.Forms.Button btnLogOut1;
        private System.Windows.Forms.Button btnEmployeeRecord1;
        private System.Windows.Forms.Button btnLogIn1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}