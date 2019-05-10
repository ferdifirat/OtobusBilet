using Dal.Repository;
using Data;
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
    public partial class Form1 : Form
    {
        DurakServis biletler = new DurakServis();
        public Form1()
        {
            biletler.Add(new Durak
            {
                  DurakAdi="Ferdi",
                  

            });
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Eğer kadın erkek veya rezerve edildiyse tıklanamaz..
            //seçili renginde tıklanabilir tekrar tıklanıldığında boşa düşer..

        }
    }
}
