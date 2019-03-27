using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using AppEntrevista.CS;

namespace AppEntrevista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostulantesPregPage : ContentPage
	{

        private string url = ""; 
        private HttpClient _Client = new HttpClient();
        private List<ListPreguntaDet> requerimineto;
         
        int idPostulantes = 0;
        int idRequerimiento = 0;
        Postulante postulantes = new Postulante();
        Requerimiento requerimiento = new Requerimiento();
        public PostulantesPregPage (Requerimiento reque,Postulante modelo)
		{
			InitializeComponent ();
            url = Servicio.IP + "pregunta/listPregDetByPost/" + modelo.idPostulante; 
            ListaPreguntas();
            BindingContext = modelo;
            idPostulantes = modelo.idPostulante;
            idRequerimiento = modelo.idRequerimiento;

            requerimiento = reque;
            postulantes = modelo;

        }

       /* public Postulante EntidadPos()
        {
            Postulante model = new Postulante();
            model.nombre =  nombre;
            model.nombre =  correo;
            return model;
        }*/

        public async void ListaPreguntas()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaDet>>(content);
                requerimineto = new List<ListPreguntaDet> (post);
                PostulantePre_List.ItemsSource = requerimineto; 
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;
            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde", "Aceptar");
                waitInidicator.IsRunning = false;
                opacidad.IsVisible = false;
                // return;
            }
            waitInidicator.IsRunning = false;
        }



        private void PostulantePre_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ListPreguntaDet modelo = (ListPreguntaDet)e.SelectedItem;


                //string nombre = Servicio.GenerarNombre(idPostula, idReque, modelo.idListPregunta, modelo.idPregunta);
                // Postulante modelo = (Postulante)e.SelectedItem;
                // Navigation.PushAsync(new EvaluaPreguntaPage(idPostulantes, idRequerimiento, modelo.idListPregunta, modelo.idPregunta));
                 

                Navigation.PushAsync(new EvaluaPreguntaPage(postulantes.idPostulante, requerimiento.idRequerimiento, modelo.idListPregunta, modelo.idPregunta));
            }

        }
    }
}