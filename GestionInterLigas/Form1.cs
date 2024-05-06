using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Drawing.Printing;
using GestionInterLigas.entities;
using System.Text.RegularExpressions;
using GestionInterLigas.components;

namespace GestionInterLigas
{
    public partial class Form1 : Form
    {
        public string baseUrl = "";
        private MatchTable matchTable;
        public Form1()
        {
            InitializeComponent();

            matchTable = new MatchTable(null, dataGridView1);

            List<string> torneos = new List<string>();
            torneos.Add("LCF MASCULINO");
            torneos.Add("LCF FEMENINO");
            torneos.Add("AFA FEMENINO");
            torneos.Add("AFA JUVENILES");

            comboBoxLiga.DataSource = torneos;
            
        }

        private void comboBoxLiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            if (comboBoxLiga.SelectedIndex == 0)
            {
                list.Add("1RA - RESERVA - CEBOLLITAS");
                list.Add("INFERIORES PLATINO");
                list.Add("INFERIORES ORO");
                list.Add("INFERIORES PLATA");
                list.Add("INFERIORES BRONCE");
            }
            else if (comboBoxLiga.SelectedIndex == 1)
            {
                list.Add("1RA A Y B");
                list.Add("SUB 17");
                list.Add("SUB 15");
                list.Add("SUB 12");
            }
            else if (comboBoxLiga.SelectedIndex == 2)
            {
                list.Add("1RA A Y B");
            }
            else if (comboBoxLiga.SelectedIndex == 3)
            {
                list.Add("INFERIORES");
            }

            comboBoxDivision.DataSource = list;
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> list = new List<String>();
            for (int i = 1;i<16;i++) { list.Add(i.ToString()); }
            comboBoxFecha.DataSource = list;
        }

        private void comboBoxFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void buttonBuscar_Click(object sender, EventArgs e)
        {

            if (comboBoxLiga.SelectedIndex == 0) {baseUrl = "https://vps-3888229-x.dattaweb.com/ligacordobesa_masculino";}
            else if(comboBoxLiga.SelectedIndex == 1) {baseUrl = "https://vps-3888229-x.dattaweb.com/ligacordobesa_femenino";}
            else if(comboBoxLiga.SelectedIndex == 2) {baseUrl = "https://vps-3888229-x.dattaweb.com/liga_afa_femenina";}
            else{ baseUrl = "https://vps-3888229-x.dattaweb.com/lpf_juveniles_a";}

            Dictionary<string, string> parametros = new Dictionary<string, string>
            {
                { "division", comboBoxDivision.SelectedIndex.ToString() },
                { "fechaLiga", comboBoxFecha.SelectedItem.ToString() }
            };

            var tarea = obtenerPartidos(baseUrl, "pc_get_matchs.php", parametros);

            var partidos = await tarea;
            
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            
            if (comboBoxLiga.SelectedIndex == 0 && comboBoxDivision.SelectedIndex != 0 && comboBoxFecha.SelectedIndex < 5) {
                MessageBox.Show("En divisiones inferiores, el sistema fuciona de la 8va fecha en adelante");
                return;
            }

            matchTable.setRowsAndColumnsTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex);
            matchTable.putListInTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex, partidos);
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {            
            if (!matchTable.checkDateFromTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex))
            {
                MessageBox.Show("ERROR: Hay algunos datos incorrectos");
                return;
            }
      

            List<Partido> matchToUpdate = matchTable.getListFromTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex);

            try
            {
                var tarea = updatePartidos(baseUrl, "pc_update_matchs.php", matchToUpdate); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
           
            if (e.StateChanged == DataGridViewElementStates.Selected && (e.Cell.RowIndex +1) % 3 == 0)
            {
                e.Cell.Selected = false;
                e.Cell.ReadOnly = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.RowIndex) % 3 == 0 && (e.ColumnIndex == 6 || e.ColumnIndex == 6 || e.ColumnIndex == 10))
            {
                matchTable.showDateTimePicker("yyyy-MM-dd", e);
            }
        }

       
        private async Task<List<entities.Partido>> obtenerPartidos(string baseUrl, string nombreArchivo, Dictionary<string, string> parametros)
        {
            try
            {
                ApiService apiService = new ApiService(baseUrl);
                var partidos = await apiService.GetPartidos(nombreArchivo, parametros);
                return partidos;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        private async Task<bool> updatePartidos(string baseUrl, string nombreArchivo,  List<Partido> matchsToUpdate)
        {
            try
            {
                ApiService apiService = new ApiService(baseUrl);
                var partidos = await apiService.UpdateMatch(nombreArchivo, matchsToUpdate);
                return partidos;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
