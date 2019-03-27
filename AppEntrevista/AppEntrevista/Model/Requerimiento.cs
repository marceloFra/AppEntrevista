using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requerimiento //: INotifyPropertyChanged
    {
        /* private int _idRequerimiento;
         private string _nombreRequerimiento;
         private DateTime _fechaTentativa;
         private string _empresa;
         private string _estadoRequerimiento;
         private string _puesto;

         public event PropertyChangedEventHandler PropertyChanged;

         protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
         {
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

         } 

         public int idRequerimiento { get { return _idRequerimiento; } set { _idRequerimiento = value; OnPropertyChanged(); } }
         public string nombreRequerimiento { get { return _nombreRequerimiento; } set { _nombreRequerimiento = value; OnPropertyChanged(); } }
         public DateTime fechaTentativa { get { return _fechaTentativa; } set  { _fechaTentativa = value; OnPropertyChanged(); } }
         public string empresa { get { return _empresa; } set { _empresa = value; OnPropertyChanged(); } }
         public string estadoRequerimiento { get { return _estadoRequerimiento; } set { _estadoRequerimiento = value; OnPropertyChanged(); } }
         public string puesto { get { return _puesto; } set { _puesto = value; OnPropertyChanged(); } }
     */

        //[JsonProperty(PropertyName = "idRequerimiento")]
        public int idRequerimiento { get; set; }
        //[JsonProperty(PropertyName = "nombreRequerimiento")]
        public string nombreRequerimiento { get; set; }
        // [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime fechaTentativa { get; set; }
        //[JsonProperty(PropertyName = "empresa")]
        public string empresa { get; set; }
        //[JsonProperty(PropertyName = "estadoRequerimiento")]
        public string estadoRequerimiento { get; set; }
        //[JsonProperty(PropertyName = "puesto")]
        public string puesto { get; set; }

    }
}
