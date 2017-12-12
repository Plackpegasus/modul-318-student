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
        Transport transport = new Transport();

        public Form1()
        {
            InitializeComponent();

            //Formatierung GUI Elemente
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Value = DateTime.Today;

            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "HH:mm";
            timePicker.Value = DateTime.Now;

        }

        private void txtStart_TextChanged(object sender, EventArgs e) //wenn Startstartion eingegeben wird
        {
            Stations station = new Stations();

            listBoxStart.Items.Clear();

            station = transport.GetStations(txtStart.Text);
            if (txtStart.Text != "")
            {
                foreach (Station xstation in station.StationList)
                {
                    listBoxStart.Visible = true;
                    listBoxStart.Items.Add(xstation.Name);
                }
            }
            else
            {
                listBoxStart.Visible = false;
            }
        }

        private void listBoxStart_SelectedIndexChanged(object sender, EventArgs e) //Vorschläge für Startstation
        {
            txtStart.Text = Convert.ToString(listBoxStart.SelectedItem);
            listBoxStart.Visible = false;
        }

        private void txtStop_TextChanged(object sender, EventArgs e) //wenn Endstation eingegeben wird
        {
            Stations station = new Stations();

            listBoxStop.Items.Clear();

            station = transport.GetStations(txtStop.Text);

            if (txtStop.Text != "")
            {
                foreach (Station xstation in station.StationList)
                {
                    listBoxStop.Visible = true;
                    listBoxStop.Items.Add(xstation.Name);
                }
            }
            else
            {
                listBoxStop.Visible = false;
            }
        }

        private void listBoxStop_SelectedIndexChanged(object sender, EventArgs e) //Vorschläge für Endstation
        {
            txtStop.Text = Convert.ToString(listBoxStop.SelectedItem);
            listBoxStop.Visible = false;
        }

        private void btnChange_Click(object sender, EventArgs e) //Knopf "<--->" gedrückt
        {
            string station = txtStart.Text;
            txtStart.Text = txtStop.Text;
            txtStop.Text = station;
        }

        private void btnSearch_Click(object sender, EventArgs e) //Knopf "Verbindung suchnen" gedrückt
        {
            listBoxStart.Visible = false;
            listBoxStop.Visible = false;

            datatableResult.Rows.Clear();
            datatableResult.Refresh();

            dataTableBoard.Rows.Clear();
            dataTableBoard.Refresh();

            showConnections();
            showDeparture();
        }

        private void showDeparture() //nächste Abfahrtszeiten der Station anzeigen
        {
            if (txtStart.Text != "" && txtStop.Text == "")
            {
                tabControl.SelectedIndex = 1;
            }
            try //sind Abfahrts- und Ankunftsstation leer --> exception bei staion.StationList[].id
            {
                Stations station = transport.GetStations(txtStart.Text);

                string id = station.StationList[0].Id;

                StationBoardRoot stationBoard = transport.GetStationBoard(txtStart.Text, id, Convert.ToString(datetimeConvert(datePicker.Value, timePicker.Value)));

                foreach (StationBoard board in stationBoard.Entries)
                {
                    var row = dataTableBoard.Rows.Add();

                    dataTableBoard.Rows[row].Cells[0].Value = txtStart.Text;
                    dataTableBoard.Rows[row].Cells[1].Value = board.Name;
                    dataTableBoard.Rows[row].Cells[2].Value = board.To;
                    dataTableBoard.Rows[row].Cells[3].Value = dateConvert(Convert.ToString(board.Stop.Departure));

                }
            }
            catch (Exception)
            {

            }
        }

        private void showConnections() //Verbindungen anzeigen
        {
            if (txtStart.Text == "" && txtStop.Text == "")
            {
                MessageBox.Show("Bitte Abfahrt- und Ankunftsstation eingeben!");
            }

            if (txtStart.Text != "" && txtStop.Text != "")
            {
                Connections verbindung = new Connections();
                verbindung.ConnectionList = transport.GetConnections(txtStart.Text, txtStop.Text, Convert.ToString(datePicker.Value), Convert.ToString(timePicker.Value)).ConnectionList;

                foreach (var connection in verbindung.ConnectionList)
                {
                    var row = datatableResult.Rows.Add();

                    datatableResult.Rows[row].Cells[0].Value = connection.From.Station.Name;
                    datatableResult.Rows[row].Cells[1].Value = connection.To.Station.Name;
                    datatableResult.Rows[row].Cells[2].Value = dateConvert(connection.From.Departure);
                    datatableResult.Rows[row].Cells[3].Value = durationConvert(connection.Duration);
                }
            }
        }

        private string dateConvert(string date) //Konvertierung der Abfahrtszeit
        {
            string sdate = Convert.ToString(Convert.ToDateTime(date)).Remove(16, 3);
            return sdate;
        }

        private string durationConvert(string time) //Konvertierung der Reisedauer
        {
            string s = time.Remove(0, 3);
            s = s.Remove(5, 3);
            return s;
        }

        private DateTime datetimeConvert(DateTime x, DateTime y) //Konvertiert date- und timePicker zu DateTime
        {
            DateTime fullDate = x.Date.Add(y.TimeOfDay);
            return fullDate;
        }
    }
}
