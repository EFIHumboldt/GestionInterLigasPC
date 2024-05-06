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

namespace GestionInterLigas
{
    public partial class Form1 : Form
    {
        public string baseUrl = "";
        public Form1()
        {
            InitializeComponent();

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

            if (comboBoxLiga.SelectedIndex == 0)
            {
                if (comboBoxDivision.SelectedIndex == 0)
                {

                    dataGridView1.Columns.Add("ID1", "ID 1");
                    dataGridView1.Columns.Add("ID2", "ID 2");
                    dataGridView1.Columns.Add("ID3", "ID 3");
                    dataGridView1.Columns.Add("EQUIPOS", "EQUIPOS");
                    dataGridView1.Columns.Add("NADA", "");
                    dataGridView1.Columns.Add("P1", "1ra.");
                    dataGridView1.Columns.Add("FH1", "FECHA Y HORA");
                    dataGridView1.Columns.Add("P2", "Res.");
                    dataGridView1.Columns.Add("FH2", "FECHA Y HORA");
                    dataGridView1.Columns.Add("P3", "Ceb.");
                    dataGridView1.Columns.Add("FH3", "FECHA Y HORA");

                    dataGridView1.Columns["ID1"].Visible = false;
                    dataGridView1.Columns["ID2"].Visible = false;
                    dataGridView1.Columns["ID3"].Visible = false;
                    dataGridView1.Columns["EQUIPOS"].Width = 250;
                    dataGridView1.Columns["NADA"].Width = 5;
                    dataGridView1.Columns["P1"].Width = 30;
                    dataGridView1.Columns["P2"].Width = 30;
                    dataGridView1.Columns["P3"].Width = 30;
                    dataGridView1.Columns["FH1"].Width = 100;
                    dataGridView1.Columns["FH2"].Width = 100;
                    dataGridView1.Columns["FH3"].Width = 100;

                    dataGridView1.Columns["ID1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["ID2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["ID3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["EQUIPOS"].DefaultCellStyle.BackColor = Color.LightCyan;
                    dataGridView1.Columns["EQUIPOS"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["P1"].DefaultCellStyle.BackColor = Color.LightCyan;
                    dataGridView1.Columns["P1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["P2"].DefaultCellStyle.BackColor = Color.LightCyan;
                    dataGridView1.Columns["P2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["P3"].DefaultCellStyle.BackColor = Color.LightCyan;
                    dataGridView1.Columns["P3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["FH1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["FH2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["FH3"].SortMode = DataGridViewColumnSortMode.NotSortable;



                    for (int i = 0; i < partidos.Count() - 2; i += 3)
                    {
                        Partido p1 = partidos[i];
                        Partido p2 = partidos[i+1];
                        Partido p3 = partidos[i+2];

                        dataGridView1.Rows.Add(new string[]
                        {
                            p1.Id.ToString(),
                            p2.Id.ToString(),
                            p3.Id.ToString(),
                            p1.NombreLocal.ToString(),
                            "",
                            p1.ResultadoLocal.ToString(),
                            p1.Fecha.ToString(),
                            p2.ResultadoLocal.ToString(),
                            p2.Fecha.ToString(),
                            p3.ResultadoLocal.ToString(),
                            p3.Fecha.ToString()
                        });

                        dataGridView1.Rows.Add(new string[]
                         {
                            p1.Id.ToString(),
                            p2.Id.ToString(),
                            p3.Id.ToString(),
                            p1.NombreVisita.ToString(),
                            "",
                            p1.ResultadoVisita.ToString(),
                            p1.Hora.ToString(),
                            p2.ResultadoVisita.ToString(),
                            p2.Hora.ToString(),
                            p3.ResultadoVisita.ToString(),
                            p3.Hora.ToString()
                         });

                        dataGridView1.Rows.Add();
                    }
                }
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool v = true;
            if (dataGridView1.Rows.Count == 0) v = false;

            for (int i = 0; i < dataGridView1.Rows.Count - 2; i += 3)
            {
                if ((!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value)) && string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i + 1].Cells[5].Value))) ||
                (string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[5].Value)) && !string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i + 1].Cells[5].Value))))
                {
                    v = false;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i + 1].Cells[6].Value)))
                {
                    string hora = Convert.ToString(dataGridView1.Rows[i + 1].Cells[6].Value);
                    if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i + 1].Cells[8].Value)))
                {
                    string hora = Convert.ToString(dataGridView1.Rows[i + 1].Cells[8].Value);
                    if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i + 1].Cells[10].Value)))
                {
                    string hora = Convert.ToString(dataGridView1.Rows[i + 1].Cells[10].Value);
                    if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                }
            }

            if (!v)
            {
                MessageBox.Show("ERROR");
                return;
            }

            List<Partido> matchToUpdate = new List<Partido>();

            for (int i = 0; i < dataGridView1.Rows.Count - 2; i += 3)
            {
                DataGridViewRow r1 = dataGridView1.Rows[i];
                DataGridViewRow r2 = dataGridView1.Rows[i + 1];
                matchToUpdate.Add(
                    new Partido(
                        Convert.ToInt32(r1.Cells["ID1"].Value),
                        Convert.ToString(r1.Cells["P1"].Value),
                        Convert.ToString(r2.Cells["P1"].Value),
                        Convert.ToString(r1.Cells["FH1"].Value),
                        Convert.ToString(r2.Cells["FH1"].Value)));

                matchToUpdate.Add(
                    new Partido(
                        Convert.ToInt32(r1.Cells["ID2"].Value),
                        Convert.ToString(r1.Cells["P2"].Value),
                        Convert.ToString(r2.Cells["P2"].Value),
                        Convert.ToString(r1.Cells["FH2"].Value),
                        Convert.ToString(r2.Cells["FH2"].Value)));

                matchToUpdate.Add(
                    new Partido(
                        Convert.ToInt32(r1.Cells["ID3"].Value),
                        Convert.ToString(r1.Cells["P3"].Value),
                        Convert.ToString(r2.Cells["P3"].Value),
                        Convert.ToString(r1.Cells["FH3"].Value),
                        Convert.ToString(r2.Cells["FH3"].Value)));
            }

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
                // Mostrar el DateTimePicker para seleccionar la fecha
                ShowDateTimePicker("yyyy-MM-dd", e);
            }
        }

        private void ShowDateTimePicker(string format, DataGridViewCellMouseEventArgs e)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = format;
            dateTimePicker.Visible = true;

            Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            dateTimePicker.Location = new Point(rect.X, rect.Y);
            dataGridView1.Controls.Add(dateTimePicker);

            dateTimePicker.CloseUp += (s, args) =>
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = dateTimePicker.Value.ToString(format);
                dataGridView1.Controls.Remove(dateTimePicker);
            };

            dateTimePicker.LostFocus += (s, args) =>
            {
                dataGridView1.Controls.Remove(dateTimePicker);
            };
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

    /*FALTA
     * Si pongo un valor, tiene que ser dos valores si o si -------------------- (LISTO)
     * Hora con formato hh:mm -------------------------------------------------- (LISTO)
     * Si borro un resultado, se tiene que poner como si fuese "", no null ----- (LISTO)
     */
       
}
