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
    public partial class UyeKayitEkrani : Form
    {
        AnaSayfa anaSayfa;
        public UyeKayitEkrani(AnaSayfa form1)
        {
            anaSayfa = form1;
            InitializeComponent();
        }


        private Context _dbContext;
        private IUnitOfWork _uow;
        private IRepository<Kullanici> _kullaniciRepository;

        private void UyeKayitEkrani_Load(object sender, EventArgs e)
        {
            _dbContext = new Context();
            _uow = new EFUnitOfWork(_dbContext);
            _kullaniciRepository = new EFRepository<Kullanici>(_dbContext);

            txtSifre.PasswordChar = '*';
            rdoErkek.Checked = true;

        }
        public bool BosAlanVarMi()
        {
            foreach (Control item in grpUyeKayit.Controls)
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




        private void btnUyeOl_Click_1(object sender, EventArgs e)
        {
            if (BosAlanVarMi() == false)
                MessageBox.Show("Lütfen zorunlu alanları doldurunuz...");
            else
            {
                if (_kullaniciRepository.Get(x => x.Email == txtEmail.Text) != null)
                {
                    MessageBox.Show("Girdiğiniz e-posta ile kayıtlı bir kullanıcı bulunmaktadır.");
                }
                else if (_kullaniciRepository.Get(x => x.CitizienshipNumber == txtTCNo.Text) != null)
                {
                    MessageBox.Show("Girdiğiniz TC no ile kayıtlı bir kullanıcı bulunmaktadır.");
                }
                else
                {
                    Kullanici kullanici = new Kullanici
                    {
                        KullaniciTipiId = 1,
                        FirstName = txtAdi.Text,
                        SureName = txtSoyadi.Text,
                        Gender = rdoErkek.Checked,
                        Address = rtbAdres.Text,
                        Email = txtEmail.Text,
                        Password = txtSifre.Text,
                        Phone = txtSifre.Text
                    };

                    _kullaniciRepository.Add(kullanici);
                    int islem = _uow.SaveChanges();

                    MessageBox.Show("Üyelik işlemi başarıyla gerçekleştirilmiştir.");
                    AnaSayfa afs = new AnaSayfa();
                    afs.Show();
                    this.Hide();



                    //_kullaniciRepository.Add(new Kullanici
                    //{
                    //    FirstName = txtAdi.Text,
                    //    SureName = txtSoyadi.Text,
                    //    CitizienshipNumber = txtTCNo.Text,
                    //    Address = rtbAdres.Text,
                    //    Email = txtEmail.Text,
                    //    Gender = rdoErkek.Checked == true ? true : false,
                    //    Password = txtSifre.Text,
                    //    Phone = mtbTelefon.Text,
                    //    KullaniciTipiId = 1

                    //});

                    //_uow.SaveChanges();


                    //MessageBox.Show("Kullanıcı Kaydınız Başarılı olmuştur");
                    //anaSayfa.Show();
                    //this.Hide();

                }

                }
        }
    }
}
