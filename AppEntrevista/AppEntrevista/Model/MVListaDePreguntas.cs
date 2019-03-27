using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MVListaDePreguntas
    {
        public int idListPregunta { get; set; }
        public string nombreListPregunta { get; set; }
        public string creador { get; set; }
        public DateTime fechaCreado { get; set; }
        public int flagEstadoListPregCab { get; set; }

        public List<ListPreguntaDet> listPreguntaDet { get; set; }
    }
}
