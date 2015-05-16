namespace BigIP
{
    partial class BigIP
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
            this.Address = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 144F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.Location = new System.Drawing.Point(0, 0);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(979, 272);
            this.Address.TabIndex = 0;
            this.Address.Text = "256.256";
            this.Address.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Address.DoubleClick += new System.EventHandler(this.Address_DoubleClick);
            // 
            // BigIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(666, 186);
            this.ControlBox = false;
            this.Controls.Add(this.Address);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "BigIP";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Big IP";
            this.Activated += new System.EventHandler(this.OnActivated);
            this.Deactivate += new System.EventHandler(this.BigIP_Deactivate);
            this.DoubleClick += new System.EventHandler(this.BigIP_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Address;
    }
}

