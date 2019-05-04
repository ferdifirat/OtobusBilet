namespace UI
{
    partial class Cinsiyet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cinsiyet));
            this.btnKadin = new System.Windows.Forms.Button();
            this.btnErkek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKadin
            // 
            this.btnKadin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnKadin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKadin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKadin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKadin.Image = ((System.Drawing.Image)(resources.GetObject("btnKadin.Image")));
            this.btnKadin.Location = new System.Drawing.Point(185, 12);
            this.btnKadin.Name = "btnKadin";
            this.btnKadin.Size = new System.Drawing.Size(156, 164);
            this.btnKadin.TabIndex = 1;
            this.btnKadin.UseVisualStyleBackColor = false;
            // 
            // btnErkek
            // 
            this.btnErkek.Image = ((System.Drawing.Image)(resources.GetObject("btnErkek.Image")));
            this.btnErkek.Location = new System.Drawing.Point(12, 12);
            this.btnErkek.Name = "btnErkek";
            this.btnErkek.Size = new System.Drawing.Size(156, 164);
            this.btnErkek.TabIndex = 2;
            this.btnErkek.UseVisualStyleBackColor = true;
            // 
            // Cinsiyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 181);
            this.Controls.Add(this.btnKadin);
            this.Controls.Add(this.btnErkek);
            this.Name = "Cinsiyet";
            this.Text = "Cinsiyet";
            this.Load += new System.EventHandler(this.Cinsiyet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKadin;
        private System.Windows.Forms.Button btnErkek;
    }
}