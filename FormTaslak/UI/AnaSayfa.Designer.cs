namespace UI
{
    partial class AnaSayfa
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.üyeGirişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üyeOlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biletAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otobusBiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seferBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cıkısToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üyeOlToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.üyeGirişiToolStripMenuItem,
            this.biletAlToolStripMenuItem,
            this.otobusBiToolStripMenuItem,
            this.seferBilgileriToolStripMenuItem,
            this.cıkısToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // üyeGirişiToolStripMenuItem
            // 
            this.üyeGirişiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.üyeOlToolStripMenuItem,
            this.üyeOlToolStripMenuItem1});
            this.üyeGirişiToolStripMenuItem.Name = "üyeGirişiToolStripMenuItem";
            this.üyeGirişiToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.üyeGirişiToolStripMenuItem.Text = "Üye İşlemleri";
            // 
            // üyeOlToolStripMenuItem
            // 
            this.üyeOlToolStripMenuItem.Name = "üyeOlToolStripMenuItem";
            this.üyeOlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.üyeOlToolStripMenuItem.Text = "Üye Girişi";
            // 
            // biletAlToolStripMenuItem
            // 
            this.biletAlToolStripMenuItem.Name = "biletAlToolStripMenuItem";
            this.biletAlToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.biletAlToolStripMenuItem.Text = "Bilet Al";
            // 
            // otobusBiToolStripMenuItem
            // 
            this.otobusBiToolStripMenuItem.Name = "otobusBiToolStripMenuItem";
            this.otobusBiToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.otobusBiToolStripMenuItem.Text = "Otobus Bilgileri";
            // 
            // seferBilgileriToolStripMenuItem
            // 
            this.seferBilgileriToolStripMenuItem.Name = "seferBilgileriToolStripMenuItem";
            this.seferBilgileriToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.seferBilgileriToolStripMenuItem.Text = "Sefer Bilgileri";
            // 
            // cıkısToolStripMenuItem
            // 
            this.cıkısToolStripMenuItem.Name = "cıkısToolStripMenuItem";
            this.cıkısToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.cıkısToolStripMenuItem.Text = "Cıkıs";
            // 
            // üyeOlToolStripMenuItem1
            // 
            this.üyeOlToolStripMenuItem1.Name = "üyeOlToolStripMenuItem1";
            this.üyeOlToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.üyeOlToolStripMenuItem1.Text = "Üye Ol";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 398);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 422);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaSayfa";
            this.Text = "AnaSayfa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem üyeGirişiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem biletAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otobusBiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seferBilgileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cıkısToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üyeOlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üyeOlToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}