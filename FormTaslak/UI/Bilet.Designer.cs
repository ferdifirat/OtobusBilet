namespace UI
{
    partial class Bilet
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
            this.rdoSatis = new System.Windows.Forms.RadioButton();
            this.rdoRezarvasyon = new System.Windows.Forms.RadioButton();
            this.rdoTekYon = new System.Windows.Forms.RadioButton();
            this.rdoGidisDonus = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNereye = new System.Windows.Forms.ComboBox();
            this.cmbNereden = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpGidis = new System.Windows.Forms.DateTimePicker();
            this.dtpDonus = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.nudYolcuSayisi = new System.Windows.Forms.NumericUpDown();
            this.btnAra = new System.Windows.Forms.Button();
            this.lblMusteri = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudYolcuSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoSatis
            // 
            this.rdoSatis.AutoSize = true;
            this.rdoSatis.Location = new System.Drawing.Point(75, 46);
            this.rdoSatis.Name = "rdoSatis";
            this.rdoSatis.Size = new System.Drawing.Size(48, 17);
            this.rdoSatis.TabIndex = 0;
            this.rdoSatis.TabStop = true;
            this.rdoSatis.Text = "Satış";
            this.rdoSatis.UseVisualStyleBackColor = true;
            // 
            // rdoRezarvasyon
            // 
            this.rdoRezarvasyon.AutoSize = true;
            this.rdoRezarvasyon.Location = new System.Drawing.Point(171, 46);
            this.rdoRezarvasyon.Name = "rdoRezarvasyon";
            this.rdoRezarvasyon.Size = new System.Drawing.Size(87, 17);
            this.rdoRezarvasyon.TabIndex = 0;
            this.rdoRezarvasyon.TabStop = true;
            this.rdoRezarvasyon.Text = "Rezarvasyon";
            this.rdoRezarvasyon.UseVisualStyleBackColor = true;
            // 
            // rdoTekYon
            // 
            this.rdoTekYon.AutoSize = true;
            this.rdoTekYon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoTekYon.Location = new System.Drawing.Point(197, 183);
            this.rdoTekYon.Name = "rdoTekYon";
            this.rdoTekYon.Size = new System.Drawing.Size(73, 17);
            this.rdoTekYon.TabIndex = 0;
            this.rdoTekYon.TabStop = true;
            this.rdoTekYon.Text = "Tek Yön";
            this.rdoTekYon.UseVisualStyleBackColor = true;
            // 
            // rdoGidisDonus
            // 
            this.rdoGidisDonus.AutoSize = true;
            this.rdoGidisDonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoGidisDonus.Location = new System.Drawing.Point(85, 183);
            this.rdoGidisDonus.Name = "rdoGidisDonus";
            this.rdoGidisDonus.Size = new System.Drawing.Size(93, 17);
            this.rdoGidisDonus.TabIndex = 0;
            this.rdoGidisDonus.TabStop = true;
            this.rdoGidisDonus.Text = "Gidiş-Dönüş";
            this.rdoGidisDonus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nereden";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nereye";
            // 
            // cmbNereye
            // 
            this.cmbNereye.FormattingEnabled = true;
            this.cmbNereye.Location = new System.Drawing.Point(338, 121);
            this.cmbNereye.Name = "cmbNereye";
            this.cmbNereye.Size = new System.Drawing.Size(169, 21);
            this.cmbNereye.TabIndex = 2;
            // 
            // cmbNereden
            // 
            this.cmbNereden.FormattingEnabled = true;
            this.cmbNereden.Location = new System.Drawing.Point(75, 121);
            this.cmbNereden.Name = "cmbNereden";
            this.cmbNereden.Size = new System.Drawing.Size(169, 21);
            this.cmbNereden.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gidiş Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dönüş Tarihi";
            // 
            // dtpGidis
            // 
            this.dtpGidis.Location = new System.Drawing.Point(63, 256);
            this.dtpGidis.Name = "dtpGidis";
            this.dtpGidis.Size = new System.Drawing.Size(200, 20);
            this.dtpGidis.TabIndex = 3;
            // 
            // dtpDonus
            // 
            this.dtpDonus.Location = new System.Drawing.Point(326, 256);
            this.dtpDonus.Name = "dtpDonus";
            this.dtpDonus.Size = new System.Drawing.Size(200, 20);
            this.dtpDonus.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yolcu Sayısı";
            // 
            // nudYolcuSayisi
            // 
            this.nudYolcuSayisi.Location = new System.Drawing.Point(63, 341);
            this.nudYolcuSayisi.Name = "nudYolcuSayisi";
            this.nudYolcuSayisi.Size = new System.Drawing.Size(45, 20);
            this.nudYolcuSayisi.TabIndex = 4;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(415, 335);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(111, 29);
            this.btnAra.TabIndex = 5;
            this.btnAra.Text = "Bilet Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            // 
            // lblMusteri
            // 
            this.lblMusteri.AutoSize = true;
            this.lblMusteri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMusteri.Location = new System.Drawing.Point(242, 9);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new System.Drawing.Size(2, 15);
            this.lblMusteri.TabIndex = 6;
            // 
            // Bilet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 377);
            this.Controls.Add(this.lblMusteri);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.nudYolcuSayisi);
            this.Controls.Add(this.dtpDonus);
            this.Controls.Add(this.dtpGidis);
            this.Controls.Add(this.cmbNereden);
            this.Controls.Add(this.cmbNereye);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoGidisDonus);
            this.Controls.Add(this.rdoTekYon);
            this.Controls.Add(this.rdoRezarvasyon);
            this.Controls.Add(this.rdoSatis);
            this.Name = "Bilet";
            this.Text = "Bilet";
            ((System.ComponentModel.ISupportInitialize)(this.nudYolcuSayisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoSatis;
        private System.Windows.Forms.RadioButton rdoRezarvasyon;
        private System.Windows.Forms.RadioButton rdoTekYon;
        private System.Windows.Forms.RadioButton rdoGidisDonus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNereye;
        private System.Windows.Forms.ComboBox cmbNereden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpGidis;
        private System.Windows.Forms.DateTimePicker dtpDonus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudYolcuSayisi;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label lblMusteri;
    }
}