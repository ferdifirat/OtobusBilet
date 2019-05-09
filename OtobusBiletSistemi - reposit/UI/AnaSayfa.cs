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
        int yonSecimi = 1, otobusTipi = 1;

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
            dtDonus.MinDate = DateTime.Now;
            dtGidis.MinDate = DateTime.Now;
            btnOturumuKapat.Visible = false;
            //for (int i = 1; i <= yolcuSayisi; i++)
            //{
            //    Panel pnlKisi = new Panel();
            //    pnlKisi1.Visible = false;
            //}

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

                var gidisTourList = new List<Sefer>();
                gidisTourList = GetTourList(kalkisDurak, varisDurak, cikisSaati);

                if (gidisTourList.Count > 0)
                {
                    gidisSeferList = gidisTourList;
                    tabControl2.SelectedIndex = 2;
                    yonSecimi = rdoGidisDonus.Checked ? 2 : yonSecimi;

                    if (yonSecimi == 2)
                    {
                        var donusSaati = dtDonus.Value;
                        donusSeferList = GetTourList(varisDurak, kalkisDurak, donusSaati);
                    }
                    FillTourLists();
                    //yonlerde sonradan değişiklikte sıkıntı var incelenmeli
                }
            }
        }

        private List<Sefer> GetTourList(int kalkisDurak, int varisDurak, DateTime cikisSaati)
        {
            var tourList = new List<Sefer>();
            var rotaListe = _rotaRepository.GetAll(x => x.CikisID == kalkisDurak && x.VarisID == varisDurak).ToList();

            var seferListe = _seferRepository.GetAll(x => x.CikisSaati > cikisSaati).ToList();// to do : alttaki foreach'i linq ile yap
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
            LoadSelectSeatPanel(otobus);
        }

        private void LoadSelectSeatPanel(Otobus otobus)
        {
            tabControl2.SelectedIndex = 3;

            if (otobusTipi == 1)
            {
                panelBusiness.Visible = false;
                LoadOtobusSeats(otobus);
            }
            else if (otobusTipi == 2)
            {
                panelClassic.Visible = false;


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
        decimal sayac = 0;
        int butonNo;
        Button btn2;
        private void btnKoltuk_Click(object sender, EventArgs e)
        {

            if (sayac == (yolcuSayisi))
                MessageBox.Show("Girdiğiniz yolcu sayısına ulaştınız daha fazla koltuk seçemezsiniz.");
            else
            {
                Button btn = (Button)sender;
                btn2 = new Button();
                butonNo = Convert.ToInt32(btn.Text);
                if (btn.BackColor == Color.White)
                {
                    if (rdoEkonomiErkek.Checked == true)
                    {
                        if (butonNo % 2 == 0)
                        {
                            btn2.Text = (butonNo - 1).ToString();
                            btn2.Name = "btnEkonomi" + (butonNo - 1);
                           

                            //foreach (Control item in panelClassic.Controls)
                            //{
                            //    if (item is Button)
                            //    {
                            //        if (item.Name==btn2.Name)
                            //        {
                            //            if (item.BackColor != Color.Pink)
                            //            {
                            //                btn.BackColor = Color.Green;
                            //            }
                            //        }
                            //    }
                            //}

                            if (btn2.BackColor != Color.Pink)
                            {
                                btn.Name = "btnEkonomi" + butonNo;
                                btn.BackColor = Color.Green;
                                sayac++;
                            }
                        }
                        else if (butonNo % 2 == 1)
                        {
                            btn2.Text = (butonNo + 1).ToString();
                            btn2.Name = "btnEkonomi" + (butonNo + 1);
                            if (btn2.BackColor != Color.Pink)
                            {
                                btn.Name = "btnEkonomi" + butonNo;
                                btn.BackColor = Color.Green;
                                sayac++;
                            }
                        }

                        //btn.BackColor = Color.Green;
                        //btn.Enabled = false;

                    }
                    else if (rdoEkonomiKadin.Checked == true)
                    {
                        if (butonNo % 2 == 0)
                        {
                            btn2.Text = (butonNo - 1).ToString();
                            btn2.Name = "btnEkonomi" + (butonNo - 1);
                            if (btn2.BackColor != Color.Blue)
                            {
                                btn.Name = "btnEkonomi" + butonNo;
                                btn.BackColor = Color.Gray;
                                sayac++;
                            }
                        }
                        else if (butonNo % 2 == 1)
                        {
                            btn2.Text = (butonNo + 1).ToString();
                            btn2.Name = "btnEkonomi" + (butonNo + 1);
                            if (btn2.BackColor != Color.Blue)
                            {
                                btn.Name = "btnEkonomi" + butonNo;
                                btn.BackColor = Color.Gray;
                                sayac++;
                            }
                        }

                        //btn.BackColor = Color.Green;
                        //btn.Enabled = false;
                    }
                }
                else if (rdoBusinessErkek.Checked == true)
                {
                    if (butonNo % 2 == 0)
                    {
                        btn2.Text = (butonNo - 1).ToString();
                        btn2.Name = "btnBusiness" + (butonNo - 1);
                        if (btn2.BackColor != Color.Blue)
                        {
                            btn.Name = "btnBusiness" + butonNo;
                            btn.BackColor = Color.Gray;
                            sayac++;
                        }
                    }
                    else if (butonNo % 2 == 1)
                    {
                        btn2.Text = (butonNo + 1).ToString();
                        btn2.Name = "btnBusiness" + (butonNo + 1);
                        if (btn2.BackColor != Color.Blue)
                        {
                            btn.Name = "btnBusiness" + butonNo;
                            btn.BackColor = Color.Gray;
                            sayac++;
                        }
                    }
                }
                else if (rdoBusinessKadin.Checked == true)
                {
                    if (butonNo % 2 == 0)
                    {
                        btn2.Text = (butonNo - 1).ToString();
                        btn2.Name = "btnBusiness" + (butonNo - 1);
                        if (btn2.BackColor != Color.Blue)
                        {
                            btn.Name = "btnBusiness" + butonNo;
                            btn.BackColor = Color.Gray;
                            sayac++;
                        }
                    }
                    else if (butonNo % 2 == 1)
                    {
                        btn2.Text = (butonNo + 1).ToString();
                        btn2.Name = "btnBusiness" + (butonNo + 1);
                        if (btn2.BackColor != Color.Blue)
                        {
                            btn.Name = "btnBusiness" + butonNo;
                            btn.BackColor = Color.Gray;
                            sayac++;
                        }
                    }
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
