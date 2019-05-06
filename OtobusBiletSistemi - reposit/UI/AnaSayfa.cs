﻿using Dal;
using Dal.Repository;
using Dal.UnitOfWork;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class AnaSayfa : Form
    {
        #region Initialize Properties
        private Context _dbContext;
        private IUnitOfWork _uow;
        private IRepository<Durak> _durakRepository;
        private IRepository<Kullanici> _kullaniciRepository;
        private IRepository<Rota> _rotaRepository;
        private IRepository<Sefer> _seferRepository;
        private IRepository<Otobus> _otobusRepository;
        private IRepository<OtobusTipi> _otobusTipiRepository;
        private IRepository<Bilet> _biletRepository;


        public Kullanici user = null;
        public List<Sefer> gidisSeferList = null;
        public List<Sefer> donusSeferList = null;
        public Sefer gidisSefer = null;
        public Sefer donusSefer = null;
        decimal yolcuSayisi;
        int yonSecimi = 1, otobusTipi = 1;

        #endregion

        public AnaSayfa()
        {
            InitializeComponent();
            InitializeConstructor();

        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            BaslangıcAyarları();
            DurakAraması();
        }

        private void InitializeConstructor()
        {
            _dbContext = new Context();
            _uow = new EFUnitOfWork(_dbContext);
            _durakRepository = new EFRepository<Durak>(_dbContext);
            _kullaniciRepository = new EFRepository<Kullanici>(_dbContext);
            _rotaRepository = new EFRepository<Rota>(_dbContext);
            _seferRepository = new EFRepository<Sefer>(_dbContext);
            _otobusRepository = new EFRepository<Otobus>(_dbContext);
            _otobusTipiRepository = new EFRepository<OtobusTipi>(_dbContext);
            _biletRepository = new EFRepository<Bilet>(_dbContext);

        }

        private void DurakAraması()
        {
            var duraklar = _durakRepository.GetAll().ToList();
            foreach (var i in duraklar)
            {
                var item = new ComboBoxItem()
                {
                    Text = i.DurakAdi,
                    Value = i.DurakID
                };
                cmbNereye.Items.Add(item);
                cmbNereden.Items.Add(item);
            }
        }

        private void BaslangıcAyarları()
        {
            rdoSatis.Checked = true;
            rdoTekYon.Checked = true;
            nmrYolcuSayisi.Minimum = 1;
            dtDonus.MinDate = DateTime.Now;
            dtGidis.MinDate = DateTime.Now;
            btnOturumuKapat.Visible = false;
        }

        private void rdoGidisDonus_CheckedChanged(object sender, EventArgs e)
        {
            dtDonus.Enabled = true;
        }

        private void rdoTekYon_CheckedChanged(object sender, EventArgs e)
        {
            dtDonus.Enabled = false;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (cmbNereden.SelectedItem == cmbNereye.SelectedItem)
            {
                MessageBox.Show("Lütfen birbirinden farklı kalkış ve varış şehirleri seçiniz..");
            }
            else
            {
                yolcuSayisi = nmrYolcuSayisi.Value;

                var kalkisDurak = GetValueOfCombobox(cmbNereden.SelectedItem);
                var varisDurak = GetValueOfCombobox(cmbNereye.SelectedItem);
                var cikisSaati = dtGidis.Value;

                var gidisTurListesi = new List<Sefer>();
                gidisTurListesi = TurListesi(kalkisDurak, varisDurak, cikisSaati);

                if (gidisTurListesi.Count > 0)
                {
                    gidisSeferList = gidisTurListesi;
                    tabControl2.SelectedIndex = 2;
                    yonSecimi = rdoGidisDonus.Checked ? 2 : yonSecimi;

                    if (yonSecimi == 2)
                    {
                        btnTekYonAra.Visible = false;
                        btnTekYonSecim.Visible = false;
                        var donusSaati = dtDonus.Value;
                        donusSeferList = TurListesi(varisDurak, kalkisDurak, donusSaati);
                    }

                    TurListesiniDoldur();
                }
            }
        }

        private List<Sefer> TurListesi(int kalkisDurak, int varisDurak, DateTime cikisSaati)
        {
            var turListe = new List<Sefer>();
            var rotaListesi = _rotaRepository.GetAll(x => x.CikisID == kalkisDurak && x.VarisID == varisDurak).ToList();

            var seferListe = _seferRepository.GetAll(x => x.CikisSaati > cikisSaati).ToList();
            //sıkıntılı Çıkış Saati>cikisSaati olacak


            foreach (var item in seferListe)
            {
                if (rotaListesi.Any(x => x.Id == item.RotaID))
                {
                    turListe.Add(item);
                }
            }
            return turListe;
        }

        private void TurListesiniDoldur()
        {
            dataGridGidis.DataSource = gidisSeferList;
            if (yonSecimi == 2)
            {
                dataGridDonus.DataSource = donusSeferList;
            }
            else
            {
                pnlDonus.Visible = false;
            }
        }

        private int GetValueOfCombobox(object selectedItem)
        {
            var selectedValue = (ComboBoxItem)selectedItem;
            return selectedValue.Value;
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            //BosDoluYapilmadi..
            UyeKayitEkrani uyeKayitEkrani = new UyeKayitEkrani(this);
            uyeKayitEkrani.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {


            var kullanici = _kullaniciRepository.Get(x => x.Email == txtMail.Text && x.Password == txtSifre.Text);

            if (kullanici == null)
            {
                MessageBox.Show("Bilgiler hatalı");

            }
            else
            {
                MessageBox.Show("Girişyapıldı");
                user = new Kullanici();
                user = kullanici;
                groupBox3.Enabled = false;
                btnOturumuKapat.Visible = true;
                //uyegirişienabled
                tabControl2.SelectedIndex = 1;
            }


        }

        private void btnOturumuKapat_Click(object sender, EventArgs e)
        {
            user = null;
            groupBox3.Enabled = true;

            txtMail.Text = "";
            txtSifre.Text = "";

        }

        private void btnTekYonSecim_Click(object sender, EventArgs e)
        {
            var seferId = dataGridGidis.Rows[0].Cells[0].Value;
            gidisSefer = _seferRepository.Get(x => x.Id == (int)seferId);
            var otobus = _otobusRepository.Get(x => x.Id == gidisSefer.OtobusID);
            otobusTipi = otobus.OtobusTipiID;
            KoltukSecimi(otobus);
        }

        private void KoltukSecimi(Otobus otobus)
        {
            tabControl2.SelectedIndex = 3;
            if (yonSecimi==1)
            {
                if (otobusTipi == 1)
                {
                    panelBusiness.Visible = false;
                    KoltuklariDoldur(otobus);
                }
                else
                {
                    panelClassic.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("lütfen");
            }
            
        }

        private void KoltuklariDoldur(Otobus otobus)
        {
            var biletler = _biletRepository.GetAll(x => x.SeferID == gidisSefer.Id).ToList();
            var koltukAdlari = otobus.OtobusTipiID == 1 ? "btnEkonomi" : "btnBusiness";

            foreach (var item in biletler)
            {
                var gender = _kullaniciRepository.Get(x => x.Id == item.KullaniciID).Gender;
                koltukAdlari = koltukAdlari + item.KoltukNo;
                Button button = this.Controls.Find(koltukAdlari, true).FirstOrDefault() as Button;

                if (button != null)
                {
                    button.BackColor = gender == true ? Color.Blue : Color.Pink;
                }
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {

        }

        private void pbBusiness3_Click(object sender, EventArgs e)
        {
            if (rdoEkonomiErkek.Checked)
            {
                //pbBusiness3.BackColor = Color.Blue;
            }
            else
            {
                //pbBusiness3.BackColor = Color.Pink;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnGidisGelisSecim_Click(object sender, EventArgs e)
        {
            //KoltukEkrani koltukEkrani = new KoltukEkrani();
            //koltukEkrani.Show();

            //this.Hide();
        }
    }
}
