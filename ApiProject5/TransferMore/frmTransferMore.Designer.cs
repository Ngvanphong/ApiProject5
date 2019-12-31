namespace ApiProject5.TransferMore
{
    partial class frmTransferMore
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
            this.treeViewElementTransfer = new System.Windows.Forms.TreeView();
            this.btnShowAllTransfer = new System.Windows.Forms.Button();
            this.btnHideTransfer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxToProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Option1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAskUser = new System.Windows.Forms.RadioButton();
            this.radioButtonAbortDuplicate = new System.Windows.Forms.RadioButton();
            this.radioButtonOnDuplicate = new System.Windows.Forms.RadioButton();
            this.checkBoxAllOrNonetra = new System.Windows.Forms.CheckBox();
            this.btnTransferOK = new System.Windows.Forms.Button();
            this.Option1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewElementTransfer
            // 
            this.treeViewElementTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewElementTransfer.CheckBoxes = true;
            this.treeViewElementTransfer.Location = new System.Drawing.Point(12, 33);
            this.treeViewElementTransfer.Name = "treeViewElementTransfer";
            this.treeViewElementTransfer.Size = new System.Drawing.Size(423, 405);
            this.treeViewElementTransfer.TabIndex = 0;
            // 
            // btnShowAllTransfer
            // 
            this.btnShowAllTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowAllTransfer.Location = new System.Drawing.Point(223, 6);
            this.btnShowAllTransfer.Name = "btnShowAllTransfer";
            this.btnShowAllTransfer.Size = new System.Drawing.Size(56, 23);
            this.btnShowAllTransfer.TabIndex = 1;
            this.btnShowAllTransfer.Text = "Show";
            this.btnShowAllTransfer.UseVisualStyleBackColor = true;
            // 
            // btnHideTransfer
            // 
            this.btnHideTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHideTransfer.Location = new System.Drawing.Point(285, 6);
            this.btnHideTransfer.Name = "btnHideTransfer";
            this.btnHideTransfer.Size = new System.Drawing.Size(56, 23);
            this.btnHideTransfer.TabIndex = 1;
            this.btnHideTransfer.Text = "Hide";
            this.btnHideTransfer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxToProject
            // 
            this.comboBoxToProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxToProject.FormattingEnabled = true;
            this.comboBoxToProject.Location = new System.Drawing.Point(196, 476);
            this.comboBoxToProject.Name = "comboBoxToProject";
            this.comboBoxToProject.Size = new System.Drawing.Size(237, 21);
            this.comboBoxToProject.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Count element selected:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "0";
            // 
            // Option1
            // 
            this.Option1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Option1.Controls.Add(this.radioButtonAskUser);
            this.Option1.Controls.Add(this.radioButtonAbortDuplicate);
            this.Option1.Controls.Add(this.radioButtonOnDuplicate);
            this.Option1.Location = new System.Drawing.Point(12, 444);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(145, 89);
            this.Option1.TabIndex = 6;
            this.Option1.TabStop = false;
            this.Option1.Text = "Option";
            // 
            // radioButtonAskUser
            // 
            this.radioButtonAskUser.AutoSize = true;
            this.radioButtonAskUser.Location = new System.Drawing.Point(6, 66);
            this.radioButtonAskUser.Name = "radioButtonAskUser";
            this.radioButtonAskUser.Size = new System.Drawing.Size(68, 17);
            this.radioButtonAskUser.TabIndex = 0;
            this.radioButtonAskUser.Text = "Ask User";
            this.radioButtonAskUser.UseVisualStyleBackColor = true;
            // 
            // radioButtonAbortDuplicate
            // 
            this.radioButtonAbortDuplicate.AutoSize = true;
            this.radioButtonAbortDuplicate.Location = new System.Drawing.Point(6, 43);
            this.radioButtonAbortDuplicate.Name = "radioButtonAbortDuplicate";
            this.radioButtonAbortDuplicate.Size = new System.Drawing.Size(113, 17);
            this.radioButtonAbortDuplicate.TabIndex = 0;
            this.radioButtonAbortDuplicate.Text = "Abort on Duplicate";
            this.radioButtonAbortDuplicate.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnDuplicate
            // 
            this.radioButtonOnDuplicate.AutoSize = true;
            this.radioButtonOnDuplicate.Checked = true;
            this.radioButtonOnDuplicate.Location = new System.Drawing.Point(7, 20);
            this.radioButtonOnDuplicate.Name = "radioButtonOnDuplicate";
            this.radioButtonOnDuplicate.Size = new System.Drawing.Size(107, 17);
            this.radioButtonOnDuplicate.TabIndex = 0;
            this.radioButtonOnDuplicate.TabStop = true;
            this.radioButtonOnDuplicate.Text = "Ok on Duplicates";
            this.radioButtonOnDuplicate.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllOrNonetra
            // 
            this.checkBoxAllOrNonetra.AutoSize = true;
            this.checkBoxAllOrNonetra.Location = new System.Drawing.Point(355, 10);
            this.checkBoxAllOrNonetra.Name = "checkBoxAllOrNonetra";
            this.checkBoxAllOrNonetra.Size = new System.Drawing.Size(78, 17);
            this.checkBoxAllOrNonetra.TabIndex = 8;
            this.checkBoxAllOrNonetra.Text = "All or None";
            this.checkBoxAllOrNonetra.UseVisualStyleBackColor = true;
            // 
            // btnTransferOK
            // 
            this.btnTransferOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransferOK.Location = new System.Drawing.Point(358, 505);
            this.btnTransferOK.Name = "btnTransferOK";
            this.btnTransferOK.Size = new System.Drawing.Size(75, 29);
            this.btnTransferOK.TabIndex = 9;
            this.btnTransferOK.Text = "Transfer";
            this.btnTransferOK.UseVisualStyleBackColor = true;
            this.btnTransferOK.Click += new System.EventHandler(this.btnTransferOK_Click);
            // 
            // frmTransferMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 544);
            this.Controls.Add(this.btnTransferOK);
            this.Controls.Add(this.checkBoxAllOrNonetra);
            this.Controls.Add(this.Option1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxToProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHideTransfer);
            this.Controls.Add(this.btnShowAllTransfer);
            this.Controls.Add(this.treeViewElementTransfer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTransferMore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTransferMore";
            this.TopMost = true;
            this.Option1.ResumeLayout(false);
            this.Option1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnShowAllTransfer;
        public System.Windows.Forms.Button btnHideTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Option1;
        public System.Windows.Forms.ComboBox comboBoxToProject;
        public System.Windows.Forms.RadioButton radioButtonOnDuplicate;
        public System.Windows.Forms.RadioButton radioButtonAbortDuplicate;
        public System.Windows.Forms.RadioButton radioButtonAskUser;
        public System.Windows.Forms.TreeView treeViewElementTransfer;
        public System.Windows.Forms.CheckBox checkBoxAllOrNonetra;
        public System.Windows.Forms.Button btnTransferOK;
    }
}