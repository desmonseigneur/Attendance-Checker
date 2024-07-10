namespace Municipal
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
            this.CheckIn = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.NameLB = new System.Windows.Forms.Label();
            this.DeptBox = new System.Windows.Forms.TextBox();
            this.PosBox = new System.Windows.Forms.TextBox();
            this.DeptLB = new System.Windows.Forms.Label();
            this.PosLB = new System.Windows.Forms.Label();
            this.CheckOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckIn
            // 
            this.CheckIn.Location = new System.Drawing.Point(174, 242);
            this.CheckIn.Name = "CheckIn";
            this.CheckIn.Size = new System.Drawing.Size(227, 79);
            this.CheckIn.TabIndex = 1;
            this.CheckIn.Text = "Check In";
            this.CheckIn.UseVisualStyleBackColor = true;
            this.CheckIn.Click += new System.EventHandler(this.CheckIn_Click);
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NameBox.Location = new System.Drawing.Point(209, 55);
            this.NameBox.Multiline = true;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(306, 41);
            this.NameBox.TabIndex = 3;
            // 
            // NameLB
            // 
            this.NameLB.AutoSize = true;
            this.NameLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NameLB.Location = new System.Drawing.Point(39, 62);
            this.NameLB.Name = "NameLB";
            this.NameLB.Size = new System.Drawing.Size(136, 20);
            this.NameLB.TabIndex = 4;
            this.NameLB.Text = "Employee Name:";
            // 
            // DeptBox
            // 
            this.DeptBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DeptBox.Location = new System.Drawing.Point(209, 114);
            this.DeptBox.Multiline = true;
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(306, 41);
            this.DeptBox.TabIndex = 6;
            // 
            // PosBox
            // 
            this.PosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PosBox.Location = new System.Drawing.Point(209, 178);
            this.PosBox.Multiline = true;
            this.PosBox.Name = "PosBox";
            this.PosBox.Size = new System.Drawing.Size(306, 41);
            this.PosBox.TabIndex = 7;
            // 
            // DeptLB
            // 
            this.DeptLB.AutoSize = true;
            this.DeptLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DeptLB.Location = new System.Drawing.Point(39, 121);
            this.DeptLB.Name = "DeptLB";
            this.DeptLB.Size = new System.Drawing.Size(102, 20);
            this.DeptLB.TabIndex = 10;
            this.DeptLB.Text = "Department:";
            // 
            // PosLB
            // 
            this.PosLB.AutoSize = true;
            this.PosLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PosLB.Location = new System.Drawing.Point(39, 185);
            this.PosLB.Name = "PosLB";
            this.PosLB.Size = new System.Drawing.Size(74, 20);
            this.PosLB.TabIndex = 11;
            this.PosLB.Text = "Position:";
            // 
            // CheckOut
            // 
            this.CheckOut.Location = new System.Drawing.Point(217, 329);
            this.CheckOut.Name = "CheckOut";
            this.CheckOut.Size = new System.Drawing.Size(147, 58);
            this.CheckOut.TabIndex = 12;
            this.CheckOut.Text = "Check Out";
            this.CheckOut.UseVisualStyleBackColor = true;
            this.CheckOut.Click += new System.EventHandler(this.CheckOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 479);
            this.Controls.Add(this.CheckOut);
            this.Controls.Add(this.PosLB);
            this.Controls.Add(this.DeptLB);
            this.Controls.Add(this.PosBox);
            this.Controls.Add(this.DeptBox);
            this.Controls.Add(this.NameLB);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.CheckIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Attendance";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckIn;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label NameLB;
        private System.Windows.Forms.TextBox DeptBox;
        private System.Windows.Forms.TextBox PosBox;
        private System.Windows.Forms.Label DeptLB;
        private System.Windows.Forms.Label PosLB;
        private System.Windows.Forms.Button CheckOut;
    }
}

