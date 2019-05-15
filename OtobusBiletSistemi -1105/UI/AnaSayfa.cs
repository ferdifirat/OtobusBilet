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
        private IRepository<Fiyat> _fiyatRepository;



        public Kullanici user = null;
        public List<Sefer> gidisSeferList = null;
        public List<Sefer> donusSeferList = null;
        public Sefer gidisSefer = null;
        public Sefer donusSefer = null;
        decimal yolcuSayisi;
        int yonSecimi = 1, otobusTipi = 0;
        int fiyat = 0;
        int gidisDonus = 0;

        #endregion

        public AnaSayfa()
        {
            InitializeComponent();
            InitializeConstructor();

        }


        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            StartUpComponentSettings();
            InitializeTourSearch();
            RemoveResevationTickets();
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
            _fiyatRepository = new EFRepository<Fiyat>(_dbContext);

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
            txtSifre.PasswordChar = '*';
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
            btnDonusBileti.Visible = false;
            if (gidisDonus==1)
                btnDonusBileti.Visible = true;
            else if(gidisDonus==2)
                btnDonusBileti.Visible = false;


            //Tableri gizle
            //tbOtobusOtomasyonu.Appearance = TabAppearance.FlatButtons;
            //tbOtobusOtomasyonu.ItemSize = new Size(0, 1);
            //tbOtobusOtomasyonu.SizeMode = TabSizeMode.Fixed;
        }

        private void RemoveResevationTickets()
        {
            var tickets = _biletRepository.GetAll(p => p.BiletDurumu == false).ToList();

            foreach (var item in tickets)
            {
                var sefer = _seferRepository.Get(x => x.Id == item.SeferID);
                var span = (sefer.Tarih - DateTime.Now);
                if (span.Hours <= 2)
                {
                    _biletRepository.Delete(item);
                    _uow.SaveChanges();
                }
            }
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

                    if (yonSecimi == 2) //to do: Kontrol yapılacak
                    {
                        gidisDonus = 1;
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
            if (rdoRezarvasyon.Checked)    //to do: kontrol edilecek
                tarih.AddHours(2);

            var seferListe = _seferRepository.GetAll(x => x.Tarih < tarih).ToList(); //to do : Tarih> tarih olmalı
            

            foreach (var item in seferListe)
            {
                if (rotaListe.Any(x => x.Id == item.RotaID))
                {
                    tourList.Add(item);
                }
            }
            return tourList;
        }
        ListViewItem item1;
        private void FillTourLists()
        {

            foreach (var item in gidisSeferList)
            {
                item1 = new ListViewItem(item.Id.ToString()); //sıkıntı
                item1.SubItems.Add(item.Tarih.ToString());
                item1.SubItems.Add(cmbNereden.Text);
                item1.SubItems.Add(cmbNereye.Text);
                item1.SubItems.Add(item.CikisSaati.ToString());
                item1.SubItems.Add(item.VarisSaati.ToString());
                item1.SubItems.Add(item.SeferSuresi.ToString());
                lstSeferlerGidis.Items.Add(item1);
            }
            if (yonSecimi == 2)
            {
                foreach (var item in donusSeferList)
                {
                    item1 = new ListViewItem(item.Id.ToString());
                    item1.SubItems.Add(item.Tarih.ToString());
                    item1.SubItems.Add(cmbNereye.Text);
                    item1.SubItems.Add(cmbNereden.Text);
                    item1.SubItems.Add(item.CikisSaati.ToString());
                    item1.SubItems.Add(item.VarisSaati.ToString());
                    item1.SubItems.Add(item.SeferSuresi.ToString());
                    lstSeferlerDonus.Items.Add(item1);
                }

                //dataGridDonus.DataSource = donusSeferList;
            }
            else
            {
                //pnlDonus.Visible = false;
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
                MessageBox.Show("Bilgiler hatalı");
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
        int seferId;
        private void btnTekYonSecim_Click(object sender, EventArgs e)
        {

            seferId = Convert.ToInt32(lstSeferlerGidis.SelectedItems[0].SubItems[0].Text);
            gidisSefer = _seferRepository.Get(x => x.Id == seferId);  //var int'e çevrildi.
            var otobus = _otobusRepository.Get(x => x.Id == gidisSefer.OtobusID);
            otobusTipi = otobus.OtobusTipiID;
            LoadSelectSeatPanel(otobus);
        }

        private void LoadSelectSeatPanel(Otobus otobus)
        {
            tbOtobusOtomasyonu.SelectedIndex = 3;

            if (otobusTipi == 1)
            {
                panelClassic.Visible = true;
                pnlEkonomiCinsiyet.Visible = true;
                panelBusiness.Visible = false;
                pnlBusinessCinsiyet.Visible = false;
                LoadOtobusSeats(otobus);
            }
            else if (otobusTipi == 2)
            {
                panelClassic.Visible = false;
                pnlEkonomiCinsiyet.Visible = false;
                panelBusiness.Visible = true;
                pnlBusinessCinsiyet.Visible = true;
                LoadOtobusSeats(otobus);


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
            if (koltukBilgileri.Count != 0 && yolcuSayaci == yolcuSayisi)   //sayackontrolü önce
            {
                
                YolcuBilgileriniDoldur();

                tbOtobusOtomasyonu.SelectedIndex = 4;
            }
            else
            {
                MessageBox.Show("Lütfen yolcu sayısı kadar koltuk seçimi yapınız..");
            }

        }

        private void YolcuBilgileriniDoldur()
        {

            if (koltukBilgileri != null)
            {
                
                var rota = _seferRepository.Get(p => p.Id == seferId).RotaID;
                var rota2 = _rotaRepository.Get(p => p.Id == rota);
                //var rotaId = _seferRepository.Get(p => p.CikisSaati==cikis);
                ////var rota = _rotaRepository.Get(p => p.Id == rotaId);
                fiyat = _fiyatRepository.Get(p => p.KalkisId == rota2.CikisID && p.VarisId == rota2.VarisID).Tutar; //hata

                for (int i = 0; i < yolcuSayisi; i++)
                {
                    string rdoErkek = "rdoErkek" + i;
                    string rdoKadin = "rdoKadin" + i;
                    string rdoYetiskin = "rdoYetiskin" + i;
                    string panelKisiler = "pnlKisi" + i;
                    string labelKoltukNumarası = "lblKoltukNumarasi" + "" + i;
                    var biletfiyat = "lblBiletFiyati" + i;


                    Panel pnl = this.Controls.Find(panelKisiler, true).FirstOrDefault() as Panel;
                    RadioButton radioErkek = this.Controls.Find(rdoErkek, true).FirstOrDefault() as RadioButton;
                    RadioButton radioKadin = this.Controls.Find(rdoKadin, true).FirstOrDefault() as RadioButton;
                    RadioButton radioYetiskin = this.Controls.Find(rdoYetiskin, true).FirstOrDefault() as RadioButton;
                    Label lbl = this.Controls.Find(labelKoltukNumarası, true).FirstOrDefault() as Label;
                    Label lblFiyat = this.Controls.Find(biletfiyat, true).FirstOrDefault() as Label;

                    pnl.Visible = true;

                    if (koltukBilgileri[i].Cinsiyet)
                        radioErkek.Checked = true;
                    else
                        radioKadin.Checked = true;
                    lbl.Text = koltukBilgileri[i].KoltukNumarasi.ToString();

                    radioYetiskin.Checked = true;
                    radioErkek.Enabled = false;
                    radioKadin.Enabled = false;
                    lblFiyat.Text = fiyat.ToString();
                }
            }

            if (!grpUyeGirisEkrani.Enabled)
            {
                var kullanici = _kullaniciRepository.Get(x => x.Email == txtMail.Text && x.Password == txtSifre.Text);
                txtAd0.Text = kullanici.FirstName;
                txtSoyad0.Text = kullanici.SureName;
                txtTc0.Text = kullanici.CitizienshipNumber;

                txtAd0.Enabled = false;
                txtSoyad0.Enabled = false;
                txtTc0.Enabled = false;
            }
        }
        #region Variables
        int butonNumarasi;
        bool cinsiyetSecimi;
        decimal yolcuSayaci = 0;
        Button secilenKoltuk;
        string arananKoltuk;
        Color color;
        List<KoltukBilgisi> koltukBilgileri = new List<KoltukBilgisi>();
        #endregion

        private void btnKoltuk_Click(object sender, EventArgs e)
        {

            secilenKoltuk = (Button)sender;
            butonNumarasi = Convert.ToInt32(secilenKoltuk.Text);

            if (yolcuSayisi == yolcuSayaci)
            {
                if (secilenKoltuk.BackColor == Color.Lime)
                {
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
                cinsiyetSecimi = false;
                color = Color.Pink;
                if (secilenKoltuk.BackColor == Color.White)
                {
                    if (otobusTipi==1)
                    {
                        if (rdoEkonomiErkek.Checked)
                        {
                            cinsiyetSecimi = true;
                            KoltukSecimi(color);

                        }
                        else if (rdoEkonomiKadin.Checked)
                        {
                            color = Color.Blue;
                            KoltukSecimi(color);

                        }
                    }
                    else if (otobusTipi==2)
                    {
                        if (rdoBusinessErkek.Checked)
                        {
                            cinsiyetSecimi = true;
                            KoltukSecimi(color);

                        }
                        else if (rdoBusinessKadin.Checked)
                        {
                            color = Color.Blue;
                            KoltukSecimi(color);
                        }
                        
                    }
                   
                    
                    if (secilenKoltuk.BackColor == Color.Turquoise || secilenKoltuk.BackColor == Color.Lime)
                    {
                        koltukBilgileri.Add(new KoltukBilgisi
                        {
                            KoltukNumarasi = butonNumarasi,
                            Cinsiyet = cinsiyetSecimi,

                        });
                    }
                }
                else
                {
                    secilenKoltuk.BackColor = Color.White;
                    var koltuk = koltukBilgileri.FirstOrDefault(x => x.KoltukNumarasi == butonNumarasi);
                    koltukBilgileri.Remove(koltuk);
                    yolcuSayaci--;
                }
            }
        }

        private void KoltukSecimi(Color color)
        {
            if (otobusTipi == 1)
            {
                if (butonNumarasi % 2 == 0)
                {
                    arananKoltuk = "btnEkonomi" + (butonNumarasi - 1);
                    Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;

                    if (btnKontrol.BackColor != color)
                    {
                        secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                        if (rdoSatis.Checked)
                            secilenKoltuk.BackColor = Color.Lime;
                        else
                            secilenKoltuk.BackColor = Color.Turquoise;
                        yolcuSayaci++;
                    }
                }
                else if (butonNumarasi % 2 == 1)
                {
                    arananKoltuk = "btnEkonomi" + (butonNumarasi + 1);
                    Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;

                    if (btnKontrol.BackColor != color)
                    {
                        secilenKoltuk.Name = "btnEkonomi" + butonNumarasi;
                        if (rdoSatis.Checked)
                            secilenKoltuk.BackColor = Color.Lime;
                        else
                            secilenKoltuk.BackColor = Color.Turquoise;
                        yolcuSayaci++;
                    }
                }
            }
            else
            {
                if (butonNumarasi % 3 == 0)
                {
                    arananKoltuk = "btnBusiness" + (butonNumarasi - 1);
                    Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;
                    if (btnKontrol.BackColor != color)
                    {
                        secilenKoltuk.Name = "btnBusiness" + butonNumarasi;
                        if (rdoSatis.Checked)
                            secilenKoltuk.BackColor = Color.Lime;
                        else
                            secilenKoltuk.BackColor = Color.Turquoise;
                        yolcuSayaci++;
                    }
                }
                else if ((butonNumarasi + 1) % 3 == 0)
                {
                    arananKoltuk = "btnBusiness" + (butonNumarasi + 1);
                    Button btnKontrol = this.Controls.Find(arananKoltuk, true).FirstOrDefault() as Button;
                    if (btnKontrol.BackColor != color)
                    {
                        secilenKoltuk.Name = "btnBusiness" + butonNumarasi;
                        if (rdoSatis.Checked)
                            secilenKoltuk.BackColor = Color.Lime;
                        else
                            secilenKoltuk.BackColor = Color.Turquoise;
                        yolcuSayaci++;
                    }
                }
                else
                {
                    if (rdoSatis.Checked)   //Kontrol
                        secilenKoltuk.BackColor = Color.Lime;
                    else
                        secilenKoltuk.BackColor = Color.Turquoise;
                    yolcuSayaci++;
                }
            }

        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < yolcuSayaci; i++)
            {
                var kullanici = new Kullanici();

                if (i == 0 && user == null)
                {
                    kullanici = GenerateKullanici(i);
                }
                else if (i == 0 && user != null)
                {
                    kullanici = user;
                }
                else
                {
                    kullanici = GenerateKullanici(i);
                }

                AddTicketRecord(kullanici, i);

            }
            MessageBox.Show("Ödeme işleminiz başarıyla gerçekleştirildi..");
            btnOdemeYap.Enabled = true;
        }

        private void AddTicketRecord(Kullanici kullanici, int i)
        {
            var yemekliMi = "chkYemekli" + i;
            var sigortali = "chkSigortali" + i;
            var yolculukHizmeti = "chkYolculukHizmeti" + i;
            var koltukNumarasi = "lblKoltukNumarasi" + i;
            var biletFiyati = "lblBiletFiyati" + i;
            var cocuk = "rdoCocuk" + i;


            CheckBox chkYemekli = this.Controls.Find(yemekliMi, true).FirstOrDefault() as CheckBox;
            CheckBox chkSigortali = this.Controls.Find(sigortali, true).FirstOrDefault() as CheckBox;
            CheckBox chkYolculukHizmeti = this.Controls.Find(yolculukHizmeti, true).FirstOrDefault() as CheckBox;
            Label lblKoltukNumarasi = this.Controls.Find(koltukNumarasi, true).FirstOrDefault() as Label;
            Label lblBiletFiyati = this.Controls.Find(biletFiyati, true).FirstOrDefault() as Label;
            RadioButton rdoCocuk = this.Controls.Find(cocuk, true).FirstOrDefault() as RadioButton;

            var bilet = new Bilet()
            {
                BiletDurumu = rdoSatis.Checked,
                YemekliMi = chkYemekli.Checked,
                SigortaliMi = chkSigortali.Checked,
                YolculukHizmetiVarMi = chkYolculukHizmeti.Checked,
                CocukluMu = rdoCocuk.Checked,
                KoltukNo = Convert.ToInt32(lblKoltukNumarasi.Text),
                Fiyat = Convert.ToInt32(lblBiletFiyati.Text),
                KullaniciID = kullanici.Id,
                SeferID = gidisSefer.Id
            };

            _biletRepository.Add(bilet);
            _uow.SaveChanges();
        }

        private Kullanici GenerateKullanici(int i)
        {
            var txtFirstName = "txtAd" + i;
            var txtSureName = "txtSoyad" + i;
            var txtCitizienshipNumber = "txtTc" + i;
            var radioButtonGender = "rdoErkek" + i;
            var kullaniciTipiId = 2;

            TextBox firstName = this.Controls.Find(txtFirstName, true).FirstOrDefault() as TextBox;
            TextBox sureName = this.Controls.Find(txtSureName, true).FirstOrDefault() as TextBox;
            TextBox citizienshipNumber = this.Controls.Find(txtCitizienshipNumber, true).FirstOrDefault() as TextBox;
            RadioButton gender = this.Controls.Find(radioButtonGender, true).FirstOrDefault() as RadioButton;

            var kullanici = new Kullanici()
            {
                FirstName = firstName.Text,
                SureName = sureName.Text,
                CitizienshipNumber = citizienshipNumber.Text,
                KullaniciTipiId = kullaniciTipiId,
                Gender = gender.Checked
            };
            _kullaniciRepository.Add(kullanici);
            _uow.SaveChanges();
            kullanici = _kullaniciRepository.Get(p => p.CitizienshipNumber == citizienshipNumber.Text);
            return kullanici;
        }

        private void seferAramayaGit_Click(object sender, EventArgs e)
        {
            tbOtobusOtomasyonu.SelectedIndex = 1;
        }

        private void btnSecimEkrani_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Sefer seçim ekranına döndüğünüzde seçili koltuklar iptal edilecektir. Devam etmek istiyor musunuz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                tbOtobusOtomasyonu.SelectedIndex = 2;
                if (otobusTipi == 1)
                    OtobusSecimleriniTemizle(panelClassic);
                else
                    OtobusSecimleriniTemizle(panelBusiness);
            }

        }

        private void OtobusSecimleriniTemizle(Panel pnl)
        {
            foreach (Control item in pnl.Controls)
            {
                if (item is Button && (item.BackColor == Color.Lime || item.BackColor == Color.Turquoise))
                {
                    item.BackColor = Color.White;
                }
            }
            koltukBilgileri.Clear();
            yolcuSayaci = 0;
        }

        private void btnTekYonAra_Click(object sender, EventArgs e)
        {
            lstSeferlerDonus.Items.Clear();
            lstSeferlerGidis.Items.Clear();
            tbOtobusOtomasyonu.SelectedIndex = 1;
        }

        private void btnGidisGelisSecim_Click(object sender, EventArgs e)
        {
            //KoltukEkrani koltukEkrani = new KoltukEkrani();
            //koltukEkrani.Show();

            //this.Hide();
        }
        Control fiyatlandirma;
        private void chkYemekliSelected(object sender, EventArgs e)
        {
            int yemekFiyati = 10;
            fiyatlandirma = (CheckBox)sender;
            UcretHesap(sender, yemekFiyati, fiyatlandirma);
        }
        private void chkSigortaliSelected(object sender, EventArgs e)
        {
            int sigortaFiyati = 5;
            fiyatlandirma = (CheckBox)sender;
            UcretHesap(sender, sigortaFiyati, fiyatlandirma);
        }
        private void chkYolculukHizmetiSelected(object sender, EventArgs e)
        {
            int yolculukHizmetFiyati = 7;
            fiyatlandirma = (CheckBox)sender;
            UcretHesap(sender, yolculukHizmetFiyati, fiyatlandirma);
        }
        private void rdoYetiskinSelected(object sender, EventArgs e)
        {
            fiyatlandirma = (RadioButton)sender;
            int kisiFiyati = 15;
            UcretHesap(sender, kisiFiyati, fiyatlandirma);
        }

        private void btnDonusBiletiAl_Click(object sender, EventArgs e)  //Yolcubilgileri sayfası
        {
            PanelleriTemizle();
            btnOdemeYap.Enabled = false;
            koltukBilgileri.Clear();
            yolcuSayaci = 0;
            tbOtobusOtomasyonu.SelectedIndex = 6;

        }

        private void btnDonusBileti_Click(object sender, EventArgs e)
        {
            if (otobusTipi == 1)
                OtobusSecimleriniTemizle(panelClassic);
            else
                OtobusSecimleriniTemizle(panelBusiness);
            PanelleriTemizle();
            gidisDonus = 2;
            tbOtobusOtomasyonu.SelectedIndex = 7;
        }

        private void PanelleriTemizle()  //silme işlemleri başarılı mı?
        {
            for (int i = 0; i < yolcuSayisi; i++)
            {
                var tcNo = "txtTc" + i;
                var ad = "txtAd" + i;
                var soyad = "txtSoyad" + i;
                var radioErkek = "rdoErkek" + i;
                var radioYetiskin = "rdoYetiskin" + i;
                var yemekli= "chkYemekli" + i;
                var sigortali= "chkSigortali" + i;
                var yolculukHizmeti= "chkYolculukHizmeti" + i;
                var lblKoltuk= "lblKoltukNumarasi" + i;
                var biletFiyati= "lblBiletFiyati" + i;

                TextBox tcNoSil = this.Controls.Find(tcNo, true).FirstOrDefault() as TextBox;
                TextBox adiSil = this.Controls.Find(ad, true).FirstOrDefault() as TextBox;
                TextBox soyadiSil = this.Controls.Find(soyad, true).FirstOrDefault() as TextBox;
                RadioButton rdoErkek = this.Controls.Find(radioErkek, true).FirstOrDefault() as RadioButton;
                RadioButton rdoYetiskin = this.Controls.Find(radioYetiskin, true).FirstOrDefault() as RadioButton;
                CheckBox chkYemekli = this.Controls.Find(yemekli, true).FirstOrDefault() as CheckBox;
                CheckBox chksigortali = this.Controls.Find(sigortali, true).FirstOrDefault() as CheckBox;
                CheckBox chkYolculukHizmeti = this.Controls.Find(yolculukHizmeti, true).FirstOrDefault() as CheckBox;
                Label koltukNumarasi = this.Controls.Find(lblKoltuk, true).FirstOrDefault() as Label;
                Label lblBiletFiyati = this.Controls.Find(biletFiyati, true).FirstOrDefault() as Label;

                tcNoSil.Text= "";
                adiSil.Text= "";
                soyadiSil.Text= "";
                rdoErkek.Checked = true;
                rdoYetiskin.Checked = true;
                chkYemekli.Checked = chksigortali.Checked = chkYolculukHizmeti.Checked = false;
                koltukNumarasi.Text = "0";
                lblBiletFiyati.Text = "0";
            }
        }

        
        private void btnDonusKoltukSecimi_Click(object sender, EventArgs e)
        {
            var seferId = Convert.ToInt32(lstSeferlerDonus.SelectedItems[0].SubItems[0].Text);
            donusSefer = _seferRepository.Get(x => x.Id == (int)seferId);
            var otobus = _otobusRepository.Get(x => x.Id == donusSefer.OtobusID);
            otobusTipi = otobus.OtobusTipiID;
            LoadSelectSeatPanel(otobus);
            yolcuSayaci = yolcuSayisi;
        }

        private void tpYolcuBilgileri_Click(object sender, EventArgs e)
        {

        }

        private void rdoCocuk0_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UcretHesap(object sender, int gelenFiyat, Control secilenHizmet)
        {
            var indexOfCheckBox = secilenHizmet.Name[secilenHizmet.Name.Length - 1];

            var biletFiyati = "lblBiletFiyati" + indexOfCheckBox;
            Label labelBiletFiyati = this.Controls.Find(biletFiyati, true).FirstOrDefault() as Label;
            var tutar = Convert.ToInt32(labelBiletFiyati.Text);
            if (secilenHizmet is CheckBox)
            {
                if ((secilenHizmet as CheckBox).Checked)
                    tutar += gelenFiyat;
                else
                    tutar -= gelenFiyat;
            }
            else if (secilenHizmet is RadioButton)  //Yetişkin veya Çocuk hesabı
            {
                if ((secilenHizmet as RadioButton).Checked)
                    tutar += gelenFiyat;
                else
                    tutar -= gelenFiyat;
            }

            labelBiletFiyati.Text = tutar.ToString();

        }

    }

}
