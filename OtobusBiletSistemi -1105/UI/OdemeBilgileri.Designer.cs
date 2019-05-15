namespace UI
{
    partial class OdemeBilgileri
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYillar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKartUzerindekiIsim = new System.Windows.Forms.TextBox();
            this.txtKartNumarasi = new System.Windows.Forms.TextBox();
            this.txtCvvKodu = new System.Windows.Forms.TextBox();
            this.rdbVisa = new System.Windows.Forms.RadioButton();
            this.rdbMasterCard = new System.Windows.Forms.RadioButton();
            this.cmbAylar = new System.Windows.Forms.ComboBox();
            this.lblToplamUcret = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOdemeYap = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYillar);
            this.groupBox1.Controls.Add(this.cmbAylar);
            this.groupBox1.Controls.Add(this.rdbMasterCard);
            this.groupBox1.Controls.Add(this.rdbVisa);
            this.groupBox1.Controls.Add(this.txtCvvKodu);
            this.groupBox1.Controls.Add(this.txtKartNumarasi);
            this.groupBox1.Controls.Add(this.txtKartUzerindekiIsim);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 335);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "grpOdemeBilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kartın Üzerindeki İsim";
            // 
            // cmbYillar
            // 
            this.cmbYillar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYillar.FormattingEnabled = true;
            this.cmbYillar.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbYillar.Location = new System.Drawing.Point(72, 182);
            this.cmbYillar.Name = "cmbYillar";
            this.cmbYillar.Size = new System.Drawing.Size(78, 21);
            this.cmbYillar.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kart Numarası";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(7, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Son Kullanma Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cvv Kodu";
            // 
            // txtKartUzerindekiIsim
            // 
            this.txtKartUzerindekiIsim.Location = new System.Drawing.Point(8, 41);
            this.txtKartUzerindekiIsim.Name = "txtKartUzerindekiIsim";
            this.txtKartUzerindekiIsim.Size = new System.Drawing.Size(258, 20);
            this.txtKartUzerindekiIsim.TabIndex = 12;
            // 
            // txtKartNumarasi
            // 
            this.txtKartNumarasi.Location = new System.Drawing.Point(9, 108);
            this.txtKartNumarasi.MaxLength = 16;
            this.txtKartNumarasi.Name = "txtKartNumarasi";
            this.txtKartNumarasi.Size = new System.Drawing.Size(258, 20);
            this.txtKartNumarasi.TabIndex = 11;
            // 
            // txtCvvKodu
            // 
            this.txtCvvKodu.Location = new System.Drawing.Point(9, 252);
            this.txtCvvKodu.MaxLength = 3;
            this.txtCvvKodu.Name = "txtCvvKodu";
            this.txtCvvKodu.Size = new System.Drawing.Size(58, 20);
            this.txtCvvKodu.TabIndex = 10;
            // 
            // rdbVisa
            // 
            this.rdbVisa.AutoSize = true;
            this.rdbVisa.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbVisa.Location = new System.Drawing.Point(119, 308);
            this.rdbVisa.Name = "rdbVisa";
            this.rdbVisa.Size = new System.Drawing.Size(50, 20);
            this.rdbVisa.TabIndex = 14;
            this.rdbVisa.TabStop = true;
            this.rdbVisa.Text = "Visa";
            this.rdbVisa.UseVisualStyleBackColor = true;
            // 
            // rdbMasterCard
            // 
            this.rdbMasterCard.AutoSize = true;
            this.rdbMasterCard.Checked = true;
            this.rdbMasterCard.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbMasterCard.Location = new System.Drawing.Point(8, 307);
            this.rdbMasterCard.Name = "rdbMasterCard";
            this.rdbMasterCard.Size = new System.Drawing.Size(97, 20);
            this.rdbMasterCard.TabIndex = 13;
            this.rdbMasterCard.TabStop = true;
            this.rdbMasterCard.Text = "Master Card";
            this.rdbMasterCard.UseVisualStyleBackColor = true;
            // 
            // cmbAylar
            // 
            this.cmbAylar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAylar.FormattingEnabled = true;
            this.cmbAylar.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbAylar.Location = new System.Drawing.Point(10, 182);
            this.cmbAylar.Name = "cmbAylar";
            this.cmbAylar.Size = new System.Drawing.Size(52, 21);
            this.cmbAylar.TabIndex = 17;
            // 
            // lblToplamUcret
            // 
            this.lblToplamUcret.AutoSize = true;
            this.lblToplamUcret.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamUcret.Location = new System.Drawing.Point(124, 369);
            this.lblToplamUcret.Name = "lblToplamUcret";
            this.lblToplamUcret.Size = new System.Drawing.Size(32, 18);
            this.lblToplamUcret.TabIndex = 8;
            this.lblToplamUcret.Text = " TL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Toplam Ücret: ";
            // 
            // btnOdemeYap
            // 
            this.btnOdemeYap.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnOdemeYap.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOdemeYap.ForeColor = System.Drawing.Color.White;
            this.btnOdemeYap.Location = new System.Drawing.Point(162, 354);
            this.btnOdemeYap.Name = "btnOdemeYap";
            this.btnOdemeYap.Size = new System.Drawing.Size(117, 47);
            this.btnOdemeYap.TabIndex = 6;
            this.btnOdemeYap.Text = "ÖDEME YAP VE BİTİR";
            this.btnOdemeYap.UseVisualStyleBackColor = false;
            // 
            // OdemeBilgileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 411);
            this.Controls.Add(this.lblToplamUcret);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOdemeYap);
            this.Controls.Add(this.groupBox1);
            this.Name = "OdemeBilgileri";
            this.Text = "OdemeBilgileri";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbYillar;
        private System.Windows.Forms.ComboBox cmbAylar;
        public System.Windows.Forms.RadioButton rdbMasterCard;
        public System.Windows.Forms.RadioButton rdbVisa;
        public System.Windows.Forms.TextBox txtCvvKodu;
        public System.Windows.Forms.TextBox txtKartNumarasi;
        public System.Windows.Forms.TextBox txtKartUzerindekiIsim;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblToplamUcret;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnOdemeYap;
    }
}