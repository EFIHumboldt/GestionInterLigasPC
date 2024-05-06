using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInterLigas
{
    internal class query
    {
        

        public DataTable llenarTabla(int league_id, int division_id, int matchday_id)
        {

            try {

                conexion cn = new conexion(league_id);
                cn.abrirconexion();
                string cadena = "";
                if (league_id == 0)
                {
                    if (division_id == 0)
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona FROM partido as p " +
                                "INNER JOIN equipo as e_local ON e_local.ID = p.equipoLocal " +
                                "INNER JOIN equipo as e_visita ON e_visita.ID = p.equipoVisita " +
                                "INNER JOIN club as c_local ON e_local.club = c_local.ID " +
                                "INNER JOIN club as c_visita ON e_visita.club = c_visita.ID " +
                                "WHERE p.fechaLiga = (SELECT id FROM fecha WHERE numero = '" + matchday_id.ToString() + ") AND " +
                                "(e_local.division = 4 or e_local.division = 5 or e_local.division = 16 or e_local.division = 17 or e_local.division = 15 or e_local.division = 20) ORDER BY c_local.ID, p.ID;";
                    }
                    else if (division_id == 1)
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona, e_local.division," +
                                    "CASE" +
                                        "WHEN e_local.division = 18 THEN 1"+
                                        "WHEN e_local.division = 7 THEN 4"+
                                        "WHEN e_local.division = 8 THEN 5"+
                                        "WHEN e_local.division = 9 THEN 6"+
                                        "WHEN e_local.division = 10 THEN 7"+
                                        "WHEN e_local.division = 11 THEN 8"+
                                        "WHEN e_local.division = 12 THEN 9"+
                                        "WHEN e_local.division = 13 THEN 10"+
                                        "WHEN e_local.division = 14 THEN 11"+
                                   "END AS orden_personalizado"+
                            "FROM partido AS p"+
                            "INNER JOIN equipo AS e_local ON e_local.ID = p.equipoLocal " +
                            "INNER JOIN equipo AS e_visita ON e_visita.ID = p.equipoVisita " +
                            "INNER JOIN club AS c_local ON e_local.club = c_local.ID " +
                            "INNER JOIN club AS c_visita ON e_visita.club = c_visita.ID " +
                            "INNER JOIN fecha AS f ON f.ID = p.fechaLiga " +
                            "where f.numero = '" + matchday_id.ToString() + "' and(e_local.zona = 'Platino' or e_local.zona = 'Platino') " +
                            "ORDER BY c_local.ID, p.ID, orden_personalizado";
                    }
                    else if(division_id == 2)
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona, e_local.division," +
                                    "CASE" +
                                        "WHEN e_local.division = 18 THEN 1" +
                                        "WHEN e_local.division = 7 THEN 4" +
                                        "WHEN e_local.division = 8 THEN 5" +
                                        "WHEN e_local.division = 9 THEN 6" +
                                        "WHEN e_local.division = 10 THEN 7" +
                                        "WHEN e_local.division = 11 THEN 8" +
                                        "WHEN e_local.division = 12 THEN 9" +
                                        "WHEN e_local.division = 13 THEN 10" +
                                        "WHEN e_local.division = 14 THEN 11" +
                                   "END AS orden_personalizado" +
                            "FROM partido AS p" +
                            "INNER JOIN equipo AS e_local ON e_local.ID = p.equipoLocal " +
                            "INNER JOIN equipo AS e_visita ON e_visita.ID = p.equipoVisita " +
                            "INNER JOIN club AS c_local ON e_local.club = c_local.ID " +
                            "INNER JOIN club AS c_visita ON e_visita.club = c_visita.ID " +
                            "INNER JOIN fecha AS f ON f.ID = p.fechaLiga " +
                            "where f.numero = '" + matchday_id.ToString() + "' and(e_local.zona = 'Oro' or e_local.zona = 'Oro') " +
                            "ORDER BY c_local.ID, p.ID, orden_personalizado";
                    }
                    else if (division_id == 3)
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona, e_local.division," +
                                    "CASE" +
                                        "WHEN e_local.division = 18 THEN 1" +
                                        "WHEN e_local.division = 7 THEN 4" +
                                        "WHEN e_local.division = 8 THEN 5" +
                                        "WHEN e_local.division = 9 THEN 6" +
                                        "WHEN e_local.division = 10 THEN 7" +
                                        "WHEN e_local.division = 11 THEN 8" +
                                        "WHEN e_local.division = 12 THEN 9" +
                                        "WHEN e_local.division = 13 THEN 10" +
                                        "WHEN e_local.division = 14 THEN 11" +
                                   "END AS orden_personalizado" +
                            "FROM partido AS p" +
                            "INNER JOIN equipo AS e_local ON e_local.ID = p.equipoLocal " +
                            "INNER JOIN equipo AS e_visita ON e_visita.ID = p.equipoVisita " +
                            "INNER JOIN club AS c_local ON e_local.club = c_local.ID " +
                            "INNER JOIN club AS c_visita ON e_visita.club = c_visita.ID " +
                            "INNER JOIN fecha AS f ON f.ID = p.fechaLiga " +
                            "where f.numero = '" + matchday_id.ToString() + "' and(e_local.zona = 'Plata' or e_local.zona = 'Plata') " +
                            "ORDER BY c_local.ID, p.ID, orden_personalizado";
                    }
                    else
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona, e_local.division," +
                                    "CASE" +
                                        "WHEN e_local.division = 18 THEN 1" +
                                        "WHEN e_local.division = 7 THEN 4" +
                                        "WHEN e_local.division = 8 THEN 5" +
                                        "WHEN e_local.division = 9 THEN 6" +
                                        "WHEN e_local.division = 10 THEN 7" +
                                        "WHEN e_local.division = 11 THEN 8" +
                                        "WHEN e_local.division = 12 THEN 9" +
                                        "WHEN e_local.division = 13 THEN 10" +
                                        "WHEN e_local.division = 14 THEN 11" +
                                   "END AS orden_personalizado" +
                            "FROM partido AS p" +
                            "INNER JOIN equipo AS e_local ON e_local.ID = p.equipoLocal " +
                            "INNER JOIN equipo AS e_visita ON e_visita.ID = p.equipoVisita " +
                            "INNER JOIN club AS c_local ON e_local.club = c_local.ID " +
                            "INNER JOIN club AS c_visita ON e_visita.club = c_visita.ID " +
                            "INNER JOIN fecha AS f ON f.ID = p.fechaLiga " +
                            "where f.numero = '" + matchday_id.ToString() + "' and(e_local.zona = 'Bronce' or e_local.zona = 'Bronce') " +
                            "ORDER BY c_local.ID, p.ID, orden_personalizado";
                    }
                }
                else if (league_id == 1)
                {
                    if (division_id == 0)
                    {
                         cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona FROM partido as p " +
                                "INNER JOIN equipo as e_local ON e_local.ID = p.equipoLocal " +
                                "INNER JOIN equipo as e_visita ON e_visita.ID = p.equipoVisita " +
                                "INNER JOIN club as c_local ON e_local.club = c_local.ID " +
                                "INNER JOIN club as c_visita ON e_visita.club = c_visita.ID " +
                                "INNER JOIN fecha as f ON f.ID = p.fechaLiga WHERE f.numero = '" + matchday_id.ToString() + " AND (e_local.division = 1 or e_local.division = 2) ORDER BY c_local.ID, p.ID;";

                    }
                    else if (division_id == 1)
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona FROM partido as p " +
                                "INNER JOIN equipo as e_local ON e_local.ID = p.equipoLocal " +
                                "INNER JOIN equipo as e_visita ON e_visita.ID = p.equipoVisita " +
                                "INNER JOIN club as c_local ON e_local.club = c_local.ID " +
                                "INNER JOIN club as c_visita ON e_visita.club = c_visita.ID " +
                                "INNER JOIN fecha as f ON f.ID = p.fechaLiga WHERE f.numero = '" + matchday_id.ToString() + " AND (e_local.division = 3) ORDER BY c_local.ID, p.ID;";

                    }
                    else if (division_id == 2)
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona FROM partido as p " +
                                "INNER JOIN equipo as e_local ON e_local.ID = p.equipoLocal " +
                                "INNER JOIN equipo as e_visita ON e_visita.ID = p.equipoVisita " +
                                "INNER JOIN club as c_local ON e_local.club = c_local.ID " +
                                "INNER JOIN club as c_visita ON e_visita.club = c_visita.ID " +
                                "INNER JOIN fecha as f ON f.ID = p.fechaLiga WHERE f.numero = '" + matchday_id.ToString() + " AND (e_local.division = 4) ORDER BY c_local.ID, p.ID;";

                    }
                    else
                    {
                        cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona FROM partido as p " +
                                "INNER JOIN equipo as e_local ON e_local.ID = p.equipoLocal " +
                                "INNER JOIN equipo as e_visita ON e_visita.ID = p.equipoVisita " +
                                "INNER JOIN club as c_local ON e_local.club = c_local.ID " +
                                "INNER JOIN club as c_visita ON e_visita.club = c_visita.ID " +
                                "INNER JOIN fecha as f ON f.ID = p.fechaLiga WHERE f.numero = '" + matchday_id.ToString() + " AND (e_local.division = 5) ORDER BY c_local.ID, p.ID;";
                    }
                }
                else if (league_id == 2)
                {
                   cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona FROM partido as p " +
                                "INNER JOIN equipo as e_local ON e_local.ID = p.equipoLocal " +
                                "INNER JOIN equipo as e_visita ON e_visita.ID = p.equipoVisita " +
                                "INNER JOIN club as c_local ON e_local.club = c_local.ID " +
                                "INNER JOIN club as c_visita ON e_visita.club = c_visita.ID " +
                                "INNER JOIN fecha as f ON f.ID = p.fechaLiga WHERE f.numero = '" + matchday_id.ToString() + " ORDER BY c_local.ID, p.ID;";

                }
                else
                {
                    cadena = "SELECT p.ID, c_local.nombrecompleto, c_visita.nombrecompleto, p.golesLocal, p.golesVisita, e_local.zona FROM partido as p " +
                                "INNER JOIN equipo as e_local ON e_local.ID = p.equipoLocal " +
                                "INNER JOIN equipo as e_visita ON e_visita.ID = p.equipoVisita " +
                                "INNER JOIN club as c_local ON e_local.club = c_local.ID " +
                                "INNER JOIN club as c_visita ON e_visita.club = c_visita.ID " +
                                "INNER JOIN fecha as f ON f.ID = p.fechaLiga WHERE f.numero = '" + matchday_id.ToString() + " ORDER BY c_local.ID, p.ID;";
                }

                MySqlCommand comando = new MySqlCommand(cadena, cn.conectarbd);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabla_resultados_partidos");
                cn.cerrarconexion();
                return ds.Tables["tabla_resultados_partidos"];

            } catch (Exception e) { 
                MessageBox.Show(e.Message);
                return null;
            }


            

        }
    }
}
