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
            this.btnTransferOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewElementTransfer
            // 
            this.treeViewElementTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewElementTransfer.CheckBoxes = true;
            this.treeViewElementTransfer.Location = new System.Drawing.Point(12, 35);
            this.treeViewElementTransfer.Name = "treeViewElementTransfer";
            this.treeViewElementTransfer.Size = new System.Drawing.Size(423, 462);
            this.treeViewElementTransfer.TabIndex = 0;
            this.treeViewElementTransfer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewElementTransfer_AfterCheck);
            // 
            // btnShowAllTransfer
            // 
            this.btnShowAllTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowAllTransfer.Location = new System.Drawing.Point(317, 6);
            this.btnShowAllTransfer.Name = "btnShowAllTransfer";
            this.btnShowAllTransfer.Size = new System.Drawing.Size(56, 23);
            this.btnShowAllTransfer.TabIndex = 1;
            this.btnShowAllTransfer.Text = "Show";
            this.btnShowAllTransfer.UseVisualStyleBackColor = true;
            this.btnShowAllTransfer.Click += new System.EventHandler(this.btnShowAllTransfer_Click);
            // 
            // btnHideTransfer
            // 
            this.btnHideTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHideTransfer.Location = new System.Drawing.Point(379, 6);
            this.btnHideTransfer.Name = "btnHideTransfer";
            this.btnHideTransfer.Size = new System.Drawing.Size(56, 23);
            this.btnHideTransfer.TabIndex = 1;
            this.btnHideTransfer.Text = "Hide";
            this.btnHideTransfer.UseVisualStyleBackColor = true;
            this.btnHideTransfer.Click += new System.EventHandler(this.btnHideTransfer_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 513);
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
            this.comboBoxToProject.Location = new System.Drawing.Point(41, 508);
            this.comboBoxToProject.Name = "comboBoxToProject";
            this.comboBoxToProject.Size = new System.Drawing.Size(313, 21);
            this.comboBoxToProject.TabIndex = 4;
            // 
            // btnTransferOK
            // 
            this.btnTransferOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransferOK.Location = new System.Drawing.Point(360, 503);
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
            this.Controls.Add(this.comboBoxToProject);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnShowAllTransfer;
        public System.Windows.Forms.Button btnHideTransfer;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxToProject;
        public System.Windows.Forms.TreeView treeViewElementTransfer;
        public System.Windows.Forms.Button btnTransferOK;
    }
}