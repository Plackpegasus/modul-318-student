using System;
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
        //Objekt transport erstellen
        Transport transport = new Transport();
        public Form1()
        {
            InitializeComponent();

            //Fenstergrösse nicht ändern oder maximieren
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            //wenn txt geändert wird
            Stations station = new Stations();

            //listbox leeren
            listBoxStart.Items.Clear();

            station = transport.GetStations(txtStart.Text);

            foreach (Station xstation in station.StationList)
            { 
                //wenn in txt geschrieben wird Vorschläge in listbox anzeigen
                if (txtStart.Text != " ")
                {
                    listBoxStart.Visible = true;
                    listBoxStart.Items.Add(xstation.Name);
                }
                else
                {
                    listBoxStart.Visible = false;
                }
            }   
        }
        private void listBoxStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStart.Text = Convert.ToString(listBoxStart.SelectedItem);
            listBoxStart.Visible = false;
        }

        private void txtStop_TextChanged(object sender, EventArgs e)
        {
            //wenn txt geändert wird
            Stations station = new Stations();

            //listbox leeren
            listBoxStop.Items.Clear();

            station = transport.GetStations(txtStop.Text);

            foreach (Station xstation in station.StationList)
            {
                //wenn in txt geschrieben wird Vorschläge in listbox anzeigen
                if (txtStop.Text != "")
                {
                    listBoxStop.Visible = true;
                    listBoxStop.Items.Add(xstation.Name);
                }
            }
        }
        private void listBoxStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStop.Text = Convert.ToString(listBoxStop.SelectedItem);
            listBoxStop.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Transport transport = new Transport();
            Connections verbindung = new Connections();

            verbindung.ConnectionList = transport.GetConnections(txtStart.Text, txtStop.Text).ConnectionList;

            foreach (var connection in verbindung.ConnectionList)
                listBoxResult.Items.Add(connection);

        }
    }
}
