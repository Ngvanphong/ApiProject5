namespace ApiProject5.DynamoModel
{
    partial class frmDynamoModel
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
            this.dataGridViewPoint = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSelectLinepoint = new System.Windows.Forms.Button();
            this.buttonExportExcelPoint = new System.Windows.Forms.Button();
            this.btnContinueMainLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPoint
            // 
            this.dataGridViewPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Z,
            this.Index});
            this.dataGridViewPoint.Location = new System.Drawing.Point(203, 12);
            this.dataGridViewPoint.Name = "dataGridViewPoint";
            this.dataGridViewPoint.Size = new System.Drawing.Size(443, 776);
            this.dataGridViewPoint.TabIndex = 0;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            // 
            // Index
            // 
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            // 
            // buttonSelectLinepoint
            // 
            this.buttonSelectLinepoint.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectLinepoint.Name = "buttonSelectLinepoint";
            this.buttonSelectLinepoint.Size = new System.Drawing.Size(75, 29);
            this.buttonSelectLinepoint.TabIndex = 1;
            this.buttonSelectLinepoint.Text = "Select line";
            this.buttonSelectLinepoint.UseVisualStyleBackColor = true;
            this.buttonSelectLinepoint.Click += new System.EventHandler(this.buttonSelectLinepoint_Click);
            // 
            // buttonExportExcelPoint
            // 
            this.buttonExportExcelPoint.Location = new System.Drawing.Point(12, 47);
            this.buttonExportExcelPoint.Name = "buttonExportExcelPoint";
            this.buttonExportExcelPoint.Size = new System.Drawing.Size(75, 29);
            this.buttonExportExcelPoint.TabIndex = 1;
            this.buttonExportExcelPoint.Text = "Export excel";
            this.buttonExportExcelPoint.UseVisualStyleBackColor = true;
            this.buttonExportExcelPoint.Click += new System.EventHandler(this.buttonExportExcelPoint_Click);
            // 
            // btnContinueMainLine
            // 
            this.btnContinueMainLine.Location = new System.Drawing.Point(93, 12);
            this.btnContinueMainLine.Name = "btnContinueMainLine";
            this.btnContinueMainLine.Size = new System.Drawing.Size(104, 29);
            this.btnContinueMainLine.TabIndex = 5;
            this.btnContinueMainLine.Text = "Continue (MainL)";
            this.btnContinueMainLine.UseVisualStyleBackColor = true;
            this.btnContinueMainLine.Click += new System.EventHandler(this.btnContinueMainLine_Click);
            // 
            // frmDynamoModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 800);
            this.Controls.Add(this.btnContinueMainLine);
            this.Controls.Add(this.buttonExportExcelPoint);
            this.Controls.Add(this.buttonSelectLinepoint);
            this.Controls.Add(this.dataGridViewPoint);
            this.MinimizeBox = false;
            this.Name = "frmDynamoModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDynamoModel";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDynamoModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button buttonExportExcelPoint;
        public System.Windows.Forms.Button buttonSelectLinepoint;
        public System.Windows.Forms.Button btnContinueMainLine;
        public System.Windows.Forms.DataGridView dataGridViewPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
    }
}