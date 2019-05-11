using Dal;
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
        int yonSecimi = 1, otobusTipi = 0;

        #endregion

        public AnaSayfa()
        {
            InitializeComponent();
            InitializeConstructor();

        }

        void YolcuBilgileriniDoldur()
        {

            if (koltukBilgileri != null)
            {

                for (int i = 0; i < yolcuSayisi; i++)
                {
                    string rdoErkek = "rdoErkek" + "" + i;
                    string rdoKadin = "rdoKadin" + "" + i;
                    string panelKisiler = "pnlKisi" + "" + i;
                    string labelKoltukNumarası = "lblKoltukNumarasi" + "" + i;

                    
                    Panel pnl = this.Controls.Find(panelKisiler, true).FirstOrDefault() as Panel;
                    RadioButton radioErkek = this.Controls.Find(rdoErkek, true).FirstOrDefault() as RadioButton;
                    RadioButton radioKadin = this.Controls.Find(rdoKadin, true).FirstOrDefault() as RadioButton;
                    Label lbl = this.Controls.Find(labelKoltukNumarası, true).FirstOrDefault() as Label;

                    
                    pnl.Visible = true;

                    if (koltukBilgileri[i].Cinsiyet == true)
                        radioErkek.Checked = true;
                    else
                        radioKadin.Checked = true;
                    lbl.Text = koltukBilgileri[i].KoltukNumarasi.ToString();


                    radioErkek.Enabled = false;
                    radioKadin.Enabled = false;
                }
            }

            if (grpUyeGirisEkrani.Enabled == false)
            {
                var kullanici = _kullaniciRepository.Get(x => x.Email == txtMail.Text && x.Password == txtSifre.Text);
                txtAd1.Text = kullanici.FirstName;
                txtSoyad1.Text = kullanici.SureName;
                txtTc1.Text = kullanici.CitizienshipNumber;

                txtAd1.Enabled = false;
                txtSoyad1.Enabled = false;
                txtTc1.Enabled = false;
            }
        }
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            StartUpComponentSettings();
            InitializeTourSearch();
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

        private void InitializeTourSearch()
        {


            var duraks = _durakRepository.GetAll().ToList();
            foreach (var i in duraks)
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

        private void StartUpComponentSettings()
        {
            rdoSatis.Checked = true;
            rdoTekYon.Checked = true;
            nmrYolcuSayisi.Minimum = 1;
            nmrYolcuSayisi.Maximum = 4;

            dtDonus.MinDate = DateTime.Now;
            dtGidis.MinDate = DateTime.Now;

            btnOturumuKapat.Visible = false;
            rdoBusinessErkek.Checked = true;
            rdoEkonomiErkek.Checked = true;

            pnlKisi0.Visible = false;
            pnlKisi1.Visible = false;
            pnlKisi2.Visible = false;
            pnlKisi3.Visible = false;

            //Tableri gizle
             tbOtobusOtomasyonu.Appearance = TabAppearance.FlatButtons;
            tbOtobusOtomasyonu.ItemSize = new Size(0, 1);
            tbOtobusOtomasyonu.SizeMode = TabSizeMode.Fixed;
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
                var gidisTarihi = dtGidis.Value;

                var gidisTourList = new List<Sefer>();
                gidisTourList = GetTourList(kalkisDurak, varisDurak, gidisTarihi);

                if (gidisTourList.Count > 0)
                {
                    gidisSeferList = gidisTourList;
                    tbOtobusOtomasyonu.SelectedIndex = 2;
                    yonSecimi = rdoGidisDonus.Checked ? 2 : yonSecimi;

                    if (yonSecimi == 2)
                    {
                        var donusTarihi = dtDonus.Value;
                        donusSeferList = GetTourList(varisDurak, kalkisDurak, donusTarihi);
                    }
                    FillTourLists();
                    //yonlerde sonradan değişiklikte sıkıntı var incelenmeli
                }
            }
        }

        private List<Sefer> GetTourList(int kalkisDurak, int varisDurak, DateTime tarih)
        {
            var tourList = new List<Sefer>();
            var rotaListe = _rotaRepository.GetAll(x => x.CikisID == kalkisDurak && x.VarisID == varisDurak).ToList();

            var seferListe = _seferRepository.GetAll(x => x.Tarih < tarih).ToList();// to do : alttaki foreach'i linq ile yap
            //sıkıntılı


            foreach (var item in seferListe)
            {
                if (rotaListe.Any(x => x.Id == item.RotaID))
                {
                    tourList.Add(item);
                }
            }
            return tourList;
        }

        private void FillTourLists()
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
                grpUyeGirisEkrani.Enabled = false;
                btnOturumuKapat.Visible = true;
            }


        }

        private void btnOturumuKapat_Click(object sender, EventArgs e)
        {
            user = null;
            grpUyeGirisEkrani.Enabled = true;

            txtMail.Text = "";
            txtSifre.Text = "";
            btnOturumuKapat.Visible = false;

        }

        private void btnTekYonSecim_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridGidis.CurrentRow.Index;
            var seferId = dataGridGidis.Rows[rowindex].Cells[0].Value;
            gidisSefer = _seferRepository.Get(x => x.Id == (int)seferId);
            var otobus = _otobusRepository.Get(x => x.Id == gidisSefer.OtobusID);
            otobusTipi = otobus.OtobusTipiID;
            LoadSelectSeatPanel(otobus);
        }

        private void LoadSelectSeatPanel(Otobus otobus)
        {
            tbOtobusOtomasyonu.SelectedIndex = 3;

            if (otobusTipi == 1)
            {
                panelBusiness.Visible = false;
                pnlBusinessCinsiyet.Visible = false;
                LoadOtobusSeats(otobus);
            }
            else if (otobusTipi == 2)
            {
                panelClassic.Visible = false;
                pnlEkonomiCinsiyet.Visible = false;
                panelBusiness.Visible = true;

            }
        }

        private void LoadOtobusSeats(Otobus otobus)
        {
            var tickets = _biletRepository.GetAll(x => x.SeferID == gidisSefer.Id).ToList();


            foreach (var item in tickets)
            {
                var seatNumberBox = otobus.OtobusTipiID == 1 ? "btnEkonomi" : "btnBusiness";
                var gender = _kullaniciRepository.Get(x => x.Id == item.KullaniciID).Gender;
                seatNumberBox = seatNumberBox + item.KoltukNo;
                Button button = this.Controls.Find(seatNumberBox, true).FirstOrDefault() as Button;


                if (button != null)
                {
                    button.BackColor = gender == true ? Color.Blue : Color.Pink;
                    button.Enabled = false;
                }
            }
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (koltukBilgileri.Count != 0 && yolcuSayaci==yolcuSayisi)
            {
                YolcuBilgileriniDoldur();
                tbOtobusOtomasyonu.SelectedIndex = 4;
            }
            else
            {
                MessageBox.Show("Lütfen yolcu sayısı kadar koltuk seçimi yapınız..");
            }

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

        int butonNumarasi;
        bool cinsiyetSecimi;
        decimal yolcuSayaci = 0;
        Button secilenKoltuk;
        List<KoltukBilgisi> koltukBilgileri = new List<KoltukBilgisi>();
        private void btnKoltuk_Click(object sender, EventArgs e)
        {
            
            if (yolcuSayisi == yolcuSayaci)
            {
                secilenKoltuk = (Button)sender;
                if (secilenKoltuk.BackColor == Color.Lime)
                {
                    butonNumarasi = Convert.ToInt32(secilenKoltuk.Text);
                    int index = koltukBilgileri.FindIndex(x => x.KoltukNumarasi == butonNumarasi);
                    koltukBilgileri.RemoveAt(index);
                    secilenKoltuk.BackColor = Color.White;
                    yolcuSayaci--;
                }
                else
                {
                    MessageBox.Show("Girdiğiniz yolcu sayısına ulaştınız daha fazla koltuk seçemezsiniz.");
                }
            }
            else
            {
                secilenKoltuk = (Button)sender;
                string arananKoltuk;
                cinsiyetSecimi = false;
                butonNumarasi = Convert.ToInt32(secilenKoltuk.Text);
                if (secilenKoltuk.BackColor == Color.White)
                {
                    if (rdoEkonomiErkek.Checked == true)
                    {
                        cinsiyetSecimi = true;
                        if (butonNumarasi % 2 == 0)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi - 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;

                            if (btnKontrol.BackColor != Color.Pink)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }
                        else if (butonNumarasi % 2 == 1)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi + 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;

                            if (btnKontrol.BackColor != Color.Pink)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }

                    }
                    else if (rdoEkonomiKadin.Checked == true)
                    {

                        if (butonNumarasi % 2 == 0)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi - 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;

                            if (btnKontrol.BackColor != Color.Blue)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }
                        else if (butonNumarasi % 2 == 1)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi + 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;

                            if (btnKontrol.BackColor != Color.Blue)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }


                    }
                    else if (rdoBusinessErkek.Checked == true)
                    {
                        cinsiyetSecimi = true;
                        if (butonNumarasi % 3 == 0)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi - 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;
                            if (btnKontrol.BackColor != Color.Pink)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }
                        else if ((butonNumarasi + 1) % 3 == 0)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi + 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;
                            if (btnKontrol.BackColor != Color.Pink)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }
                    }
                    else if (rdoBusinessKadin.Checked == true)
                    {
                        if (butonNumarasi % 3 == 0)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi - 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;
                            if (btnKontrol.BackColor != Color.Pink)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }
                        else if ((butonNumarasi + 1) % 3 == 0)
                        {
                            arananKoltuk = "btnEkonomi" + (butonNumarasi + 1);
                            Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;
                            if (btnKontrol.BackColor != Color.Pink)
                            {
                                secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                                secilenKoltuk.BackColor = Color.Lime;
                                yolcuSayaci++;
                            }
                        }
                    }

                    koltukBilgileri.Add(new KoltukBilgisi
                    {
                        KoltukNumarasi = butonNumarasi,
                        Cinsiyet = cinsiyetSecimi,
                        
                    });
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBusiness29_Click(object sender, EventArgs e)
        {

        }

        private void tpYolcuBilgileri_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tpKoltukSecimi_Click(object sender, EventArgs e)
        {

        }

        private void rdoYetiskin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoCocuk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            _kullaniciRepository.Add(new Kullanici
            {
                FirstName = txtAd1.Text,
                SureName = txtSoyad1.Text,
                CitizienshipNumber = txtTc1.Text,
                KullaniciTipiId = 1,
                Gender = rdoErkek0.Checked
                 
            });
            _biletRepository.Add(new Bilet {
                BiletDurumu = true,  //düzenlenecek
                KoltukNo= Convert.ToInt32(lblKoltukNumarasi0.Text)
                //eksik
            });
            _uow.SaveChanges();
            if (pnlKisi1.Visible == true)
            {
                _kullaniciRepository.Add(new Kullanici
                {
                    FirstName = txtAd1.Text,
                    SureName = txtSoyad1.Text,
                    CitizienshipNumber = txtTc1.Text,
                    KullaniciTipiId = 1,
                    Gender = rdoErkek0.Checked

                });
                _biletRepository.Add(new Bilet
                {
                    BiletDurumu = true,  //düzenlenecek
                    KoltukNo = Convert.ToInt32(lblKoltukNumarasi0.Text)
                    //eksik
                });
                _uow.SaveChanges();
            } 
            //Belki kısa bi yol?



        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbOtobusOtomasyonu.SelectedIndex = 1;
        }

        private void btnSecimEkrani_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Sefer seçim ekranına döndüğünüzde seçili koltuklar iptal edilecektir. Devam etmek istiyor musunuz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                tbOtobusOtomasyonu.SelectedIndex = 2;
                foreach (Control item in panelClassic.Controls)
                {
                    if(item is Button && item.BackColor==Color.Lime)
                    {
                        item.BackColor = Color.White;
                    }
                }
                koltukBilgileri.Clear();
                yolcuSayaci = 0;
            }
          
        }

        private void btnTekYonAra_Click(object sender, EventArgs e)
        {
            tbOtobusOtomasyonu.SelectedIndex=1;
        }

        private void btnGidisGelisSecim_Click(object sender, EventArgs e)
        {
            //KoltukEkrani koltukEkrani = new KoltukEkrani();
            //koltukEkrani.Show();

            //this.Hide();
        }


    }
}
