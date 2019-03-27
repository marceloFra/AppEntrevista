using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppEntrevista.Model
{
    public class ArchivoAudioModel
    {
        /** para enviar string
         * public String audio { get; set; }
        */

        /** para enviar bytes
     *
    */
        public string audio { get; set; }
        public int Idpostulante { get; set; }
        public int idRequerimiento { get; set; }
        public int idListPregunta { get; set; }
        public int idPregunta { get; set; }

    }
}
