using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ListPreguntaCab 
    {
        //private int _idListPregunta;
        //private string _nombreListPregunta;
        //private string _creador;
        //private DateTime _fechaCreado;
        //private int _flagEstadoListPregCab;
        //public List<ListPreguntaDet> _listPreguntaDet;

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //}

        //public int idListPregunta { get { return _idListPregunta; } set { _idListPregunta = value; OnPropertyChanged(); } }
        //public string nombreListPregunta { get { return _nombreListPregunta; } set { _nombreListPregunta = value; OnPropertyChanged(); } }
        //public string creador { get { return _creador; } set { _creador = value; OnPropertyChanged(); } }
        //public DateTime fechaCreado { get { return _fechaCreado; } set { _fechaCreado = value; OnPropertyChanged(); } }
        //public int flagEstadoListPregCab { get { return _flagEstadoListPregCab; } set { _flagEstadoListPregCab = value; OnPropertyChanged(); } }

        //public List<ListPreguntaDet> listPreguntaDet { get { return _listPreguntaDet; } set { _listPreguntaDet = value; OnPropertyChanged(); } }



        public int idListPregunta { get; set; }
        public string nombreListPregunta { get; set; }
        public string creador { get; set; }
        public DateTime fechaCreado { get; set; }
        public int flagEstadoListPregCab { get; set; }

       // public List<ListPreguntaDet> listPreguntaDet { get; set; }
    }
}
