namespace ApiProject5.ParameterSetValue
{
    partial class frmParameterSet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnParameterSetValue = new System.Windows.Forms.Button();
            this.radioButtonInSelectionView = new System.Windows.Forms.RadioButton();
            this.radioButtonInEntireProject = new System.Windows.Forms.RadioButton();
            this.radioButtonUpperText = new System.Windows.Forms.RadioButton();
            this.radioButtonLowerText = new System.Windows.Forms.RadioButton();
            this.radioButtonTitleText = new System.Windows.Forms.RadioButton();
            this.radioButtonSentenceText = new System.Windows.Forms.RadioButton();
            this.comboBoxNameParameterEle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxValueParameterEle = new System.Windows.Forms.TextBox();
            this.radioButtonNormalText = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonInEntireProject);
            this.groupBox1.Controls.Add(this.radioButtonInSelectionView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonNormalText);
            this.groupBox2.Controls.Add(this.radioButtonSentenceText);
            this.groupBox2.Controls.Add(this.radioButtonTitleText);
            this.groupBox2.Controls.Add(this.radioButtonLowerText);
            this.groupBox2.Controls.Add(this.radioButtonUpperText);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 80);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UPPER or lower case";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBoxValueParameterEle);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboBoxNameParameterEle);
            this.groupBox3.Location = new System.Drawing.Point(12, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 101);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameter";
            // 
            // btnParameterSetValue
            // 
            this.btnParameterSetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParameterSetValue.Location = new System.Drawing.Point(327, 263);
            this.btnParameterSetValue.Name = "btnParameterSetValue";
            this.btnParameterSetValue.Size = new System.Drawing.Size(75, 30);
            this.btnParameterSetValue.TabIndex = 1;
            this.btnParameterSetValue.Text = "Ok";
            this.btnParameterSetValue.UseVisualStyleBackColor = true;
            this.btnParameterSetValue.Click += new System.EventHandler(this.btnParameterSetValue_Click);
            // 
            // radioButtonInSelectionView
            // 
            this.radioButtonInSelectionView.AutoSize = true;
            this.radioButtonInSelectionView.Checked = true;
            this.radioButtonInSelectionView.Location = new System.Drawing.Point(27, 19);
            this.radioButtonInSelectionView.Name = "radioButtonInSelectionView";
            this.radioButtonInSelectionView.Size = new System.Drawing.Size(79, 17);
            this.radioButtonInSelectionView.TabIndex = 0;
            this.radioButtonInSelectionView.TabStop = true;
            this.radioButtonInSelectionView.Text = "In selection";
            this.radioButtonInSelectionView.UseVisualStyleBackColor = true;
            // 
            // radioButtonInEntireProject
            // 
            this.radioButtonInEntireProject.AutoSize = true;
            this.radioButtonInEntireProject.Location = new System.Drawing.Point(176, 19);
            this.radioButtonInEntireProject.Name = "radioButtonInEntireProject";
            this.radioButtonInEntireProject.Size = new System.Drawing.Size(99, 17);
            this.radioButtonInEntireProject.TabIndex = 0;
            this.radioButtonInEntireProject.Text = "In entire Project";
            this.radioButtonInEntireProject.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpperText
            // 
            this.radioButtonUpperText.AutoSize = true;
            this.radioButtonUpperText.Location = new System.Drawing.Point(156, 19);
            this.radioButtonUpperText.Name = "radioButtonUpperText";
            this.radioButtonUpperText.Size = new System.Drawing.Size(93, 17);
            this.radioButtonUpperText.TabIndex = 0;
            this.radioButtonUpperText.Text = "UPPER CASE";
            this.radioButtonUpperText.UseVisualStyleBackColor = true;
            // 
            // radioButtonLowerText
            // 
            this.radioButtonLowerText.AutoSize = true;
            this.radioButtonLowerText.Location = new System.Drawing.Point(284, 19);
            this.radioButtonLowerText.Name = "radioButtonLowerText";
            this.radioButtonLowerText.Size = new System.Drawing.Size(76, 17);
            this.radioButtonLowerText.TabIndex = 0;
            this.radioButtonLowerText.Text = "lower case";
            this.radioButtonLowerText.UseVisualStyleBackColor = true;
            // 
            // radioButtonTitleText
            // 
            this.radioButtonTitleText.AutoSize = true;
            this.radioButtonTitleText.Location = new System.Drawing.Point(156, 57);
            this.radioButtonTitleText.Name = "radioButtonTitleText";
            this.radioButtonTitleText.Size = new System.Drawing.Size(72, 17);
            this.radioButtonTitleText.TabIndex = 0;
            this.radioButtonTitleText.Text = "Title Case";
            this.radioButtonTitleText.UseVisualStyleBackColor = true;
            // 
            // radioButtonSentenceText
            // 
            this.radioButtonSentenceText.AutoSize = true;
            this.radioButtonSentenceText.Location = new System.Drawing.Point(27, 57);
            this.radioButtonSentenceText.Name = "radioButtonSentenceText";
            this.radioButtonSentenceText.Size = new System.Drawing.Size(97, 17);
            this.radioButtonSentenceText.TabIndex = 0;
            this.radioButtonSentenceText.Text = "Sentence case";
            this.radioButtonSentenceText.UseVisualStyleBackColor = true;
            // 
            // comboBoxNameParameterEle
            // 
            this.comboBoxNameParameterEle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxNameParameterEle.FormattingEnabled = true;
            this.comboBoxNameParameterEle.Location = new System.Drawing.Point(127, 21);
            this.comboBoxNameParameterEle.Name = "comboBoxNameParameterEle";
            this.comboBoxNameParameterEle.Size = new System.Drawing.Size(257, 21);
            this.comboBoxNameParameterEle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name Parameter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value of Parameter:";
            // 
            // textBoxValueParameterEle
            // 
            this.textBoxValueParameterEle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxValueParameterEle.Location = new System.Drawing.Point(127, 54);
            this.textBoxValueParameterEle.Name = "textBoxValueParameterEle";
            this.textBoxValueParameterEle.Size = new System.Drawing.Size(257, 20);
            this.textBoxValueParameterEle.TabIndex = 2;
            // 
            // radioButtonNormalText
            // 
            this.radioButtonNormalText.AutoSize = true;
            this.radioButtonNormalText.Checked = true;
            this.radioButtonNormalText.Location = new System.Drawing.Point(27, 19);
            this.radioButtonNormalText.Name = "radioButtonNormalText";
            this.radioButtonNormalText.Size = new System.Drawing.Size(58, 17);
            this.radioButtonNormalText.TabIndex = 1;
            this.radioButtonNormalText.TabStop = true;
            this.radioButtonNormalText.Text = "Normal";
            this.radioButtonNormalText.UseVisualStyleBackColor = true;
            // 
            // frmParameterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 302);
            this.Controls.Add(this.btnParameterSetValue);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParameterSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmParameterSet";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radioButtonInEntireProject;
        public System.Windows.Forms.RadioButton radioButtonInSelectionView;
        public System.Windows.Forms.RadioButton radioButtonUpperText;
        public System.Windows.Forms.RadioButton radioButtonLowerText;
        public System.Windows.Forms.RadioButton radioButtonSentenceText;
        public System.Windows.Forms.RadioButton radioButtonTitleText;
        public System.Windows.Forms.RadioButton radioButtonNormalText;
        public System.Windows.Forms.ComboBox comboBoxNameParameterEle;
        public System.Windows.Forms.TextBox textBoxValueParameterEle;
        public System.Windows.Forms.Button btnParameterSetValue;
    }
}