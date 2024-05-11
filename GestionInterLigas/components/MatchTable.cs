using GestionInterLigas.entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInterLigas.components
{
    internal class MatchTable
    {
        private List<Partido> listMatchs;
        private DataGridView tabla;
        public MatchTable(List<Partido> l, DataGridView e) { 
         
            this.listMatchs = l;
            this.tabla = e;
        }

        public List<Partido> getListFromTable(int torneo, int division, int cat)
        {
            List<Partido> list = new List<Partido>();
            if(torneo == 0)
            {
                if (division == 0)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        DataGridViewRow r1 = tabla.Rows[i];
                        DataGridViewRow r2 = tabla.Rows[i + 1];
                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID1"].Value),
                                Convert.ToString(r1.Cells["P1"].Value),
                                Convert.ToString(r2.Cells["P1"].Value),
                                Convert.ToString(r1.Cells["FH1"].Value),
                                Convert.ToString(r2.Cells["FH1"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID2"].Value),
                                Convert.ToString(r1.Cells["P2"].Value),
                                Convert.ToString(r2.Cells["P2"].Value),
                                Convert.ToString(r1.Cells["FH2"].Value),
                                Convert.ToString(r2.Cells["FH2"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID3"].Value),
                                Convert.ToString(r1.Cells["P3"].Value),
                                Convert.ToString(r2.Cells["P3"].Value),
                                Convert.ToString(r1.Cells["FH3"].Value),
                                Convert.ToString(r2.Cells["FH3"].Value)));
                    }
                }
                else if (cat == 0)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        DataGridViewRow r1 = tabla.Rows[i];
                        DataGridViewRow r2 = tabla.Rows[i + 1];
                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID1"].Value),
                                Convert.ToString(r1.Cells["P1"].Value),
                                Convert.ToString(r2.Cells["P1"].Value),
                                Convert.ToString(r1.Cells["FH1"].Value),
                                Convert.ToString(r2.Cells["FH1"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID2"].Value),
                                Convert.ToString(r1.Cells["P2"].Value),
                                Convert.ToString(r2.Cells["P2"].Value),
                                Convert.ToString(r1.Cells["FH2"].Value),
                                Convert.ToString(r2.Cells["FH2"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID3"].Value),
                                Convert.ToString(r1.Cells["P3"].Value),
                                Convert.ToString(r2.Cells["P3"].Value),
                                Convert.ToString(r1.Cells["FH3"].Value),
                                Convert.ToString(r2.Cells["FH3"].Value)));
                    }
                }
                else if (cat == 1)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        DataGridViewRow r1 = tabla.Rows[i];
                        DataGridViewRow r2 = tabla.Rows[i + 1];
                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID4"].Value),
                                Convert.ToString(r1.Cells["P4"].Value),
                                Convert.ToString(r2.Cells["P4"].Value),
                                Convert.ToString(r1.Cells["FH4"].Value),
                                Convert.ToString(r2.Cells["FH4"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID5"].Value),
                                Convert.ToString(r1.Cells["P5"].Value),
                                Convert.ToString(r2.Cells["P5"].Value),
                                Convert.ToString(r1.Cells["FH5"].Value),
                                Convert.ToString(r2.Cells["FH5"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID6"].Value),
                                Convert.ToString(r1.Cells["P6"].Value),
                                Convert.ToString(r2.Cells["P6"].Value),
                                Convert.ToString(r1.Cells["FH6"].Value),
                                Convert.ToString(r2.Cells["FH6"].Value)));
                    }
                }
                else if (cat == 2)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        DataGridViewRow r1 = tabla.Rows[i];
                        DataGridViewRow r2 = tabla.Rows[i + 1];
                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID7"].Value),
                                Convert.ToString(r1.Cells["P7"].Value),
                                Convert.ToString(r2.Cells["P7"].Value),
                                Convert.ToString(r1.Cells["FH7"].Value),
                                Convert.ToString(r2.Cells["FH7"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID8"].Value),
                                Convert.ToString(r1.Cells["P8"].Value),
                                Convert.ToString(r2.Cells["P8"].Value),
                                Convert.ToString(r1.Cells["FH8"].Value),
                                Convert.ToString(r2.Cells["FH8"].Value)));

                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID9"].Value),
                                Convert.ToString(r1.Cells["P9"].Value),
                                Convert.ToString(r2.Cells["P9"].Value),
                                Convert.ToString(r1.Cells["FH9"].Value),
                                Convert.ToString(r2.Cells["FH9"].Value)));
                    }
                }
               
            }
            else if (torneo == 1)
            {
                if (division == 0 ||  division == 1 || division == 2 || division == 3)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        DataGridViewRow r1 = tabla.Rows[i];
                        DataGridViewRow r2 = tabla.Rows[i + 1];
                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID1"].Value),
                                Convert.ToString(r1.Cells["P1"].Value),
                                Convert.ToString(r2.Cells["P1"].Value),
                                Convert.ToString(r1.Cells["FH1"].Value),
                                Convert.ToString(r2.Cells["FH1"].Value)));

                    }
                }         
            }
            else if (torneo == 2)
            {
                if (division == 0)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        DataGridViewRow r1 = tabla.Rows[i];
                        DataGridViewRow r2 = tabla.Rows[i + 1];
                        list.Add(
                            new Partido(
                                Convert.ToInt32(r1.Cells["ID1"].Value),
                                Convert.ToString(r1.Cells["P1"].Value),
                                Convert.ToString(r2.Cells["P1"].Value),
                                Convert.ToString(r1.Cells["FH1"].Value),
                                Convert.ToString(r2.Cells["FH1"].Value)));

                    }
                }
            }
            else if (torneo == 3)
            {
                for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                {
                    DataGridViewRow r1 = tabla.Rows[i];
                    DataGridViewRow r2 = tabla.Rows[i + 1];
                    list.Add(
                        new Partido(
                            Convert.ToInt32(r1.Cells["ID1"].Value),
                            Convert.ToString(r1.Cells["P1"].Value),
                            Convert.ToString(r2.Cells["P1"].Value),
                            Convert.ToString(r1.Cells["FH1"].Value),
                            Convert.ToString(r2.Cells["FH1"].Value)));

                    list.Add(
                        new Partido(
                            Convert.ToInt32(r1.Cells["ID2"].Value),
                            Convert.ToString(r1.Cells["P2"].Value),
                            Convert.ToString(r2.Cells["P2"].Value),
                            Convert.ToString(r1.Cells["FH2"].Value),
                            Convert.ToString(r2.Cells["FH2"].Value)));

                    list.Add(
                        new Partido(
                            Convert.ToInt32(r1.Cells["ID3"].Value),
                            Convert.ToString(r1.Cells["P3"].Value),
                            Convert.ToString(r2.Cells["P3"].Value),
                            Convert.ToString(r1.Cells["FH3"].Value),
                            Convert.ToString(r2.Cells["FH3"].Value)));
                }
            }
            return list;
        }
        public void putListInTable(int torneo, int division, List<Partido> l, int cat)
        {
            listMatchs = l;

            if(torneo == 0)
            {
                if(division == 0)
                {
                    for (int i = 0; i < listMatchs.Count() - 2; i += 3)
                    {
                        Partido p1 = listMatchs[i];
                        Partido p2 = listMatchs[i + 1];
                        Partido p3 = listMatchs[i + 2];

                        tabla.Rows.Add(new string[]
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

                        tabla.Rows.Add(new string[]
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

                        tabla.Rows.Add();
                    }
                }
                else
                {
                    if(cat == 0)
                    {
                        for (int i = 0; i < listMatchs.Count() - 2; i += 3)
                        {
                            Partido p1 = listMatchs[i];
                            Partido p2 = listMatchs[i + 1];
                            Partido p3 = listMatchs[i + 2];
                            //Partido p4 = listMatchs[i + 3];
                            //Partido p5 = listMatchs[i + 4];
                            //Partido p6 = listMatchs[i + 5];
                            //Partido p7 = listMatchs[i + 6];
                            //Partido p8 = listMatchs[i + 7];
                            //Partido p9 = listMatchs[i + 8];

                            tabla.Rows.Add(new string[]
                            {
                            p1.Id.ToString(),
                            p2.Id.ToString(),
                            p3.Id.ToString(),"","","","","","",
                            //p4.Id.ToString(),
                            //p5.Id.ToString(),
                            //p6.Id.ToString(),
                            //p7.Id.ToString(),
                            //p8.Id.ToString(),
                            //p9.Id.ToString(),

                            p1.NombreLocal.ToString(),
                            "",
                            p1.ResultadoLocal.ToString(),
                            p1.Fecha.ToString(),
                            p2.ResultadoLocal.ToString(),
                            p2.Fecha.ToString(),
                            p3.ResultadoLocal.ToString(),
                            p3.Fecha.ToString(),"","","","","","","","","","","",""
                                //p4.ResultadoLocal.ToString(),
                                //p4.Fecha.ToString(),
                                //p5.ResultadoLocal.ToString(),
                                //p5.Fecha.ToString(),
                                //p6.ResultadoLocal.ToString(),
                                //p6.Fecha.ToString(),
                                //p7.ResultadoLocal.ToString(),
                                //p7.Fecha.ToString(),
                                //p8.ResultadoLocal.ToString(),
                                //p8.Fecha.ToString(),
                                //p9.ResultadoLocal.ToString(),
                                //p9.Fecha.ToString()
                            });

                            tabla.Rows.Add(new string[]
                             {
                            p1.Id.ToString(),
                            p2.Id.ToString(),
                            p3.Id.ToString(),"","","","","","",
                            //p4.Id.ToString(),
                            //p5.Id.ToString(),
                            //p6.Id.ToString(),
                            //p7.Id.ToString(),
                            //p8.Id.ToString(),
                            //p9.Id.ToString(),

                            p1.NombreVisita.ToString(),
                            "",
                            p1.ResultadoVisita.ToString(),
                            p1.Hora.ToString(),
                            p2.ResultadoVisita.ToString(),
                            p2.Hora.ToString(),
                            p3.ResultadoVisita.ToString(),
                            p3.Hora.ToString(),"","","","","","","","","","","",""
                                 //p4.ResultadoVisita.ToString(),
                                 //p4.Hora.ToString(),
                                 //p5.ResultadoVisita.ToString(),
                                 //p5.Hora.ToString(),
                                 //p6.ResultadoVisita.ToString(),
                                 //p6.Hora.ToString(),
                                 //p7.ResultadoVisita.ToString(),
                                 //p7.Hora.ToString(),
                                 //p8.ResultadoVisita.ToString(),
                                 //p8.Hora.ToString(),
                                 //p9.ResultadoVisita.ToString(),
                                 //p9.Hora.ToString()
                             });

                            tabla.Rows.Add();
                        }
                    }
                    else if (cat == 1)
                    {
                        for (int i = 0; i < listMatchs.Count() - 2; i += 3)
                        {
                            //Partido p1 = listMatchs[i];
                            //Partido p2 = listMatchs[i + 1];
                            //Partido p3 = listMatchs[i + 2];
                            Partido p4 = listMatchs[i];
                            Partido p5 = listMatchs[i + 1];
                            Partido p6 = listMatchs[i + 2];
                            //Partido p7 = listMatchs[i + 6];
                            //Partido p8 = listMatchs[i + 7];
                            //Partido p9 = listMatchs[i + 8];

                            tabla.Rows.Add(new string[]
                            {
                            //p1.Id.ToString(),
                            //p2.Id.ToString(),
                            //p3.Id.ToString(),
                            "","","",
                            p4.Id.ToString(),
                            p5.Id.ToString(),
                            p6.Id.ToString(),
                            "","","",
                            //p7.Id.ToString(),
                            //p8.Id.ToString(),
                            //p9.Id.ToString(),

                            p4.NombreLocal.ToString(),
                            "",
                            //p1.ResultadoLocal.ToString(),
                            //p1.Fecha.ToString(),
                            //p2.ResultadoLocal.ToString(),
                            //p2.Fecha.ToString(),
                            //p3.ResultadoLocal.ToString(),
                            //p3.Fecha.ToString(),
                            "","","","","","",
                                p4.ResultadoLocal.ToString(),
                                p4.Fecha.ToString(),
                                p5.ResultadoLocal.ToString(),
                                p5.Fecha.ToString(),
                                p6.ResultadoLocal.ToString(),
                                p6.Fecha.ToString(),
                            "","","","","",""
                                //p7.ResultadoLocal.ToString(),
                                //p7.Fecha.ToString(),
                                //p8.ResultadoLocal.ToString(),
                                //p8.Fecha.ToString(),
                                //p9.ResultadoLocal.ToString(),
                                //p9.Fecha.ToString()
                            });

                            tabla.Rows.Add(new string[]
                             {
                            //p1.Id.ToString(),
                            //p2.Id.ToString(),
                            //p3.Id.ToString(),
                            "","","",
                            p4.Id.ToString(),
                            p5.Id.ToString(),
                            p6.Id.ToString(),
                            "","","",
                            //p7.Id.ToString(),
                            //p8.Id.ToString(),
                            //p9.Id.ToString(),

                            p4.NombreVisita.ToString(),
                            "",
                            //p1.ResultadoVisita.ToString(),
                            //p1.Hora.ToString(),
                            //p2.ResultadoVisita.ToString(),
                            //p2.Hora.ToString(),
                            //p3.ResultadoVisita.ToString(),
                            //p3.Hora.ToString(),
                            "","","","","","",
                            
                                 p4.ResultadoVisita.ToString(),
                                 p4.Hora.ToString(),
                                 p5.ResultadoVisita.ToString(),
                                 p5.Hora.ToString(),
                                 p6.ResultadoVisita.ToString(),
                                 p6.Hora.ToString(),
                            "","","","","",""
                                 //p7.ResultadoVisita.ToString(),
                                 //p7.Hora.ToString(),
                                 //p8.ResultadoVisita.ToString(),
                                 //p8.Hora.ToString(),
                                 //p9.ResultadoVisita.ToString(),
                                 //p9.Hora.ToString()
                             });

                            tabla.Rows.Add();
                        }
                    }
                    else if (cat == 2)
                    {
                        for (int i = 0; i < listMatchs.Count() - 2; i += 3)
                        {
                            //Partido p1 = listMatchs[i];
                            //Partido p2 = listMatchs[i + 1];
                            //Partido p3 = listMatchs[i + 2];
                            //Partido p4 = listMatchs[i + 3];
                            //Partido p5 = listMatchs[i + 4];
                            //Partido p6 = listMatchs[i + 5];
                            Partido p7 = listMatchs[i];
                            Partido p8 = listMatchs[i + 1];
                            Partido p9 = listMatchs[i + 2];

                            tabla.Rows.Add(new string[]
                            {
                            //p1.Id.ToString(),
                            //p2.Id.ToString(),
                            //p3.Id.ToString(),
                            "","","",
                            //p4.Id.ToString(),
                            //p5.Id.ToString(),
                            //p6.Id.ToString(),
                            "","","",
                            p7.Id.ToString(),
                            p8.Id.ToString(),
                            p9.Id.ToString(),

                            p7.NombreLocal.ToString(),
                            "",
                            //p1.ResultadoLocal.ToString(),
                            //p1.Fecha.ToString(),
                            //p2.ResultadoLocal.ToString(),
                            //p2.Fecha.ToString(),
                            //p3.ResultadoLocal.ToString(),
                            //p3.Fecha.ToString(),
                            "","","","","","",
                            //p4.ResultadoLocal.ToString(),
                            //p4.Fecha.ToString(),
                            //p5.ResultadoLocal.ToString(),
                            //p5.Fecha.ToString(),
                            //p6.ResultadoLocal.ToString(),
                            //p6.Fecha.ToString(),
                            "","","","","","",
                              p7.ResultadoLocal.ToString(),
                              p7.Fecha.ToString(),
                              p8.ResultadoLocal.ToString(),
                              p8.Fecha.ToString(),
                              p9.ResultadoLocal.ToString(),
                              p9.Fecha.ToString()
                            });

                            tabla.Rows.Add(new string[]
                             {
                            //p1.Id.ToString(),
                            //p2.Id.ToString(),
                            //p3.Id.ToString(),
                            "","","",
                            //p4.Id.ToString(),
                            //p5.Id.ToString(),
                            //p6.Id.ToString(),
                            "","","",
                            p7.Id.ToString(),
                            p8.Id.ToString(),
                            p9.Id.ToString(),

                            p7.NombreVisita.ToString(),
                            "",
                            //p1.ResultadoVisita.ToString(),
                            //p1.Hora.ToString(),
                            //p2.ResultadoVisita.ToString(),
                            //p2.Hora.ToString(),
                            //p3.ResultadoVisita.ToString(),
                            //p3.Hora.ToString(),
                            "","","","","","",

                            //p4.ResultadoVisita.ToString(),
                            //p4.Hora.ToString(),
                            //p5.ResultadoVisita.ToString(),
                            //p5.Hora.ToString(),
                            //p6.ResultadoVisita.ToString(),
                            //p6.Hora.ToString(),
                            "","","","","","",
                                 p7.ResultadoVisita.ToString(),
                                 p7.Hora.ToString(),
                                 p8.ResultadoVisita.ToString(),
                                 p8.Hora.ToString(),
                                 p9.ResultadoVisita.ToString(),
                                 p9.Hora.ToString()
                             });

                            tabla.Rows.Add();
                        }
                    }
                    
                }
            }
            else if (torneo == 1)
            {
                if (division == 0 || division == 1 || division == 2 || division == 3)
                {
                    for (int i = 0; i < listMatchs.Count() - 1; i ++)
                    {
                        Partido p1 = listMatchs[i];

                        tabla.Rows.Add(new string[]
                        {
                            p1.Id.ToString(),
                            p1.NombreLocal.ToString(),
                            "",
                            p1.ResultadoLocal.ToString(),
                            p1.Fecha.ToString(),
                            
                        });

                        tabla.Rows.Add(new string[]
                         {
                            p1.Id.ToString(),
                            p1.NombreVisita.ToString(),
                            "",
                            p1.ResultadoVisita.ToString(),
                            p1.Hora.ToString(),
                         });

                        tabla.Rows.Add();
                    }
                }
            }
            else if (torneo == 2)
            {
                if (division == 0)
                {
                    for (int i = 0; i < listMatchs.Count() - 1; i++)
                    {
                        Partido p1 = listMatchs[i];

                        tabla.Rows.Add(new string[]
                        {
                            p1.Id.ToString(),
                            p1.NombreLocal.ToString(),
                            "",
                            p1.ResultadoLocal.ToString(),
                            p1.Fecha.ToString(),

                        });

                        tabla.Rows.Add(new string[]
                         {
                            p1.Id.ToString(),
                            p1.NombreVisita.ToString(),
                            "",
                            p1.ResultadoVisita.ToString(),
                            p1.Hora.ToString(),
                         });

                        tabla.Rows.Add();
                    }
                }
            }
            else if (torneo == 3)
            {
                if (cat ==0 || cat == 1)
                {
                    for (int i = 0; i < listMatchs.Count() - 2; i += 3)
                    {
                        Partido p1 = listMatchs[i];
                        Partido p2 = listMatchs[i + 1];
                        Partido p3 = listMatchs[i + 2];

                        tabla.Rows.Add(new string[]
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

                        tabla.Rows.Add(new string[]
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

                        tabla.Rows.Add();
                    }
                }  
            }
        }

        public void setRowsAndColumnsTable(int torneo, int division, int cat)
        {
            if (torneo == 0)
            {
                if (division == 0)
                {

                    tabla.Columns.Add("ID1", "ID 1");
                    tabla.Columns.Add("ID2", "ID 2");
                    tabla.Columns.Add("ID3", "ID 3");
                    tabla.Columns.Add("EQUIPOS", "EQUIPOS");
                    tabla.Columns.Add("NADA", "");
                    tabla.Columns.Add("P1", "1ra.");
                    tabla.Columns.Add("FH1", "FECHA Y HORA");
                    tabla.Columns.Add("P2", "Res.");
                    tabla.Columns.Add("FH2", "FECHA Y HORA");
                    tabla.Columns.Add("P3", "Ceb.");
                    tabla.Columns.Add("FH3", "FECHA Y HORA");

                    tabla.Columns["ID1"].Visible = false;
                    tabla.Columns["ID2"].Visible = false;
                    tabla.Columns["ID3"].Visible = false;
                    tabla.Columns["EQUIPOS"].Width = 250;
                    tabla.Columns["NADA"].Width = 5;
                    tabla.Columns["P1"].Width = 30;
                    tabla.Columns["P2"].Width = 30;
                    tabla.Columns["P3"].Width = 30;
                    tabla.Columns["FH1"].Width = 100;
                    tabla.Columns["FH2"].Width = 100;
                    tabla.Columns["FH3"].Width = 100;

                    tabla.Columns["ID1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["EQUIPOS"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["EQUIPOS"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P1"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P2"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P3"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH3"].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
                else if (division == 1 || division == 2 || division == 3 || division == 4) {

                    
                    tabla.Columns.Add("ID1", "ID 1");
                    tabla.Columns.Add("ID2", "ID 2");
                    tabla.Columns.Add("ID3", "ID 3");
                    tabla.Columns.Add("ID4", "ID 4");
                    tabla.Columns.Add("ID5", "ID 5");
                    tabla.Columns.Add("ID6", "ID 6");
                    tabla.Columns.Add("ID7", "ID 7");
                    tabla.Columns.Add("ID8", "ID 8");
                    tabla.Columns.Add("ID9", "ID 9");

                    tabla.Columns.Add("EQUIPOS", "EQUIPOS");
                    tabla.Columns.Add("NADA", "");

                    tabla.Columns.Add("P1", "4°");
                    tabla.Columns.Add("FH1", "F/H");
                    tabla.Columns.Add("P2", "5°");
                    tabla.Columns.Add("FH2", "F/H");
                    tabla.Columns.Add("P3", "6°");
                    tabla.Columns.Add("FH3", "F/H");
                    tabla.Columns.Add("P4", "7°");
                    tabla.Columns.Add("FH4", "F/H");
                    tabla.Columns.Add("P5", "8°");
                    tabla.Columns.Add("FH5", "F/H");
                    tabla.Columns.Add("P6", "9°");
                    tabla.Columns.Add("FH6", "F/H");
                    tabla.Columns.Add("P7", "10°");
                    tabla.Columns.Add("FH7", "F/H");
                    tabla.Columns.Add("P8", "11°");
                    tabla.Columns.Add("FH8", "F/H");
                    tabla.Columns.Add("P9", "12°");
                    tabla.Columns.Add("FH9", "F/H");

                    tabla.Columns["ID1"].Visible = false;
                    tabla.Columns["ID2"].Visible = false;
                    tabla.Columns["ID3"].Visible = false;
                    tabla.Columns["ID4"].Visible = false;
                    tabla.Columns["ID5"].Visible = false;
                    tabla.Columns["ID6"].Visible = false;
                    tabla.Columns["ID7"].Visible = false;
                    tabla.Columns["ID8"].Visible = false;
                    tabla.Columns["ID9"].Visible = false;

                    
                    if (cat == 0)
                    {
                        tabla.Columns["P4"].Visible = false;
                        tabla.Columns["P5"].Visible = false;
                        tabla.Columns["P6"].Visible = false;
                        tabla.Columns["P7"].Visible = false;
                        tabla.Columns["P8"].Visible = false;
                        tabla.Columns["P9"].Visible = false;
                        tabla.Columns["FH4"].Visible = false;
                        tabla.Columns["FH5"].Visible = false;
                        tabla.Columns["FH6"].Visible = false;
                        tabla.Columns["FH7"].Visible = false;
                        tabla.Columns["FH8"].Visible = false;
                        tabla.Columns["FH9"].Visible = false;
                    }
                    else if (cat == 1)
                    {
                        tabla.Columns["P1"].Visible = false;
                        tabla.Columns["P2"].Visible = false;
                        tabla.Columns["P3"].Visible = false;
                        tabla.Columns["P7"].Visible = false;
                        tabla.Columns["P8"].Visible = false;
                        tabla.Columns["P9"].Visible = false;
                        tabla.Columns["FH1"].Visible = false;
                        tabla.Columns["FH2"].Visible = false;
                        tabla.Columns["FH3"].Visible = false;
                        tabla.Columns["FH7"].Visible = false;
                        tabla.Columns["FH8"].Visible = false;
                        tabla.Columns["FH9"].Visible = false;
                    }
                    else if (cat == 2)
                    {
                        tabla.Columns["P1"].Visible = false;
                        tabla.Columns["P2"].Visible = false;
                        tabla.Columns["P3"].Visible = false;
                        tabla.Columns["P4"].Visible = false;
                        tabla.Columns["P5"].Visible = false;
                        tabla.Columns["P6"].Visible = false;
                        tabla.Columns["FH1"].Visible = false;
                        tabla.Columns["FH2"].Visible = false;
                        tabla.Columns["FH3"].Visible = false;
                        tabla.Columns["FH4"].Visible = false;
                        tabla.Columns["FH5"].Visible = false;
                        tabla.Columns["FH6"].Visible = false;
                    }
                   

                    tabla.Columns["EQUIPOS"].Width = 250;
                    tabla.Columns["NADA"].Width = 5;

                    tabla.Columns["P1"].Width = 25;
                    tabla.Columns["P2"].Width = 25;
                    tabla.Columns["P3"].Width = 25;
                    tabla.Columns["P4"].Width = 25;
                    tabla.Columns["P5"].Width = 25;
                    tabla.Columns["P6"].Width = 25;
                    tabla.Columns["P7"].Width = 25;
                    tabla.Columns["P8"].Width = 25;
                    tabla.Columns["P9"].Width = 25;

                    tabla.Columns["FH1"].Width = 80;
                    tabla.Columns["FH2"].Width = 80;
                    tabla.Columns["FH3"].Width = 80;
                    tabla.Columns["FH4"].Width = 80;
                    tabla.Columns["FH5"].Width = 80;
                    tabla.Columns["FH6"].Width = 80;
                    tabla.Columns["FH7"].Width = 80;
                    tabla.Columns["FH8"].Width = 80;
                    tabla.Columns["FH9"].Width = 80;

                    tabla.Columns["ID1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID4"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID5"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID6"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID7"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID8"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID9"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    tabla.Columns["EQUIPOS"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["EQUIPOS"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    tabla.Columns["P1"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P2"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P3"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P4"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P4"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P5"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P5"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P6"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P6"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P7"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P7"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P8"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P8"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P9"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P9"].SortMode = DataGridViewColumnSortMode.NotSortable;

                    tabla.Columns["FH1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH4"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH5"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH6"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH7"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH8"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH9"].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
            }
            else if (torneo == 1)
            {
                if (division == 0 || division == 1 || division == 2 || division == 3)
                {
                    tabla.Columns.Add("ID1", "ID 1");
                    tabla.Columns.Add("EQUIPOS", "EQUIPOS");
                    tabla.Columns.Add("NADA", "");
                    tabla.Columns.Add("P1", "1ra.");
                    tabla.Columns.Add("FH1", "FECHA Y HORA");

                    tabla.Columns["ID1"].Visible = false;
                    tabla.Columns["EQUIPOS"].Width = 250;
                    tabla.Columns["NADA"].Width = 5;
                    tabla.Columns["P1"].Width = 30;
                    tabla.Columns["FH1"].Width = 100;

                    tabla.Columns["ID1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["EQUIPOS"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["EQUIPOS"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P1"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P1"].SortMode = DataGridViewColumnSortMode.NotSortable;  
                    tabla.Columns["FH1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    
                }   
            }   
            else if (torneo == 2)
            {
                tabla.Columns.Add("ID1", "ID 1");
                tabla.Columns.Add("EQUIPOS", "EQUIPOS");
                tabla.Columns.Add("NADA", "");
                tabla.Columns.Add("P1", "1ra.");
                tabla.Columns.Add("FH1", "FECHA Y HORA");

                tabla.Columns["ID1"].Visible = false;
                tabla.Columns["EQUIPOS"].Width = 250;
                tabla.Columns["NADA"].Width = 5;
                tabla.Columns["P1"].Width = 30;
                tabla.Columns["FH1"].Width = 100;

                tabla.Columns["ID1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                tabla.Columns["EQUIPOS"].DefaultCellStyle.BackColor = Color.LightCyan;
                tabla.Columns["EQUIPOS"].SortMode = DataGridViewColumnSortMode.NotSortable;
                tabla.Columns["P1"].DefaultCellStyle.BackColor = Color.LightCyan;
                tabla.Columns["P1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                tabla.Columns["FH1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }   
            else if (torneo == 3)
            {
                if (cat == 0)
                {
                    tabla.Columns.Add("ID1", "ID 1");
                    tabla.Columns.Add("ID2", "ID 2");
                    tabla.Columns.Add("ID3", "ID 3");
                    tabla.Columns.Add("EQUIPOS", "EQUIPOS");
                    tabla.Columns.Add("NADA", "");
                    tabla.Columns.Add("P1", "4º");
                    tabla.Columns.Add("FH1", "FECHA Y HORA");
                    tabla.Columns.Add("P2", "5º");
                    tabla.Columns.Add("FH2", "FECHA Y HORA");
                    tabla.Columns.Add("P3", "6º");
                    tabla.Columns.Add("FH3", "FECHA Y HORA");

                    tabla.Columns["ID1"].Visible = false;
                    tabla.Columns["ID2"].Visible = false;
                    tabla.Columns["ID3"].Visible = false;
                    tabla.Columns["EQUIPOS"].Width = 250;
                    tabla.Columns["NADA"].Width = 5;
                    tabla.Columns["P1"].Width = 30;
                    tabla.Columns["P2"].Width = 30;
                    tabla.Columns["P3"].Width = 30;
                    tabla.Columns["FH1"].Width = 100;
                    tabla.Columns["FH2"].Width = 100;
                    tabla.Columns["FH3"].Width = 100;

                    tabla.Columns["ID1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["EQUIPOS"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["EQUIPOS"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P1"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P2"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P3"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                else if (cat == 1)
                {
                    tabla.Columns.Add("ID1", "ID 1");
                    tabla.Columns.Add("ID2", "ID 2");
                    tabla.Columns.Add("ID3", "ID 3");
                    tabla.Columns.Add("EQUIPOS", "EQUIPOS");
                    tabla.Columns.Add("NADA", "");
                    tabla.Columns.Add("P1", "7º");
                    tabla.Columns.Add("FH1", "FECHA Y HORA");
                    tabla.Columns.Add("P2", "8º");
                    tabla.Columns.Add("FH2", "FECHA Y HORA");
                    tabla.Columns.Add("P3", "9º");
                    tabla.Columns.Add("FH3", "FECHA Y HORA");

                    tabla.Columns["ID1"].Visible = false;
                    tabla.Columns["ID2"].Visible = false;
                    tabla.Columns["ID3"].Visible = false;
                    tabla.Columns["EQUIPOS"].Width = 250;
                    tabla.Columns["NADA"].Width = 5;
                    tabla.Columns["P1"].Width = 30;
                    tabla.Columns["P2"].Width = 30;
                    tabla.Columns["P3"].Width = 30;
                    tabla.Columns["FH1"].Width = 100;
                    tabla.Columns["FH2"].Width = 100;
                    tabla.Columns["FH3"].Width = 100;

                    tabla.Columns["ID1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["ID3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["EQUIPOS"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["EQUIPOS"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P1"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P2"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["P3"].DefaultCellStyle.BackColor = Color.LightCyan;
                    tabla.Columns["P3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH1"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH2"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    tabla.Columns["FH3"].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

        }

        public Boolean checkDateFromTable(int torneo, int division, int cat)
        {

            bool v = true;

            if (tabla.Rows.Count == 0) v = false;
        
            if (torneo == 0)
            {
                if(division == 0)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[5].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[5].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[5].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[5].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[7].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[7].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[7].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[7].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[9].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[9].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[9].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[9].Value))))
                        {
                            v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[6].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[6].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[8].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[8].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[10].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[10].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }
                    }
                    return v;
                }
                else if (cat == 0)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[11].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[11].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[11].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[11].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[13].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[13].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[13].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[13].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[15].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[15].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[15].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[15].Value))))
                        {
                            v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[12].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[12].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[14].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[14].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[16].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[16].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }
                    }
                    return v;
                }
                else if (cat == 1)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[17].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[17].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[17].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[17].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[19].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[19].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[19].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[19].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[21].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[21].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[21].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[21].Value))))
                        {
                            v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[18].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[18].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[20].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[20].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[22].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[22].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }
                    }
                    return v;
                }
                else if (cat == 2)
                {
                    for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                    {
                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[23].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[23].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[23].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[23].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[25].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[25].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[25].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[25].Value))))
                        {
                            v = false;
                        }

                        if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[27].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[27].Value))) ||
                        (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[27].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[27].Value))))
                        {
                            v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[24].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[24].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[26].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[26].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[28].Value)))
                        {
                            string hora = Convert.ToString(tabla.Rows[i + 1].Cells[28].Value);
                            if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                        }
                    }
                    return v;
                }
            }
            else if (torneo == 1)
            {
                for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                {
                    if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[3].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[3].Value))) ||
                    (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[3].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[3].Value))))
                    {
                        v = false;
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[4].Value)))
                    {
                        string hora = Convert.ToString(tabla.Rows[i + 1].Cells[4].Value);
                        if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                    }

                }
                return v;
            }
            else if (torneo == 2)
            {
                for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                {
                    if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[3].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[3].Value))) ||
                    (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[3].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[3].Value))))
                    {
                        v = false;
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[4].Value)))
                    {
                        string hora = Convert.ToString(tabla.Rows[i + 1].Cells[4].Value);
                        if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                    }

                }
                return v;
            }
            else if (torneo == 3)
            {
                for (int i = 0; i < tabla.Rows.Count - 2; i += 3)
                {
                    if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[5].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[5].Value))) ||
                    (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[5].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[5].Value))))
                    {
                        v = false;
                    }

                    if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[7].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[7].Value))) ||
                    (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[7].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[7].Value))))
                    {
                        v = false;
                    }

                    if ((!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[9].Value)) && string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[9].Value))) ||
                    (string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i].Cells[9].Value)) && !string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[9].Value))))
                    {
                        v = false;
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[6].Value)))
                    {
                        string hora = Convert.ToString(tabla.Rows[i + 1].Cells[6].Value);
                        if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[8].Value)))
                    {
                        string hora = Convert.ToString(tabla.Rows[i + 1].Cells[8].Value);
                        if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                    }

                    if (!string.IsNullOrEmpty(Convert.ToString(tabla.Rows[i + 1].Cells[10].Value)))
                    {
                        string hora = Convert.ToString(tabla.Rows[i + 1].Cells[10].Value);
                        if (!Regex.IsMatch(hora, @"^\d{2}:\d{2}$")) v = false;
                    }
                }
                return v;
            }
            return false;
        }

        public void showDateTimePicker(string format, DataGridViewCellMouseEventArgs e)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = format;
            dateTimePicker.Visible = true;

            Rectangle rect = tabla.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            dateTimePicker.Location = new Point(rect.X, rect.Y);
            tabla.Controls.Add(dateTimePicker);

            dateTimePicker.CloseUp += (s, args) =>
            {
                tabla[e.ColumnIndex, e.RowIndex].Value = dateTimePicker.Value.ToString(format);
                tabla.Controls.Remove(dateTimePicker);
            };

            dateTimePicker.LostFocus += (s, args) =>
            {
                tabla.Controls.Remove(dateTimePicker);
            };
        }

    }
}
