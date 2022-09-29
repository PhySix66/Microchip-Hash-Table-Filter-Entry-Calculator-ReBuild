namespace Microchip_Hash_Table_Filter_Entry_Calculator_ReBuild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.polynomial_textbox = new System.Windows.Forms.TextBox();
            this.crc_initial_value_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dst_addresses_rtb = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtextbox_results = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Destination MAC Address:";
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(218, 360);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(75, 30);
            this.btn_calc.TabIndex = 2;
            this.btn_calc.Text = "Calculate";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // polynomial_textbox
            // 
            this.polynomial_textbox.Location = new System.Drawing.Point(9, 38);
            this.polynomial_textbox.Name = "polynomial_textbox";
            this.polynomial_textbox.Size = new System.Drawing.Size(169, 22);
            this.polynomial_textbox.TabIndex = 3;
            this.polynomial_textbox.Text = "04C11DB7";
            this.polynomial_textbox.TextChanged += new System.EventHandler(this.polynomial_textbox_TextChanged);
            this.polynomial_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.polynomial_textbox_KeyPress);
            // 
            // crc_initial_value_textbox
            // 
            this.crc_initial_value_textbox.Location = new System.Drawing.Point(9, 83);
            this.crc_initial_value_textbox.Name = "crc_initial_value_textbox";
            this.crc_initial_value_textbox.Size = new System.Drawing.Size(169, 22);
            this.crc_initial_value_textbox.TabIndex = 4;
            this.crc_initial_value_textbox.Text = "FFFFFFFF";
            this.crc_initial_value_textbox.TextChanged += new System.EventHandler(this.crc_initial_value_textbox_TextChanged);
            this.crc_initial_value_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.crc_initial_value_textbox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "CRC Polynomial(hex):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "CRC Initial Value(hex):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dst_addresses_rtb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.polynomial_textbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.crc_initial_value_textbox);
            this.groupBox1.Location = new System.Drawing.Point(15, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 316);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inputs";
            // 
            // dst_addresses_rtb
            // 
            this.dst_addresses_rtb.Location = new System.Drawing.Point(9, 128);
            this.dst_addresses_rtb.Name = "dst_addresses_rtb";
            this.dst_addresses_rtb.Size = new System.Drawing.Size(169, 182);
            this.dst_addresses_rtb.TabIndex = 7;
            this.dst_addresses_rtb.Text = "0004a3112233\nFFFFFFFFFFFF\n3333ff112233";
            this.dst_addresses_rtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dst_addresses_rtb_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(599, 51);
            this.label6.TabIndex = 10;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // rtextbox_results
            // 
            this.rtextbox_results.Location = new System.Drawing.Point(218, 80);
            this.rtextbox_results.Name = "rtextbox_results";
            this.rtextbox_results.ReadOnly = true;
            this.rtextbox_results.Size = new System.Drawing.Size(433, 263);
            this.rtextbox_results.TabIndex = 12;
            this.rtextbox_results.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Output Box:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Test RC 21.08.04";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 402);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rtextbox_results);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_calc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Microchip Hash Table Filter Entry Calculator ReBuild";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.TextBox polynomial_textbox;
        private System.Windows.Forms.TextBox crc_initial_value_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtextbox_results;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox dst_addresses_rtb;
        private System.Windows.Forms.Label label4;
    }
}

