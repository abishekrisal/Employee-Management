namespace EmployeeManagement
{
    partial class LogIn
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
            this.txtTimeIn = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastLogIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClockIn = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Location = new System.Drawing.Point(331, 314);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.ReadOnly = true;
            this.txtTimeIn.Size = new System.Drawing.Size(199, 26);
            this.txtTimeIn.TabIndex = 79;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(331, 263);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(199, 26);
            this.txtDate.TabIndex = 78;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(331, 162);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(84, 26);
            this.txtID.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 31);
            this.label3.TabIndex = 76;
            this.label3.Text = "LastLoginDate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(157, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 31);
            this.label7.TabIndex = 75;
            this.label7.Text = "EmployeeID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(113, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 31);
            this.label6.TabIndex = 74;
            this.label6.Text = "EmployeeName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(218, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 31);
            this.label5.TabIndex = 73;
            this.label5.Text = "TimeIn";
            // 
            // txtLastLogIn
            // 
            this.txtLastLogIn.Location = new System.Drawing.Point(331, 368);
            this.txtLastLogIn.Name = "txtLastLogIn";
            this.txtLastLogIn.ReadOnly = true;
            this.txtLastLogIn.Size = new System.Drawing.Size(199, 26);
            this.txtLastLogIn.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 83;
            this.label1.Text = "LogInDate";
            // 
            // btnClockIn
            // 
            this.btnClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClockIn.Location = new System.Drawing.Point(693, 445);
            this.btnClockIn.Name = "btnClockIn";
            this.btnClockIn.Size = new System.Drawing.Size(145, 64);
            this.btnClockIn.TabIndex = 85;
            this.btnClockIn.Text = "ClockIn";
            this.btnClockIn.UseVisualStyleBackColor = true;
            this.btnClockIn.Click += new System.EventHandler(this.btnClockIn_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(331, 208);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(199, 26);
            this.txtName.TabIndex = 86;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 88);
            this.panel1.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Clock-In Details";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnClockIn);
            this.Controls.Add(this.txtLastLogIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimeIn);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogIn_FormClosing);
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTimeIn;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastLogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClockIn;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}