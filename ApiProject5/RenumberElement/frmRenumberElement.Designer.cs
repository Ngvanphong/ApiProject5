namespace ApiProject5.RenumberElement
{
    partial class frmRenumberElement
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTypeElementRenumber = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMainRenumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPrefitRenumber = new System.Windows.Forms.TextBox();
            this.textBoxSubffixRenumber = new System.Windows.Forms.TextBox();
            this.btnStartRenumberElement = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPreviewRenumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxParameterRenumerElement = new System.Windows.Forms.ComboBox();
            this.numericUpDownStepRenumber = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonManualSelect = new System.Windows.Forms.RadioButton();
            this.radioButtonAutoBottomLeft = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepRenumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type Element: ";
            // 
            // comboBoxTypeElementRenumber
            // 
            this.comboBoxTypeElementRenumber.FormattingEnabled = true;
            this.comboBoxTypeElementRenumber.Location = new System.Drawing.Point(84, 16);
            this.comboBoxTypeElementRenumber.Name = "comboBoxTypeElementRenumber";
            this.comboBoxTypeElementRenumber.Size = new System.Drawing.Size(212, 21);
            this.comboBoxTypeElementRenumber.TabIndex = 1;
            this.comboBoxTypeElementRenumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeElementRenumber_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Main number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Step:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Prefit:";
            // 
            // textBoxMainRenumber
            // 
            this.textBoxMainRenumber.Location = new System.Drawing.Point(84, 123);
            this.textBoxMainRenumber.Name = "textBoxMainRenumber";
            this.textBoxMainRenumber.Size = new System.Drawing.Size(212, 20);
            this.textBoxMainRenumber.TabIndex = 3;
            this.textBoxMainRenumber.Text = "01";
            this.textBoxMainRenumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxMainRenumber_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Subffix:";
            // 
            // textBoxPrefitRenumber
            // 
            this.textBoxPrefitRenumber.Location = new System.Drawing.Point(84, 97);
            this.textBoxPrefitRenumber.Name = "textBoxPrefitRenumber";
            this.textBoxPrefitRenumber.Size = new System.Drawing.Size(212, 20);
            this.textBoxPrefitRenumber.TabIndex = 3;
            this.textBoxPrefitRenumber.TextChanged += new System.EventHandler(this.textBoxPrefitRenumber_TextChanged);
            // 
            // textBoxSubffixRenumber
            // 
            this.textBoxSubffixRenumber.Location = new System.Drawing.Point(84, 149);
            this.textBoxSubffixRenumber.Name = "textBoxSubffixRenumber";
            this.textBoxSubffixRenumber.Size = new System.Drawing.Size(212, 20);
            this.textBoxSubffixRenumber.TabIndex = 3;
            this.textBoxSubffixRenumber.TextChanged += new System.EventHandler(this.textBoxSubffixRenumber_TextChanged);
            // 
            // btnStartRenumberElement
            // 
            this.btnStartRenumberElement.Location = new System.Drawing.Point(217, 176);
            this.btnStartRenumberElement.Name = "btnStartRenumberElement";
            this.btnStartRenumberElement.Size = new System.Drawing.Size(79, 26);
            this.btnStartRenumberElement.TabIndex = 4;
            this.btnStartRenumberElement.Text = "Start";
            this.btnStartRenumberElement.UseVisualStyleBackColor = true;
            this.btnStartRenumberElement.Click += new System.EventHandler(this.btnStartRenumberElement_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Preview:";
            // 
            // textBoxPreviewRenumber
            // 
            this.textBoxPreviewRenumber.Location = new System.Drawing.Point(84, 179);
            this.textBoxPreviewRenumber.Name = "textBoxPreviewRenumber";
            this.textBoxPreviewRenumber.Size = new System.Drawing.Size(127, 20);
            this.textBoxPreviewRenumber.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Parameter: ";
            // 
            // comboBoxParameterRenumerElement
            // 
            this.comboBoxParameterRenumerElement.FormattingEnabled = true;
            this.comboBoxParameterRenumerElement.Location = new System.Drawing.Point(84, 43);
            this.comboBoxParameterRenumerElement.Name = "comboBoxParameterRenumerElement";
            this.comboBoxParameterRenumerElement.Size = new System.Drawing.Size(212, 21);
            this.comboBoxParameterRenumerElement.TabIndex = 1;
            // 
            // numericUpDownStepRenumber
            // 
            this.numericUpDownStepRenumber.Location = new System.Drawing.Point(84, 71);
            this.numericUpDownStepRenumber.Name = "numericUpDownStepRenumber";
            this.numericUpDownStepRenumber.Size = new System.Drawing.Size(212, 20);
            this.numericUpDownStepRenumber.TabIndex = 2;
            this.numericUpDownStepRenumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonAutoBottomLeft);
            this.groupBox1.Controls.Add(this.radioButtonManualSelect);
            this.groupBox1.Location = new System.Drawing.Point(306, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 78);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type:";
            // 
            // radioButtonManualSelect
            // 
            this.radioButtonManualSelect.AutoSize = true;
            this.radioButtonManualSelect.Checked = true;
            this.radioButtonManualSelect.Location = new System.Drawing.Point(7, 20);
            this.radioButtonManualSelect.Name = "radioButtonManualSelect";
            this.radioButtonManualSelect.Size = new System.Drawing.Size(85, 17);
            this.radioButtonManualSelect.TabIndex = 0;
            this.radioButtonManualSelect.TabStop = true;
            this.radioButtonManualSelect.Text = "Single select";
            this.radioButtonManualSelect.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutoBottomLeft
            // 
            this.radioButtonAutoBottomLeft.AutoSize = true;
            this.radioButtonAutoBottomLeft.Location = new System.Drawing.Point(7, 43);
            this.radioButtonAutoBottomLeft.Name = "radioButtonAutoBottomLeft";
            this.radioButtonAutoBottomLeft.Size = new System.Drawing.Size(139, 17);
            this.radioButtonAutoBottomLeft.TabIndex = 0;
            this.radioButtonAutoBottomLeft.Text = "Multi select (Left->Right)";
            this.radioButtonAutoBottomLeft.UseVisualStyleBackColor = true;
            // 
            // frmRenumberElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 215);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartRenumberElement);
            this.Controls.Add(this.textBoxPrefitRenumber);
            this.Controls.Add(this.textBoxPreviewRenumber);
            this.Controls.Add(this.textBoxSubffixRenumber);
            this.Controls.Add(this.textBoxMainRenumber);
            this.Controls.Add(this.numericUpDownStepRenumber);
            this.Controls.Add(this.comboBoxParameterRenumerElement);
            this.Controls.Add(this.comboBoxTypeElementRenumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenumberElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRenumberElement";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRenumberElement_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmRenumberElement_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStepRenumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnStartRenumberElement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox comboBoxTypeElementRenumber;
        public System.Windows.Forms.ComboBox comboBoxParameterRenumerElement;
        public System.Windows.Forms.NumericUpDown numericUpDownStepRenumber;
        public System.Windows.Forms.TextBox textBoxPrefitRenumber;
        public System.Windows.Forms.TextBox textBoxMainRenumber;
        public System.Windows.Forms.TextBox textBoxSubffixRenumber;
        public System.Windows.Forms.TextBox textBoxPreviewRenumber;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioButtonAutoBottomLeft;
        public System.Windows.Forms.RadioButton radioButtonManualSelect;
    }
}