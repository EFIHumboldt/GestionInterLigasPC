using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInterLigas.entities
{
    public class Partido
    {
        public int Id { get; set; }
        public int IdLocal { get; set; }
        public int IdVisita { get; set; }
        public string NombreLocal { get; set; }
        public string NombreVisita { get; set; }
        public string ResultadoLocal { get; set; }
        public string ResultadoVisita { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }

        public Partido()
        {
        }
        public Partido(int id, int idLocal, int idVisita, string nombreLocal, string nombreVisita, string resultadoLocal, string resultadoVisita, string fecha, string hora)
        {
            Id = id;
            IdLocal = idLocal;
            IdVisita = idVisita;
            NombreLocal = nombreLocal;
            NombreVisita = nombreVisita;
            ResultadoLocal = resultadoLocal;
            ResultadoVisita = resultadoVisita;
            Fecha = fecha;
            Hora = hora;
        }

        public Partido(int id, string resultadoLocal, string resultadoVisita, string fecha, string hora)
        {
            Id = id;
            ResultadoLocal = resultadoLocal;
            ResultadoVisita = resultadoVisita;
            Fecha = fecha;
            Hora = hora;
        }
    }

    
}
