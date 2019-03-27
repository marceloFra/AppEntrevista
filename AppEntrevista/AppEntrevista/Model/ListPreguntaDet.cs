using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ListPreguntaDet : INotifyPropertyChanged  
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        } 

        public int idPregunta { get; set; }
        public int idListPregunta { get; set; }
        public string pregunta { get; set; }
        public string creador { get; set; }
        public int flagEstadoListPregDet { get; set; }
        public int idRequerimiento { get; set; }
        public int numero { get; set; }
    }
}
