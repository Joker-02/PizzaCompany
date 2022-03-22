namespace PizzaCompany
{
    partial class MenuForm
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
            this.LEmp = new System.Windows.Forms.Label();
            this.lProduct = new System.Windows.Forms.Label();
            this.lOrder = new System.Windows.Forms.Label();
            this.lExit = new System.Windows.Forms.Label();
            this.LReport = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LEmp
            // 
            this.LEmp.AutoSize = true;
            this.LEmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LEmp.Font = new System.Drawing.Font("Khmer OS Battambang", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEmp.Location = new System.Drawing.Point(263, 9);
            this.LEmp.Name = "LEmp";
            this.LEmp.Size = new System.Drawing.Size(94, 41);
            this.LEmp.TabIndex = 0;
            this.LEmp.Text = "បុគ្គលិក";
            // 
            // lProduct
            // 
            this.lProduct.AutoSize = true;
            this.lProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lProduct.Font = new System.Drawing.Font("Khmer OS Battambang", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProduct.Location = new System.Drawing.Point(28, 9);
            this.lProduct.Name = "lProduct";
            this.lProduct.Size = new System.Drawing.Size(104, 41);
            this.lProduct.TabIndex = 1;
            this.lProduct.Text = "Product";
            // 
            // lOrder
            // 
            this.lOrder.AutoSize = true;
            this.lOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lOrder.Font = new System.Drawing.Font("Khmer OS Battambang", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOrder.Location = new System.Drawing.Point(164, 9);
            this.lOrder.Name = "lOrder";
            this.lOrder.Size = new System.Drawing.Size(83, 41);
            this.lOrder.TabIndex = 3;
            this.lOrder.Text = "Order";
            // 
            // lExit
            // 
            this.lExit.AutoSize = true;
            this.lExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lExit.Font = new System.Drawing.Font("Khmer OS Battambang", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExit.Location = new System.Drawing.Point(504, 9);
            this.lExit.Name = "lExit";
            this.lExit.Size = new System.Drawing.Size(60, 41);
            this.lExit.TabIndex = 4;
            this.lExit.Text = "Exit";
            // 
            // LReport
            // 
            this.LReport.AutoSize = true;
            this.LReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LReport.Font = new System.Drawing.Font("Khmer OS Battambang", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LReport.Location = new System.Drawing.Point(389, 9);
            this.LReport.Name = "LReport";
            this.LReport.Size = new System.Drawing.Size(93, 41);
            this.LReport.TabIndex = 5;
            this.LReport.Text = "Report";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PizzaCompany.Properties.Resources.The_Pizza_Company_600x600;
            this.pictureBox1.Location = new System.Drawing.Point(214, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(620, 380);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Battambang", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(841, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 551);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LReport);
            this.Controls.Add(this.LEmp);
            this.Controls.Add(this.lProduct);
            this.Controls.Add(this.lExit);
            this.Controls.Add(this.lOrder);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LEmp;
        private System.Windows.Forms.Label lProduct;
        private System.Windows.Forms.Label lOrder;
        private System.Windows.Forms.Label lExit;
        private System.Windows.Forms.Label LReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}