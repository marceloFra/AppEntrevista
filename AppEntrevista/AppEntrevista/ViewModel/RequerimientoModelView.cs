using AppEntrevista.Servicios;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppEntrevista.ViewModel
{
    public class RequerimientoModelView: Requerimiento
    {
        public ObservableCollection<Requerimiento> Requerimientos { get; set; }

        RequerimientoServicio servicio = new RequerimientoServicio();
        public RequerimientoModelView()
        {
            Requerimientos = servicio.Lista();
        }

    }
}
