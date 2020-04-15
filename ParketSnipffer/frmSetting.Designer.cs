namespace ParketSnipffer
{
    partial class frmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.lbTran = new System.Windows.Forms.Label();
            this.cbTiStamp = new System.Windows.Forms.CheckBox();
            this.cbAutoScr = new System.Windows.Forms.CheckBox();
            this.cbEchoRec = new System.Windows.Forms.CheckBox();
            this.btnClTran = new System.Windows.Forms.Button();
            this.btnClRec = new System.Windows.Forms.Button();
            this.lbRec = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTran
            // 
            this.lbTran.AutoSize = true;
            this.lbTran.Location = new System.Drawing.Point(33, 21);
            this.lbTran.Name = "lbTran";
            this.lbTran.Size = new System.Drawing.Size(29, 13);
            this.lbTran.TabIndex = 0;
            this.lbTran.Text = "Tran";
            // 
            // cbTiStamp
            // 
            this.cbTiStamp.AutoSize = true;
            this.cbTiStamp.Checked = true;
            this.cbTiStamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTiStamp.Location = new System.Drawing.Point(135, 75);
            this.cbTiStamp.Margin = new System.Windows.Forms.Padding(4);
            this.cbTiStamp.Name = "cbTiStamp";
            this.cbTiStamp.Size = new System.Drawing.Size(82, 17);
            this.cbTiStamp.TabIndex = 17;
            this.cbTiStamp.Text = "Time Stamp";
            this.cbTiStamp.UseVisualStyleBackColor = true;
            // 
            // cbAutoScr
            // 
            this.cbAutoScr.AutoSize = true;
            this.cbAutoScr.Checked = true;
            this.cbAutoScr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoScr.Location = new System.Drawing.Point(36, 75);
            this.cbAutoScr.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutoScr.Name = "cbAutoScr";
            this.cbAutoScr.Size = new System.Drawing.Size(75, 17);
            this.cbAutoScr.TabIndex = 16;
            this.cbAutoScr.Text = "Auto scroll";
            this.cbAutoScr.UseVisualStyleBackColor = true;
            // 
            // cbEchoRec
            // 
            this.cbEchoRec.AutoSize = true;
            this.cbEchoRec.Location = new System.Drawing.Point(36, 99);
            this.cbEchoRec.Name = "cbEchoRec";
            this.cbEchoRec.Size = new System.Drawing.Size(71, 17);
            this.cbEchoRec.TabIndex = 20;
            this.cbEchoRec.Text = "EchoRec";
            this.cbEchoRec.UseVisualStyleBackColor = true;
            // 
            // btnClTran
            // 
            this.btnClTran.BackColor = System.Drawing.Color.Green;
            this.btnClTran.Location = new System.Drawing.Point(73, 16);
            this.btnClTran.Margin = new System.Windows.Forms.Padding(4);
            this.btnClTran.Name = "btnClTran";
            this.btnClTran.Size = new System.Drawing.Size(44, 22);
            this.btnClTran.TabIndex = 18;
            this.btnClTran.UseVisualStyleBackColor = false;
            this.btnClTran.Click += new System.EventHandler(this.color_Click);
            // 
            // btnClRec
            // 
            this.btnClRec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClRec.Location = new System.Drawing.Point(160, 16);
            this.btnClRec.Margin = new System.Windows.Forms.Padding(4);
            this.btnClRec.Name = "btnClRec";
            this.btnClRec.Size = new System.Drawing.Size(44, 22);
            this.btnClRec.TabIndex = 19;
            this.btnClRec.UseVisualStyleBackColor = false;
            this.btnClRec.Click += new System.EventHandler(this.color_Click);
            // 
            // lbRec
            // 
            this.lbRec.AutoSize = true;
            this.lbRec.Location = new System.Drawing.Point(126, 21);
            this.lbRec.Name = "lbRec";
            this.lbRec.Size = new System.Drawing.Size(27, 13);
            this.lbRec.TabIndex = 0;
            this.lbRec.Text = "Rec";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(33, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 51);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adapter";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(122, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(43, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "uart";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(66, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(38, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "spi";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "i2c";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.radioButton11);
            this.groupBox4.Controls.Add(this.radioButton5);
            this.groupBox4.Location = new System.Drawing.Point(20, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 79);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Option";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(166, 48);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(92, 20);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "0x26";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(7, 22);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(90, 17);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.Text = "Auto Connect";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Checked = true;
            this.radioButton11.Location = new System.Drawing.Point(167, 22);
            this.radioButton11.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(51, 17);
            this.radioButton11.TabIndex = 2;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "None";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(7, 50);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(127, 17);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.Text = "Auto Connect Device";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Font:";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(73, 45);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(212, 23);
            this.btnFont.TabIndex = 23;
            this.btnFont.Text = "Seclect font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "ms";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(220, 97);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(38, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "200";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Auto save log";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Log dir";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(178, 127);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "C:\\";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Hex:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(71, 123);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(29, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "0x";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(36, 150);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "enter to send";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(112, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 361);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbTiStamp);
            this.Controls.Add(this.cbAutoScr);
            this.Controls.Add(this.cbEchoRec);
            this.Controls.Add(this.btnClTran);
            this.Controls.Add(this.btnClRec);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbRec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTran);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTran;
        private System.Windows.Forms.CheckBox cbTiStamp;
        private System.Windows.Forms.CheckBox cbAutoScr;
        private System.Windows.Forms.CheckBox cbEchoRec;
        private System.Windows.Forms.Button btnClTran;
        private System.Windows.Forms.Button btnClRec;
        private System.Windows.Forms.Label lbRec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnSave;
    }
}