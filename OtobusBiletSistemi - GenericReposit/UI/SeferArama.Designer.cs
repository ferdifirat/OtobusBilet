namespace UI
{
    partial class SeferArama
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
            this.btnListele = new System.Windows.Forms.Button();
            this.nmrYolcuSayisi = new System.Windows.Forms.NumericUpDown();
            this.dtpDonus = new System.Windows.Forms.DateTimePicker();
            this.dtpGidis = new System.Windows.Forms.DateTimePicker();
            this.cmbNereden = new System.Windows.Forms.ComboBox();
            this.cmbNereye = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoGidisDonus = new System.Windows.Forms.RadioButton();
            this.rdoTekYon = new System.Windows.Forms.RadioButton();
            this.rdoRezarvasyon = new System.Windows.Forms.RadioButton();
            this.rdoSatis = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmrYolcuSayisi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(379, 289);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(111, 29);
            this.btnListele.TabIndex = 21;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            // 
            // nmrYolcuSayisi
            // 
            this.nmrYolcuSayisi.Location = new System.Drawing.Point(51, 298);
            this.nmrYolcuSayisi.Name = "nmrYolcuSayisi";
            this.nmrYolcuSayisi.Size = new System.Drawing.Size(45, 20);
            this.nmrYolcuSayisi.TabIndex = 20;
            // 
            // dtpDonus
            // 
            this.dtpDonus.Location = new System.Drawing.Point(314, 213);
            this.dtpDonus.Name = "dtpDonus";
            this.dtpDonus.Size = new System.Drawing.Size(176, 20);
            this.dtpDonus.TabIndex = 18;
            // 
            // dtpGidis
            // 
            this.dtpGidis.Location = new System.Drawing.Point(51, 213);
            this.dtpGidis.Name = "dtpGidis";
            this.dtpGidis.Size = new System.Drawing.Size(168, 20);
            this.dtpGidis.TabIndex = 19;
            // 
            // cmbNereden
            // 
            this.cmbNereden.FormattingEnabled = true;
            this.cmbNereden.Location = new System.Drawing.Point(50, 105);
            this.cmbNereden.Name = "cmbNereden";
            this.cmbNereden.Size = new System.Drawing.Size(169, 21);
            this.cmbNereden.TabIndex = 16;
            // 
            // cmbNereye
            // 
            this.cmbNereye.FormattingEnabled = true;
            this.cmbNereye.Location = new System.Drawing.Point(313, 105);
            this.cmbNereye.Name = "cmbNereye";
            this.cmbNereye.Size = new System.Drawing.Size(169, 21);
            this.cmbNereye.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nereye";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Dönüş Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Yolcu Sayısı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Gidiş Tarihi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nereden";
            // 
            // rdoGidisDonus
            // 
            this.rdoGidisDonus.AutoSize = true;
            this.rdoGidisDonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoGidisDonus.Location = new System.Drawing.Point(101, 30);
            this.rdoGidisDonus.Name = "rdoGidisDonus";
            this.rdoGidisDonus.Size = new System.Drawing.Size(82, 17);
            this.rdoGidisDonus.TabIndex = 7;
            this.rdoGidisDonus.TabStop = true;
            this.rdoGidisDonus.Text = "Gidiş-Dönüş";
            this.rdoGidisDonus.UseVisualStyleBackColor = true;
            // 
            // rdoTekYon
            // 
            this.rdoTekYon.AutoSize = true;
            this.rdoTekYon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoTekYon.Location = new System.Drawing.Point(6, 30);
            this.rdoTekYon.Name = "rdoTekYon";
            this.rdoTekYon.Size = new System.Drawing.Size(66, 17);
            this.rdoTekYon.TabIndex = 8;
            this.rdoTekYon.TabStop = true;
            this.rdoTekYon.Text = "Tek Yön";
            this.rdoTekYon.UseVisualStyleBackColor = true;
            // 
            // rdoRezarvasyon
            // 
            this.rdoRezarvasyon.AutoSize = true;
            this.rdoRezarvasyon.Location = new System.Drawing.Point(102, 28);
            this.rdoRezarvasyon.Name = "rdoRezarvasyon";
            this.rdoRezarvasyon.Size = new System.Drawing.Size(87, 17);
            this.rdoRezarvasyon.TabIndex = 9;
            this.rdoRezarvasyon.TabStop = true;
            this.rdoRezarvasyon.Text = "Rezarvasyon";
            this.rdoRezarvasyon.UseVisualStyleBackColor = true;
            // 
            // rdoSatis
            // 
            this.rdoSatis.AutoSize = true;
            this.rdoSatis.Location = new System.Drawing.Point(6, 28);
            this.rdoSatis.Name = "rdoSatis";
            this.rdoSatis.Size = new System.Drawing.Size(48, 17);
            this.rdoSatis.TabIndex = 10;
            this.rdoSatis.TabStop = true;
            this.rdoSatis.Text = "Satış";
            this.rdoSatis.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSatis);
            this.groupBox1.Controls.Add(this.rdoRezarvasyon);
            this.groupBox1.Location = new System.Drawing.Point(50, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 65);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoTekYon);
            this.groupBox2.Controls.Add(this.rdoGidisDonus);
            this.groupBox2.Location = new System.Drawing.Point(296, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 65);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // SeferArama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.nmrYolcuSayisi);
            this.Controls.Add(this.dtpDonus);
            this.Controls.Add(this.dtpGidis);
            this.Controls.Add(this.cmbNereden);
            this.Controls.Add(this.cmbNereye);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SeferArama";
            this.Text = "SeferArama";
            this.Load += new System.EventHandler(this.SeferArama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrYolcuSayisi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.NumericUpDown nmrYolcuSayisi;
        private System.Windows.Forms.DateTimePicker dtpDonus;
        private System.Windows.Forms.DateTimePicker dtpGidis;
        private System.Windows.Forms.ComboBox cmbNereden;
        private System.Windows.Forms.ComboBox cmbNereye;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoGidisDonus;
        private System.Windows.Forms.RadioButton rdoTekYon;
        private System.Windows.Forms.RadioButton rdoRezarvasyon;
        private System.Windows.Forms.RadioButton rdoSatis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}