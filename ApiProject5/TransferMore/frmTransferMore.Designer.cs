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
            this.radioButtonCheckAllTransfer = new System.Windows.Forms.RadioButton();
            this.radioButtonCheckNoneTransfer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFromProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Option1 = new System.Windows.Forms.GroupBox();
            this.radioButtonOnDuplicate = new System.Windows.Forms.RadioButton();
            this.radioButtonAbortDuplicate = new System.Windows.Forms.RadioButton();
            this.radioButtonAskUser = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewProjectTo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Option1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewElementTransfer
            // 
            this.treeViewElementTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewElementTransfer.Location = new System.Drawing.Point(12, 33);
            this.treeViewElementTransfer.Name = "treeViewElementTransfer";
            this.treeViewElementTransfer.Size = new System.Drawing.Size(423, 380);
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
            // radioButtonCheckAllTransfer
            // 
            this.radioButtonCheckAllTransfer.AutoSize = true;
            this.radioButtonCheckAllTransfer.Checked = true;
            this.radioButtonCheckAllTransfer.Location = new System.Drawing.Point(347, 9);
            this.radioButtonCheckAllTransfer.Name = "radioButtonCheckAllTransfer";
            this.radioButtonCheckAllTransfer.Size = new System.Drawing.Size(36, 17);
            this.radioButtonCheckAllTransfer.TabIndex = 2;
            this.radioButtonCheckAllTransfer.TabStop = true;
            this.radioButtonCheckAllTransfer.Text = "All";
            this.radioButtonCheckAllTransfer.UseVisualStyleBackColor = true;
            // 
            // radioButtonCheckNoneTransfer
            // 
            this.radioButtonCheckNoneTransfer.AutoSize = true;
            this.radioButtonCheckNoneTransfer.Location = new System.Drawing.Point(389, 9);
            this.radioButtonCheckNoneTransfer.Name = "radioButtonCheckNoneTransfer";
            this.radioButtonCheckNoneTransfer.Size = new System.Drawing.Size(51, 17);
            this.radioButtonCheckNoneTransfer.TabIndex = 2;
            this.radioButtonCheckNoneTransfer.Text = "None";
            this.radioButtonCheckNoneTransfer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // comboBoxFromProject
            // 
            this.comboBoxFromProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxFromProject.FormattingEnabled = true;
            this.comboBoxFromProject.Location = new System.Drawing.Point(198, 435);
            this.comboBoxFromProject.Name = "comboBoxFromProject";
            this.comboBoxFromProject.Size = new System.Drawing.Size(237, 21);
            this.comboBoxFromProject.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Count element selected:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 424);
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
            this.Option1.Location = new System.Drawing.Point(15, 445);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(158, 89);
            this.Option1.TabIndex = 6;
            this.Option1.TabStop = false;
            this.Option1.Text = "Option";
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
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 467);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "To:";
            // 
            // listViewProjectTo
            // 
            this.listViewProjectTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProjectTo.AutoArrange = false;
            this.listViewProjectTo.CheckBoxes = true;
            this.listViewProjectTo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewProjectTo.HideSelection = false;
            this.listViewProjectTo.Location = new System.Drawing.Point(225, 467);
            this.listViewProjectTo.Name = "listViewProjectTo";
            this.listViewProjectTo.Size = new System.Drawing.Size(210, 86);
            this.listViewProjectTo.TabIndex = 7;
            this.listViewProjectTo.UseCompatibleStateImageBehavior = false;
            this.listViewProjectTo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name Project";
            this.columnHeader1.Width = 400;
            // 
            // frmTransferMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 565);
            this.Controls.Add(this.listViewProjectTo);
            this.Controls.Add(this.Option1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxFromProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonCheckNoneTransfer);
            this.Controls.Add(this.radioButtonCheckAllTransfer);
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
        public System.Windows.Forms.RadioButton radioButtonCheckAllTransfer;
        public System.Windows.Forms.RadioButton radioButtonCheckNoneTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Option1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ListView listViewProjectTo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ComboBox comboBoxFromProject;
        public System.Windows.Forms.RadioButton radioButtonOnDuplicate;
        public System.Windows.Forms.RadioButton radioButtonAbortDuplicate;
        public System.Windows.Forms.RadioButton radioButtonAskUser;
        public System.Windows.Forms.TreeView treeViewElementTransfer;
    }
}