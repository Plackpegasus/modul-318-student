﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            Transport transport = new Transport();
            Connections verbindung = new Connections();
            
            verbindung.ConnectionList = transport.GetConnections(txtStart.Text, txtStop.Text).ConnectionList;



        }
    }
}
