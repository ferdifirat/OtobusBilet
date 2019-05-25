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
        private IRepository<KullaniciTipi> _kullaniciTipRepository;




        public Kullanici user = null;
        public List<Sefer> gidisSeferListesi = null;
        public List<Sefer> donusSeferListesi = null;
        public Sefer gidisSefer = null;
        public Sefer donusSefer = null;
        decimal yolcuSayisi;
        int yonSecimi = 1, otobusTipi = 0;
        int fiyat = 0;
        int gidisDonus = 0;
        int sorgulamaBiletId;

        #endregion

        public AnaSayfa()
        {
            InitializeComponent();
            InitializeConstructor();

        }


        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            BaslangicAyarlari();
            InitializeTourSearch();
            RezervasyonIptal();


            dtGidis.MinDate = DateTime.Today;
            dtGidis.MaxDate = DateTime.Today.AddDays(14);
            dtDonus.MinDate = DateTime.Today;
            dtDonus.MaxDate = DateTime.Today.AddDays(14);

            KayitYap();
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
            _kullaniciTipRepository = new EFRepository<KullaniciTipi>(_dbContext);


        }

        private void InitializeTourSearch()
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
        private void KayitYap()
        {
            //Durak
            var duraklar = _durakRepository.GetAll().ToList();
            if (duraklar.Count == 0)
            {
                List<Durak> EklenecekDuraklar = new List<Durak>()
                {
                   new Durak() {DurakAdi = "İstanbul"},
                   new Durak() {DurakAdi = "Bursa" },
                   new Durak() {DurakAdi = "Ankara"},
                   new Durak() {DurakAdi = "Antalya"}
                };
                _durakRepository.AddRange(EklenecekDuraklar);
            }
            _uow.SaveChanges();

            //Rota 
            var rotalar = _rotaRepository.GetAll().ToList();
            if (rotalar.Count == 0)
            {
                List<Rota> EklenecekRotalar = new List<Rota>()
                {
                    new Rota() {CikisID = 1, VarisID = 2},
                    new Rota() {CikisID = 1, VarisID = 3},
                    new Rota() {CikisID = 1, VarisID = 4},
                    new Rota() {CikisID = 2, VarisID = 1},
                    new Rota() {CikisID = 2, VarisID = 3},
                    new Rota() {CikisID = 2, VarisID = 4},
                    new Rota() {CikisID = 3, VarisID = 1},
                    new Rota() {CikisID = 3, VarisID = 2},
                    new Rota() {CikisID = 3, VarisID = 4},
                    new Rota() {CikisID = 4, VarisID = 1},
                    new Rota() {CikisID = 4, VarisID = 2},
                    new Rota() {CikisID = 4, VarisID = 3}
                };
                _rotaRepository.AddRange(EklenecekRotalar);

            }
            _uow.SaveChanges();

            //// otobus Tipi

            var otobusTipi = _otobusTipiRepository.GetAll().ToList();

            if (otobusTipi.Count == 0)
            {
                List<OtobusTipi> eklenecekOtobusTipi = new List<OtobusTipi>()
                {
                    new OtobusTipi() {TipAdi="Ekonomi"},
                    new OtobusTipi()  {TipAdi="Businiess"}

                };
                _otobusTipiRepository.AddRange(eklenecekOtobusTipi);

            }
            _uow.SaveChanges();

            // otobus 

            var otobus = _otobusRepository.GetAll().ToList();
            if (otobus.Count == 0)
            {

                for (int i = 0; i < 168; i++)
                {
                    List<Otobus> eklenecekOtobus = new List<Otobus>()
                {

                new Otobus() { OtobusTipiID = 1, KoltukSayisi = 56 },
                new Otobus() { OtobusTipiID = 2, KoltukSayisi = 27 }
                };
                    _otobusRepository.AddRange(eklenecekOtobus);
                }



            }
            _uow.SaveChanges();

            var seferlerIlk = _seferRepository.GetAll().ToList();
            if (seferlerIlk.Count == 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    DateTime gun = new DateTime(dtGidis.Value.Year, dtGidis.Value.Month, dtGidis.Value.Day + i, 0, 0, 0);
                    List<Sefer> eklenecekSeferler = new List<Sefer>()
                {
                    new Sefer() { CikisSaati=TimeSpan.FromHours(8) , VarisSaati=TimeSpan.FromHours(9), RotaID =1,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 1 },
                    new Sefer() { CikisSaati=TimeSpan.FromHours(9) , VarisSaati=TimeSpan.FromHours(10), RotaID =2,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 3},
                      new Sefer() { CikisSaati=TimeSpan.FromHours(10) , VarisSaati=TimeSpan.FromHours(11), RotaID =3,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 5 },
                          new Sefer() { CikisSaati=TimeSpan.FromHours(11) , VarisSaati=TimeSpan.FromHours(12), RotaID =4,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 7 },
                                    new Sefer() { CikisSaati=TimeSpan.FromHours(12) , VarisSaati=TimeSpan.FromHours(13), RotaID =5,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 9 },
                                              new Sefer() { CikisSaati=TimeSpan.FromHours(13) , VarisSaati=TimeSpan.FromHours(14), RotaID =6,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 11 },
                                                  new Sefer() { CikisSaati=TimeSpan.FromHours(14) , VarisSaati=TimeSpan.FromHours(15), RotaID =7,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 13 },
                    new Sefer() { CikisSaati=TimeSpan.FromHours(15) , VarisSaati=TimeSpan.FromHours(16), RotaID =8,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 15 },
                      new Sefer() { CikisSaati=TimeSpan.FromHours(16) , VarisSaati=TimeSpan.FromHours(17), RotaID = 9,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 17 },
                          new Sefer() { CikisSaati=TimeSpan.FromHours(17) , VarisSaati=TimeSpan.FromHours(18), RotaID = 10,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 19 },
                                    new Sefer() { CikisSaati=TimeSpan.FromHours(18) , VarisSaati=TimeSpan.FromHours(19), RotaID = 11,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 21 },
                                              new Sefer() { CikisSaati=TimeSpan.FromHours(19) , VarisSaati=TimeSpan.FromHours(20), RotaID = 12,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 23 },

                                               new Sefer() { CikisSaati=TimeSpan.FromHours(19) , VarisSaati=TimeSpan.FromHours(20), RotaID =1,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 2 },
                    new Sefer() { CikisSaati=TimeSpan.FromHours(18) , VarisSaati=TimeSpan.FromHours(19), RotaID =2,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 4 },
                      new Sefer() { CikisSaati=TimeSpan.FromHours(17) , VarisSaati=TimeSpan.FromHours(18), RotaID =3,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 6 },
                          new Sefer() { CikisSaati=TimeSpan.FromHours(16) , VarisSaati=TimeSpan.FromHours(17), RotaID =4,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 8 },
                                    new Sefer() { CikisSaati=TimeSpan.FromHours(15) , VarisSaati=TimeSpan.FromHours(16), RotaID =5,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 10 },
                                              new Sefer() { CikisSaati=TimeSpan.FromHours(14) , VarisSaati=TimeSpan.FromHours(15), RotaID =6,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 12 },
                                                  new Sefer() { CikisSaati=TimeSpan.FromHours(13) , VarisSaati=TimeSpan.FromHours(14), RotaID =7,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 14 },
                    new Sefer() { CikisSaati=TimeSpan.FromHours(12) , VarisSaati=TimeSpan.FromHours(13), RotaID =8,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 16 },
                      new Sefer() { CikisSaati=TimeSpan.FromHours(11) , VarisSaati=TimeSpan.FromHours(12), RotaID = 9,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 18 },
                          new Sefer() { CikisSaati=TimeSpan.FromHours(10) , VarisSaati=TimeSpan.FromHours(11), RotaID = 10,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 20 },
                                    new Sefer() { CikisSaati=TimeSpan.FromHours(9) , VarisSaati=TimeSpan.FromHours(10), RotaID = 11,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 22 },
                                              new Sefer() { CikisSaati=TimeSpan.FromHours(8) , VarisSaati=TimeSpan.FromHours(9), RotaID = 12,
                        SeferSuresi = TimeSpan.FromHours(1), Tarih=gun, OtobusID = 24 }
                };
                    _seferRepository.AddRange(eklenecekSeferler);
                }
            }
            _uow.SaveChanges();

            var kullaniciTipi = _kullaniciTipRepository.GetAll().ToList();
            if (kullaniciTipi.Count == 0)
            {
                List<KullaniciTipi> kullaniciTipis = new List<KullaniciTipi>() {
                new KullaniciTipi() { TipAdi = "user" },
                new KullaniciTipi() { TipAdi = "potansiyel uye" }
                };
                _kullaniciTipRepository.AddRange(kullaniciTipis);
            }
            _uow.SaveChanges();

            var fiyat = _fiyatRepository.GetAll().ToList();
            if (fiyat.Count == 0)
            {
                List<Fiyat> fiyats = new List<Fiyat>()
                {
                    new Fiyat() {KalkisId=1 , VarisId=2, Tutar=50},
                    new Fiyat() {KalkisId=1 , VarisId=3, Tutar=80},
                    new Fiyat() {KalkisId=1 , VarisId=4, Tutar=100},
                    new Fiyat() {KalkisId=2 , VarisId=1, Tutar=50},
                    new Fiyat() {KalkisId=2 , VarisId=3, Tutar=45},
                    new Fiyat() {KalkisId=2 , VarisId=4, Tutar=65},
                    new Fiyat() {KalkisId=3 , VarisId=1, Tutar=80},
                    new Fiyat() {KalkisId=3 , VarisId=2, Tutar=45},
                    new Fiyat() {KalkisId=3 , VarisId=4, Tutar=75},
                    new Fiyat() {KalkisId=4 , VarisId=1, Tutar=100},
                    new Fiyat() {KalkisId=4 , VarisId=2, Tutar=65},
                    new Fiyat() {KalkisId=4 , VarisId=3, Tutar=75},

                };
                _fiyatRepository.AddRange(fiyats);
            }
            _uow.SaveChanges();

            
        }

        private void BaslangicAyarlari()
        {
            txtSifre.PasswordChar = '*';
            rdoSatis.Checked = true;
            rdoTekYon.Checked = true;
            nmrYolcuSayisi.Minimum = 1;
            nmrYolcuSayisi.Maximum = 4;

            dtGidis.MinDate = DateTime.Now;

            btnOturumuKapat.Visible = false;
            rdoBusinessErkek.Checked = true;
            rdoEkonomiErkek.Checked = true;

            pnlKisi0.Visible = false;
            pnlKisi1.Visible = false;
            pnlKisi2.Visible = false;
            pnlKisi3.Visible = false;
            btnDonusBileti.Visible = false;

            tbOtobusOtomasyonu.Appearance = TabAppearance.FlatButtons;
            tbOtobusOtomasyonu.ItemSize = new Size(0, 1);
            tbOtobusOtomasyonu.SizeMode = TabSizeMode.Fixed;
        }

        private void RezervasyonIptal()
        {
            var biletler = _biletRepository.GetAll(p => p.BiletDurumu == false).ToList();

            foreach (var item in biletler)
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

                var kalkisDurak = ComboBoxDegerleriniGetir(cmbNereden.SelectedItem);
                var varisDurak = ComboBoxDegerleriniGetir(cmbNereye.SelectedItem);
                var gidisTarihi = dtGidis.Value;

                var gidisTurListesi = new List<Sefer>();
                gidisTurListesi = TurListesiniAl(kalkisDurak, varisDurak, gidisTarihi);

                if (gidisTurListesi.Count > 0)
                {
                    gidisSeferListesi = gidisTurListesi;

                    yonSecimi = rdoGidisDonus.Checked ? 2 : yonSecimi;

                    if (yonSecimi == 2) //to do: Kontrol yapılacak
                    {
                        gidisDonus = 1;
                        var donusTarihi = dtDonus.Value;
                        donusSeferListesi = TurListesiniAl(varisDurak, kalkisDurak, donusTarihi);
                    }
                    if (yonSecimi == 2 && donusSeferListesi.Count == 0)
                        MessageBox.Show("Seçtiğiniz tarihte dönüş bileti bulunmamaktadır.");
                    else
                    {
                        tbOtobusOtomasyonu.SelectedIndex = 2;
                        TurListesiniDoldur();
                    }

                }
                else
                    MessageBox.Show("Gidiş yönünde herhangi bir sefer bulunamadı. Lütfen başka bir tarih seçiniz..");
            }
        }

        private List<Sefer> TurListesiniAl(int kalkisDurak, int varisDurak, DateTime tarih)
        {
            var turListesi = new List<Sefer>();

            var rotaListe = _rotaRepository.GetAll(x => x.CikisID == kalkisDurak && x.VarisID == varisDurak).ToList();
            if (rdoRezarvasyon.Checked)    //to do: kontrol edilecek
                tarih.AddHours(2);

            var seferListe = _seferRepository.GetAll(x => x.Tarih.Day == tarih.Day).ToList(); //to do : Tarih> tarih olmalı


            foreach (var item in seferListe)
            {
                if (rotaListe.Any(x => x.Id == item.RotaID))
                {
                    turListesi.Add(item);
                }
            }
            return turListesi;
        }
        ListViewItem seferListesi;
        private void TurListesiniDoldur()
        {


            foreach (var item in gidisSeferListesi)
            {
                var otobusTipi = item.Otobus.OtobusTipiID == 1 ? "Ekonomi" : "Business";
                seferListesi = new ListViewItem(item.Id.ToString());
                seferListesi.SubItems.Add(item.Tarih.ToShortDateString());
                seferListesi.SubItems.Add(cmbNereden.Text);
                seferListesi.SubItems.Add(cmbNereye.Text);
                seferListesi.SubItems.Add(item.CikisSaati.ToString());
                seferListesi.SubItems.Add(item.VarisSaati.ToString());
                seferListesi.SubItems.Add(item.SeferSuresi.ToString());
                seferListesi.SubItems.Add(otobusTipi);
                lstSeferlerGidis.Items.Add(seferListesi);


            }
            if (yonSecimi == 2)
            {
                foreach (var item in donusSeferListesi)
                {
                    var otobusTipi = item.Otobus.OtobusTipiID == 1 ? "Ekonomi" : "Business";
                    seferListesi = new ListViewItem(item.Id.ToString());
                    seferListesi.SubItems.Add(item.Tarih.ToShortDateString());
                    seferListesi.SubItems.Add(cmbNereye.Text);
                    seferListesi.SubItems.Add(cmbNereden.Text);
                    seferListesi.SubItems.Add(item.CikisSaati.Hours.ToString());
                    seferListesi.SubItems.Add(item.VarisSaati.Hours.ToString());
                    seferListesi.SubItems.Add(item.SeferSuresi.ToString());
                    seferListesi.SubItems.Add(otobusTipi);
                    lstSeferlerDonus.Items.Add(seferListesi);
                }
            }

        }

        private int ComboBoxDegerleriniGetir(object selectedItem)
        {
            var secilenDeger = (ComboBoxItem)selectedItem;
            return secilenDeger.Value;

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

            if (kullanici == null || kullanici.KullaniciTipiId != 1)
                MessageBox.Show("Hatalı kullanıcı adı ve şifre girdiniz..!");
            else if (txtMail.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Mail ve şifre alanları boş bırakılamaz.!");
            }
            else
            {

                MessageBox.Show("Giriş yapıldı. Hoşgeldiniz " + kullanici.FirstName + kullanici.SureName);
                user = new Kullanici();
                user = kullanici;
                grpUyeGirisEkrani.Enabled = false;
                btnOturumuKapat.Visible = true;
            }
        }

        public bool BosAlanVarMi()
        {
            foreach (Control item in grpUyeGirisEkrani.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == "")
                    {
                        return false;
                    }

                }


            }
            return true;
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
            if (lstSeferlerGidis.SelectedItems.Count > 0)
            {
                seferId = Convert.ToInt32(lstSeferlerGidis.SelectedItems[0].SubItems[0].Text);
                gidisSefer = _seferRepository.Get(x => x.Id == seferId);
                var otobus = _otobusRepository.Get(x => x.Id == gidisSefer.OtobusID);
                otobusTipi = otobus.OtobusTipiID;
                LoadSelectSeatPanel(otobus);
            }
            else
                MessageBox.Show("Lütfen bir sefer seçiniz");

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
            if (gidisDonus == 2)
            {
                var ticket = _biletRepository.GetAll(x => x.SeferID == donusSefer.Id).ToList();
                foreach (var item in ticket)
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
            else
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
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (koltukBilgileri.Count != 0 && yolcuSayaci == yolcuSayisi)   //sayackontrolü önce
            {

                if (rdoRezarvasyon.Checked)
                    btnOdemeYap.Text = "Rezervasyon Yap";
                else
                    btnOdemeYap.Text = "Ödeme Yap";

                if (gidisDonus == 1)
                    btnDonusBileti.Visible = true;
                else if (gidisDonus == 2)
                {
                    yolcuSayisi = yolcuSayisi / 2;
                    btnDonusBileti.Visible = false;
                }
                YolcuBilgileriniDoldur();

                tbOtobusOtomasyonu.SelectedIndex = 4;
                btnOdemeYap.Enabled = true;
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

                var sefer = _seferRepository.Get(p => p.Id == seferId).RotaID;
                var rota2 = _rotaRepository.Get(p => p.Id == sefer);
                fiyat = _fiyatRepository.Get(p => p.KalkisId == rota2.CikisID && p.VarisId == rota2.VarisID).Tutar; //hata
                if (otobusTipi == 1)
                    fiyat = fiyat - 20;

                for (int i = 0; i < yolcuSayisi; i++)
                {
                    string rdoErkek = "rdoErkek" + i;
                    string rdoKadin = "rdoKadin" + i;
                    string rdoYetiskin = "rdoYetiskin" + i;
                    string panelKisiler = "pnlKisi" + i;
                    string labelKoltukNumarası = "lblKoltukNumarasi" + i;
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
                    if (otobusTipi == 1)
                    {
                        if (rdoEkonomiErkek.Checked)
                        {
                            cinsiyetSecimi = true;
                            KoltukSecimi(color, "Erkek", "kadin");

                        }
                        else if (rdoEkonomiKadin.Checked)
                        {
                            color = Color.Blue;
                            KoltukSecimi(color, "Kadın", "erkek");

                        }
                    }
                    else if (otobusTipi == 2)
                    {
                        if (rdoBusinessErkek.Checked)
                        {
                            cinsiyetSecimi = true;
                            KoltukSecimi(color, "Erkek", "kadin");

                        }
                        else if (rdoBusinessKadin.Checked)
                        {
                            color = Color.Blue;
                            KoltukSecimi(color, "Kadın", "erkek");
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

        private void KoltukSecimi(Color color, string cinsiyet1, string cinsiyet2)
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
                    else
                        MessageBox.Show(cinsiyet1 + " yanına " + cinsiyet2 + " alamazsınız.. ");
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
                    else
                        MessageBox.Show(cinsiyet1 + " yanına " + cinsiyet2 + " alamazsınız.. ");

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
                    else
                        MessageBox.Show(cinsiyet1 + " yanına " + cinsiyet2 + " alamazsınız.. ");
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
                    else
                        MessageBox.Show(cinsiyet1 + " yanına " + cinsiyet2 + " alamazsınız.. ");
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

        private bool OdemeKontrolu()
        {
            bool result = true;
            for (int i = 0; i < yolcuSayisi; i++)
            {
                var txtFirstName = "txtAd" + i;
                var txtSureName = "txtSoyad" + i;
                var txtCitizienshipNumber = "txtTc" + i;
                var radioButtonGender = "rdoErkek" + i;

                TextBox firstName = this.Controls.Find(txtFirstName, true).FirstOrDefault() as TextBox;
                TextBox sureName = this.Controls.Find(txtSureName, true).FirstOrDefault() as TextBox;
                TextBox citizienshipNumber = this.Controls.Find(txtCitizienshipNumber, true).FirstOrDefault() as TextBox;
                RadioButton gender = this.Controls.Find(radioButtonGender, true).FirstOrDefault() as RadioButton;
                if (firstName.Text == "" || sureName.Text == "" || citizienshipNumber.Text == "")
                {
                    return result = false;
                }
            }
            return result;

        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {

            if (!OdemeKontrolu())
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
            }
            else
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
                if (!rdoRezarvasyon.Checked)
                {
                    if (gidisDonus == 2)
                        MessageBox.Show("Dönüş Biletiniz alınmıştır.");
                    else if (gidisDonus == 1)
                        MessageBox.Show("Ödeme işleminiz başarıyla gerçekleştirildi. Şimdi dönüş biletinizi alabilirsiniz..");
                    else
                        MessageBox.Show("Ödeme işleminiz başarıyla gerçekleştirildi..");
                }
                else
                {

                    if (gidisDonus == 2)
                        MessageBox.Show("Dönüş Biletiniz rezerve edilmiştir. Lütfen sefer saatinden 2 saat önce satın alınız.");
                    else if (gidisDonus == 1)
                        MessageBox.Show("Rezerve işleminiz başarıyla gerçekleşitirilmiştir. Şimdi dönüş biletinizi rezerve edebilirsiniz. Lütfen sefer saatinden 2 saat önce satın alınız.");
                    else
                        MessageBox.Show("Rezerve işleminiz başarıyla gerçekleştirildi. Lütfen sefer saatinden 2 saat önce satın alınız.");
                }

                btnOdemeYap.Enabled = false;
            }
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


            var kullaniciKontrol = _kullaniciRepository.Get(x => x.CitizienshipNumber == citizienshipNumber.Text);


            var kullanici = new Kullanici();
            if (kullaniciKontrol == null)
            {
                kullanici = new Kullanici()
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
            }
            else
            {
                kullanici = _kullaniciRepository.Get(p => p.CitizienshipNumber == citizienshipNumber.Text);
            }
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
            int yemekFiyati;
            if (otobusTipi == 1)
                yemekFiyati = 10;
            else
                yemekFiyati = 15;

            fiyatlandirma = (CheckBox)sender;
            UcretHesap(sender, yemekFiyati, fiyatlandirma);
        }
        private void chkSigortaliSelected(object sender, EventArgs e)
        {
            int sigortaFiyati;
            if (otobusTipi == 1)
                sigortaFiyati = 5;
            else
                sigortaFiyati = 10;
            fiyatlandirma = (CheckBox)sender;
            UcretHesap(sender, sigortaFiyati, fiyatlandirma);
        }
        private void chkYolculukHizmetiSelected(object sender, EventArgs e)
        {
            int yolculukHizmetFiyati;
            if (otobusTipi == 1)
                yolculukHizmetFiyati = 7;
            else
                yolculukHizmetFiyati = 13;

            fiyatlandirma = (CheckBox)sender;
            UcretHesap(sender, yolculukHizmetFiyati, fiyatlandirma);
        }
        private void rdoYetiskinSelected(object sender, EventArgs e)
        {

            int kisiFiyati;
            if (otobusTipi == 1)
                kisiFiyati = 20;
            else
                kisiFiyati = 10;
            fiyatlandirma = (RadioButton)sender;
            UcretHesap(sender, kisiFiyati, fiyatlandirma);
        }

        private void btnDonusBileti_Click(object sender, EventArgs e)
        {
            if (!btnOdemeYap.Enabled)
            {
                if (otobusTipi == 1)
                    OtobusSecimleriniTemizle(panelClassic);
                else
                    OtobusSecimleriniTemizle(panelBusiness);
                PanelleriTemizle();
                gidisDonus = 2;
                btnOdemeYap.Enabled = true;
                tbOtobusOtomasyonu.SelectedIndex = 6;
                btnDonusBileti.Enabled = true;
            }
            else
                MessageBox.Show("Lütfen öncelikle gidiş yönündeki ödemenizi gerçekleştiriniz.");

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
                var yemekli = "chkYemekli" + i;
                var sigortali = "chkSigortali" + i;
                var yolculukHizmeti = "chkYolculukHizmeti" + i;
                var lblKoltuk = "lblKoltukNumarasi" + i;
                var biletFiyati = "lblBiletFiyati" + i;

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

                tcNoSil.Text = "";
                adiSil.Text = "";
                soyadiSil.Text = "";
                rdoErkek.Checked = true;
                rdoYetiskin.Checked = true;
                chkYemekli.Checked = chksigortali.Checked = chkYolculukHizmeti.Checked = false;
                koltukNumarasi.Text = "0";
                lblBiletFiyati.Text = "0";
            }
        }


        private void btnDonusKoltukSecimi_Click(object sender, EventArgs e)
        {
            if (lstSeferlerDonus.SelectedItems.Count > 0)
            {
                var seferId = Convert.ToInt32(lstSeferlerDonus.SelectedItems[0].SubItems[0].Text);
                donusSefer = _seferRepository.Get(x => x.Id == (int)seferId);
                var otobus = _otobusRepository.Get(x => x.Id == donusSefer.OtobusID);
                otobusTipi = otobus.OtobusTipiID;
                LoadSelectSeatPanel(otobus);
                gidisDonus = 2;
                yolcuSayaci = yolcuSayisi;
                yolcuSayisi = yolcuSayisi * 2;
            }
            else
                MessageBox.Show("Lütfen bir sefer seçiniz..");
        }

        private void btnBiletBilgileriniGoruntule_Click(object sender, EventArgs e)
        {
            if (gidisDonus == 2 || rdoTekYon.Checked == true)
                tbOtobusOtomasyonu.SelectedIndex = 5;
            else
                MessageBox.Show("Önce bilet bilgilerinizi kaydediniz..");

        }

        private void btnBiletlerim_Click(object sender, EventArgs e)
        {
            tbOtobusOtomasyonu.SelectedIndex = 5;
        }

        private void dtGidis_ValueChanged(object sender, EventArgs e)
        {
            dtDonus.MinDate = dtGidis.Value;
        }

        private void BiletSorgulama()
        {

            var kullanici = _kullaniciRepository.Get(x => x.CitizienshipNumber == txtTcNoArama.Text);
            if (kullanici != null)
            {
                var bilet = _biletRepository.GetAll(x => x.KullaniciID == kullanici.Id).ToList();


                lstBiletGoruntuleme.Items.Clear();
                foreach (var item in bilet)
                {
                    seferListesi = new ListViewItem(item.Id.ToString());
                    seferListesi.SubItems.Add(kullanici.CitizienshipNumber.ToString());
                    seferListesi.SubItems.Add(kullanici.FirstName + " - " + kullanici.SureName);
                    string cikisDurak = _durakRepository.GetAll(x => x.DurakID == item.Sefer.Rota.CikisID).Select(x => x.DurakAdi).FirstOrDefault();
                    string varisDurak = _durakRepository.GetAll(x => x.DurakID == item.Sefer.Rota.VarisID).Select(x => x.DurakAdi).FirstOrDefault();
                    seferListesi.SubItems.Add(item.Sefer.Tarih.ToShortDateString());
                    seferListesi.SubItems.Add(cikisDurak + " - " + varisDurak);
                    seferListesi.SubItems.Add(item.Sefer.CikisSaati.Hours + " - " + item.Sefer.VarisSaati.Hours);
                    seferListesi.SubItems.Add(item.SigortaliMi ? "+" : "-");
                    seferListesi.SubItems.Add(item.YemekliMi ? "+" : "-");
                    seferListesi.SubItems.Add(item.YolculukHizmetiVarMi ? "+" : "-");
                    seferListesi.SubItems.Add(item.KoltukNo.ToString());
                    if (item.BiletDurumu)
                        seferListesi.SubItems.Add(item.Fiyat.ToString());
                    else
                        seferListesi.SubItems.Add("0");
                    seferListesi.SubItems.Add(item.BiletDurumu ? "SATILDI" : "REZERVE");
                    lstBiletGoruntuleme.Items.Add(seferListesi);
                }
            }

        }

        private void btnBiletAra_Click(object sender, EventArgs e)
        {
            BiletSorgulama();
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYeniBiletAl_Click(object sender, EventArgs e)
        {
            tbOtobusOtomasyonu.SelectedIndex = 1;
            OtobusSecimleriniTemizle(panelClassic);
            OtobusSecimleriniTemizle(panelBusiness);
            lstSeferlerDonus.Items.Clear();
            lstSeferlerGidis.Items.Clear();
        }

        private void btnRezervasyonSatinAl_Click(object sender, EventArgs e)
        {

            if (lstBiletGoruntuleme.SelectedItems.Count > 0)
            {
                Bilet rezervasyon = _biletRepository.GetById(sorgulamaBiletId);
                if (!rezervasyon.BiletDurumu)
                {
                    DialogResult sonuc = MessageBox.Show("Bilet ücretiniz " + rezervasyon.Fiyat + " liradır satın almak istiyor musunuz?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sonuc == DialogResult.Yes)
                    {
                        rezervasyon.BiletDurumu = true;
                        _biletRepository.Update(rezervasyon);
                        _uow.SaveChanges();
                        BiletSorgulama();
                    }
                    else
                        MessageBox.Show("Biletinizi sefer saatinden 2 saat önceye kadar alabilirsiniz. İyi günler..");
                }
                else
                    MessageBox.Show("Bilet zaten satın alınmış durumdadır");
            }
            else
                MessageBox.Show("Lütfen işlem yapmak istediğiniz bir bilet seçiniz..");
        }

        private void btnBiletIptalEt_Click(object sender, EventArgs e)
        {
            if (lstBiletGoruntuleme.SelectedItems.Count > 0)
            {
                _biletRepository.Delete(sorgulamaBiletId);
                MessageBox.Show("Bilet silme işlemi başarıyla gerçekleştirildi");
                _uow.SaveChanges();
                BiletSorgulama();
            }
            else
                MessageBox.Show("Lütfen işlem yapmak istediğiniz bir bilet seçiniz..");
        }

        private void btnUyePaneli_Click(object sender, EventArgs e)
        {
            tbOtobusOtomasyonu.SelectedIndex = 0;
        }

        private void lstBiletGoruntuleme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBiletGoruntuleme.SelectedItems.Count > 0)
            {
                sorgulamaBiletId = Convert.ToInt32(lstBiletGoruntuleme.SelectedItems[0].SubItems[0].Text);
                var secilenBilet = _biletRepository.Get(x => x.Id == sorgulamaBiletId);

            }
        }

        private void tpUyeGirisi_Click(object sender, EventArgs e)
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
