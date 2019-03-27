using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppEntrevista.Servicios
{
    public class RequerimientoServicio
    {
        private ObservableCollection<Requerimiento> requerimientos { get; set; }

        public RequerimientoServicio()
        {
            if (requerimientos == null)
            {
                requerimientos = new ObservableCollection<Requerimiento>();
            }
        }

        public ObservableCollection<Requerimiento> Lista()
        {
            return requerimientos;
        }


    }
}
