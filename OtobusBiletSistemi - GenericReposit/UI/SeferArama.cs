﻿using System;
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
    public partial class SeferArama : Form
    {
        public SeferArama()
        {
            InitializeComponent();
        }

        private void SeferArama_Load(object sender, EventArgs e)
        {
            nmrYolcuSayisi.Value = 1;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
