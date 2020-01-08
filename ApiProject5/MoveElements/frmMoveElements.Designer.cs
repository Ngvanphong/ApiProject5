namespace ApiProject5.MoveElements
{
    partial class frmMoveElements
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDistanceX = new System.Windows.Forms.TextBox();
            this.textBoxDistanceY = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDistanceZ = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Distance X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Distance Y:";
            // 
            // textBoxDistanceX
            // 
            this.textBoxDistanceX.Location = new System.Drawing.Point(80, 7);
            this.textBoxDistanceX.Name = "textBoxDistanceX";
            this.textBoxDistanceX.Size = new System.Drawing.Size(202, 20);
            this.textBoxDistanceX.TabIndex = 1;
            this.textBoxDistanceX.Text = "0";
            // 
            // textBoxDistanceY
            // 
            this.textBoxDistanceY.Location = new System.Drawing.Point(80, 31);
            this.textBoxDistanceY.Name = "textBoxDistanceY";
            this.textBoxDistanceY.Size = new System.Drawing.Size(202, 20);
            this.textBoxDistanceY.TabIndex = 1;
            this.textBoxDistanceY.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Distance Z:";
            // 
            // textBoxDistanceZ
            // 
            this.textBoxDistanceZ.Location = new System.Drawing.Point(80, 57);
            this.textBoxDistanceZ.Name = "textBoxDistanceZ";
            this.textBoxDistanceZ.Size = new System.Drawing.Size(202, 20);
            this.textBoxDistanceZ.TabIndex = 1;
            this.textBoxDistanceZ.Text = "0";
            // 
            // frmMoveElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 119);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDistanceZ);
            this.Controls.Add(this.textBoxDistanceY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDistanceX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMoveElements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMoveElements";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMoveElements_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxDistanceX;
        public System.Windows.Forms.TextBox textBoxDistanceY;
        public System.Windows.Forms.TextBox textBoxDistanceZ;
    }
}