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

            List<string> torneos = new List<string>
            {
                "LCF MASCULINO",
                "LCF FEMENINO",
                "AFA FEMENINO",
                "AFA JUVENILES",
                "AFA INFANTILES"
            };

            comboBoxLiga.DataSource = torneos;
            
        }

        private void comboBoxLiga_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            if (comboBoxLiga.SelectedIndex == 0)
            {
                groupBox2.Enabled = true;
                radioButton3.Enabled = true;
                label6.Enabled = true;

                list.Add("1RA - RESERVA - CEBOLLITAS");
                list.Add("INFERIORES PLATINO");
                list.Add("INFERIORES ORO");
                list.Add("INFERIORES PLATA");
                list.Add("INFERIORES BRONCE");
            }
            else if (comboBoxLiga.SelectedIndex == 1)
            {
                groupBox2.Enabled = false;
                list.Add("1RA A Y B");
                list.Add("SUB 17");
                list.Add("SUB 15");
                list.Add("SUB 12");
            }
            else if (comboBoxLiga.SelectedIndex == 2)
            {
                groupBox2.Enabled = false;

                list.Add("1RA A Y B");
            }
            else if (comboBoxLiga.SelectedIndex == 3)
            {
                groupBox2.Enabled = true;
                radioButton3.Enabled = false;
                label6.Enabled = false;

                list.Add("INFERIORES");
            }
            else if(comboBoxLiga.SelectedIndex == 4)
            {
                groupBox2.Enabled = false;

                list.Add("2011-2012-2013-2014");
          
            }

            comboBoxDivision.DataSource = list;
        }

        private void comboBoxDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> list = new List<String>();

            for (int i = 1;i<40;i++) { list.Add(i.ToString()); }
            comboBoxFecha.DataSource = list;

        }

        private void comboBoxFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void buttonBuscar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Al presionar buscar, se borraran todos los datos actuales de la tabla. ¿Está seguro de realizar la acción?", "Buscar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (comboBoxLiga.SelectedIndex == 0) { baseUrl = "https://vps-3888229-x.dattaweb.com/ligacordobesa_masculino"; }
                else if (comboBoxLiga.SelectedIndex == 1) { baseUrl = "https://vps-3888229-x.dattaweb.com/ligacordobesa_femenino"; }
                else if (comboBoxLiga.SelectedIndex == 2) { baseUrl = "https://vps-3888229-x.dattaweb.com/liga_afa_femenina"; }
                else if (comboBoxLiga.SelectedIndex == 3) { baseUrl = "https://vps-3888229-x.dattaweb.com/lpf_inferiores_a"; }
                else if (comboBoxLiga.SelectedIndex == 4) { baseUrl = "https://vps-3888229-x.dattaweb.com/liga_afa_juveniles"; }

                Dictionary<string, string> parametros = new Dictionary<string, string>
            {
                { "division", comboBoxDivision.SelectedIndex.ToString() },
                { "fechaLiga", comboBoxFecha.SelectedItem.ToString() }
            };

                if (radioButton1.Checked) parametros.Add("categoria", "0");
                else if (radioButton2.Checked) parametros.Add("categoria", "1");
                else if (radioButton3.Checked) parametros.Add("categoria", "2");
                else parametros.Add("categoria", "-1");


                var tarea = obtenerPartidos(baseUrl, "pc_get_matchs.php", parametros);

                var partidos = await tarea;

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();


                int i = -1;
                if (radioButton1.Checked) i = 0;
                else if (radioButton2.Checked) i = 1;
                else if (radioButton3.Checked) i = 2;

                matchTable.setRowsAndColumnsTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex, i);
                matchTable.putListInTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex, partidos, i);
            }            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de realizar la actualización de los partidos?", "Actualizar partidos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int i = -1;
            

                if (!matchTable.checkDateFromTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex, i))
                {
                    MessageBox.Show("ERROR: Hay algunos datos incorrectos, verifique que a) si colocó resultados, que sea tanto en local como visitantes, b) si coloco una hora, que sea con el formato correcto (HH:MM) y c) que no coloque letras en los resultados", "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                List<Partido> matchToUpdate = matchTable.getListFromTable(comboBoxLiga.SelectedIndex, comboBoxDivision.SelectedIndex, i);
                MessageBox.Show("hpña");
                try
                {
                    var tarea = updatePartidos(baseUrl, "pc_update_matchs.php", matchToUpdate);
                    MessageBox.Show("Partidos actualizados correctamente", "Actualizar partidos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
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
            if (comboBoxLiga.SelectedIndex == 0)
            {
                if (comboBoxDivision.SelectedIndex == 0)
                {
                    if ((e.RowIndex) % 3 == 0 && (e.ColumnIndex == 6 || e.ColumnIndex == 8 || e.ColumnIndex == 10))
                    {
                        matchTable.showDateTimePicker("yyyy-MM-dd", e);
                    }
                }
                else if (radioButton1.Checked)
                {
                    if ((e.RowIndex) % 3 == 0 && (e.ColumnIndex == 12 || e.ColumnIndex == 14 || e.ColumnIndex == 16))
                    {
                        matchTable.showDateTimePicker("yyyy-MM-dd", e);
                    }
                }
                else if (radioButton2.Checked)
                {
                    if ((e.RowIndex) % 3 == 0 && (e.ColumnIndex == 18 || e.ColumnIndex == 20 || e.ColumnIndex == 22))
                    {
                        matchTable.showDateTimePicker("yyyy-MM-dd", e);
                    }
                }
                else if (radioButton3.Checked)
                {
                    if ((e.RowIndex) % 3 == 0 && (e.ColumnIndex == 24 || e.ColumnIndex == 26 || e.ColumnIndex == 28))
                    {
                        matchTable.showDateTimePicker("yyyy-MM-dd", e);
                    }
                }
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
