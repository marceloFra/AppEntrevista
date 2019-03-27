using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PostulanteRequeDet
    {
        public int idRequerimiento { get; set; }
        public int idPostulante { get; set; }
        public string codPostu { get; set; }
        public int flagEstadoRespuestas { get; set; }
    }
}
