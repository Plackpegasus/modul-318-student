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

            timePicker.Format = DateTimePickerFormat.Short;
         }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            //wenn txt geändert wird
            Stations station = new Stations();

            //listbox leeren
            listBoxStart.Items.Clear();

            station = transport.GetStations(txtStart.Text);
            if (txtStart.Text != "")
            {
                //wenn in txt geschrieben wird Vorschläge in listbox anzeigen
                foreach (Station xstation in station.StationList)
                {
                    listBoxStart.Visible = true;
                    listBoxStart.Items.Add(xstation.Name);
                }
            }
            else //wenn nicht listbox schliessen
            {
                listBoxStart.Visible = false;
            }
        }

        private void listBoxStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nachdem ort ausgewählt, wird listbox geschlossen
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

            if (txtStop.Text != "")
            {
                //wenn in txt geschrieben wird Vorschläge in listbox anzeigen
                foreach (Station xstation in station.StationList)
                {
                    listBoxStop.Visible = true;
                    listBoxStop.Items.Add(xstation.Name);
                }
            }
            else //wenn nicht listbox schliessen
            {
                listBoxStop.Visible = false;
            }
        }

        private void listBoxStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nachdem ort ausgewählt, wird listbox geschlossen
            txtStop.Text = Convert.ToString(listBoxStop.SelectedItem);
            listBoxStop.Visible = false;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string station = txtStart.Text;
            txtStart.Text = txtStop.Text;
            txtStop.Text = station;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //beim drücken von "verbindung suchen" knopf

            //listboxen schliessen
            listBoxStart.Visible = false;
            listBoxStop.Visible = false;

            showDeparture();
            showConnections();
        }

        private void showDeparture()
        {
            if (txtStart.Text != "" && txtStop.Text == "")
            {
                tabControl.SelectTab(tabPage1);
            }

            //abfahrtstafel 
            Stations station = transport.GetStations(txtStart.Text);

            string id = station.StationList[0].Id;
            StationBoardRoot stationBoard = transport.GetStationBoard(txtStart.Text, id);

            foreach (StationBoard board in stationBoard.Entries)
            {
                var row = dataTableBoard.Rows.Add();

                //in entsprechende zellen einfügen
                dataTableBoard.Rows[row].Cells[0].Value = board.Name;
                dataTableBoard.Rows[row].Cells[1].Value = board.To;

            }

        }

        private void showConnections()
        {
            if (txtStart.Text == "" && txtStop.Text == "")
            {
                MessageBox.Show("Bitte Abfahrt- und Ankunftsstation eingeben!");
            }
            if(txtStart.Text != "" && txtStop.Text != "") //wenn nicht, verbindung suchen
            {
                //new connection
                Connections verbindung = new Connections();
                verbindung.ConnectionList = transport.GetConnections(txtStart.Text, txtStop.Text).ConnectionList;

                //für jede connection in list
                foreach (var connection in verbindung.ConnectionList)
                {
                    var row = datatableResult.Rows.Add();

                    //in entsprechende zellen einfügen
                    datatableResult.Rows[row].Cells[0].Value = connection.From.Station.Name;
                    datatableResult.Rows[row].Cells[1].Value = connection.To.Station.Name;
                    datatableResult.Rows[row].Cells[2].Value = dateConvert(connection.From.Departure);
                    datatableResult.Rows[row].Cells[3].Value = durationConvert(connection.Duration);
                }
            }
        }

        private string dateConvert(string date)
        {            
            string sdate = Convert.ToString(Convert.ToDateTime(date)).Remove(16,3);
            return sdate;
        }

        private string durationConvert(string time)
        {
            string s = time.Remove(0, 3);
            s = s.Remove(5, 3);
            return s;
        }
    }
}
