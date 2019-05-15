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
            //boşkontrol...

        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {

            _kullaniciRepository.Add(new Kullanici
            {
                FirstName = txtAdi.Text,
                SureName = txtSoyadi.Text,
                CitizienshipNumber = txtTCNo.Text,
                Address = rtbAdres.Text,
                Email = txtEmail.Text,
                Gender = rdoErkek.Checked == true ? true : false,
                Password = txtSifre.Text,
                Phone = mtbTelefon.Text,
                KullaniciTipiId = 1
                 
            });

            _uow.SaveChanges();


            MessageBox.Show("Kullanıcı Kaydınız Başarılı olmuştur");
            anaSayfa.Show();
            this.Hide();
        }
    }
}
